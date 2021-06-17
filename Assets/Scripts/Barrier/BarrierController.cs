using System;
using System.Collections.Generic;
using Block;
using Core;
using UnityEngine;

namespace Barrier
{
	public class BarrierController
	{
		private readonly BarrierModel _model;

		private Dictionary<Transform, BlockController[]> _barriers;

		public BarrierController(ICommonFactory factory, GameConfig config, Vector3 middleBlockPosition)
		{
			_model = new BarrierModel(config);

			CreateBarriers(factory, config, middleBlockPosition);
		}

		private void CreateBarriers(ICommonFactory factory, GameConfig config, Vector3 middleBlockPosition)
		{
			_barriers = new Dictionary<Transform, BlockController[]>(config.BarriersAmount);

			for (var i = 0; i < config.BarriersAmount; i++)
			{
				var positions = _model.GetBarrierWallPositions(middleBlockPosition, config.TotalBlocksInFigure + 2);
				var barrierRoot = new GameObject(BarrierModel.BarrierName + _barriers.Count).transform;
				barrierRoot.localPosition = BarrierModel.FirstBarrierPosition;

				var blocks = CreateBlocks(factory, config, barrierRoot, positions);

				_barriers.Add(barrierRoot, blocks);
			}
		}

		private BlockController[] CreateBlocks(ICommonFactory factory,  GameConfig config, Transform parent, Vector3[] positions)
		{
			var blocks = new BlockController[positions.Length];

			for (var i = 0; i < blocks.Length; i++)
			{
				blocks[i] = new BlockController();
				blocks[i].CreateView(factory, config.BlockPrefab, parent);
				blocks[i].SetPosition(positions[i]);
				blocks[i].SetColor(config.DefaultBlockMaterial, Randomizer.GetRandomColor(false));
			}

			return blocks;
		}
	}
}
