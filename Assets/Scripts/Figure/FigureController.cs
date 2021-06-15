using System;
using Block;
using Core;
using UnityEngine;

namespace Figure
{
	public class FigureController : MonoBehaviour
	{
		private readonly ICommonFactory _factory;

		private FigureModel _model;
		private FigureView _view;
		private BlockController[] _blocks;

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

			for (var i = 0; i < config.NotDefaultBlocks; i++)
			{
				var heightId = Randomizer.GetNumberInRange(0, _blocks.Length);
				var sideId = Randomizer.GetNumberInRange(1, Enum.GetNames(typeof(BlockType)).Length);
			}
		}
	}
}
