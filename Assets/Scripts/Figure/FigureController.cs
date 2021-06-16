using System;
using System.Linq;
using Block;
using Core;
using UnityEngine;

namespace Figure
{
	public class SideBlock
	{
		public BlockType Type;
		public BlockController Controller;
	}

	public class FigureController : MonoBehaviour
	{
		private readonly ICommonFactory _factory;

		private readonly FigureModel _model;
		private FigureView _view;
		private BlockController[] _blocks;
		private SideBlock[] _sideBlocks;

		public FigureController(ICommonFactory factory, GameConfig config)
		{
			_factory = factory;

			_model = new FigureModel();

			CreateFigure(_factory, config);
		}

		private void CreateFigure(ICommonFactory factory, GameConfig config)
		{
			_view = new GameObject(FigureModel.FigureName).AddComponent<FigureView>();
			_view.Init();
			_view.SetPosition(FigureModel.SpawnPosition);

			CreateBlocks(factory, config);
		}

		private void CreateBlocks(ICommonFactory factory, GameConfig config)
		{
			_blocks = new BlockController[config.TotalBlocksInFigure];

			for (var i = 0; i < _blocks.Length; i++)
			{
				_blocks[i] = new BlockController();
				_blocks[i].CreateView(factory, config.BlockPrefab, _view.transform);
				_blocks[i].SetPosition(Vector3.zero + Vector3.up * i * config.BlocksGap);
			}

			_sideBlocks = new SideBlock[config.NotDefaultBlocks];

			for (var i = 0; i < _sideBlocks.Length; i++)
			{
				var heightId = Randomizer.GetNumberInRange(0, _blocks.Length);
				var sideType = (BlockType) Randomizer.GetNumberInRange(1, Enum.GetNames(typeof(BlockType)).Length);
				var sourceBlock = _blocks[heightId];

				_sideBlocks[i] = new SideBlock();

				var sideBlock = new BlockController();
				sideBlock.CreateView(factory, config.BlockPrefab, _view.transform);

				if (i > 0)
				{
					SideBlock lastSideBlockWithSameType = null;

					foreach (var block in _sideBlocks)
					{
						if(block == null)
							break;

						if (block.Type == sideType)
							lastSideBlockWithSameType = block;
					}

					if (lastSideBlockWithSameType != null)
						sourceBlock = lastSideBlockWithSameType.Controller;
				}

				_sideBlocks[i].Controller = sideBlock;
				_sideBlocks[i].Type = sideType;

				var sideBlockPosition = _model.GetSideBlockPosition(sideType, sourceBlock.GetPosition(), config.BlocksGap);

				sideBlock.SetPosition(sideBlockPosition);
			}
		}
	}
}
