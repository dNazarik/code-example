using System.Collections.Generic;
using System.Linq;
using Block;
using Core;
using UnityEngine;

namespace Barrier
{
	public class BarrierController
	{
		private readonly BarrierModel _model;

		private Dictionary<Transform, BlockController[]> _barriers;

		public BarrierController(ICommonFactory factory, GameConfig config, Vector3 middleBlockPosition,
			Vector3Int[] gapsCoordinates)
		{
			_model = new BarrierModel(config);

			CreateBarriers(factory, config, middleBlockPosition, gapsCoordinates);
		}

		private void CreateBarriers(ICommonFactory factory, GameConfig config, Vector3 middleBlockPosition,
			Vector3Int[] gapsCoordinates)
		{
			_barriers = new Dictionary<Transform, BlockController[]>(config.BarriersAmount);

			for (var i = 0; i < config.BarriersAmount; i++)
			{
				var positions = _model.GetBarrierWallPositions(middleBlockPosition, config.TotalBlocksInFigure + config.BarrierExtraHeightAmount);
				var barrierRoot = new GameObject(BarrierModel.BarrierName + _barriers.Count).transform;
				barrierRoot.localPosition = BarrierModel.FirstBarrierPosition + Vector3.forward * i * config.BarriersOffset;

				var blocks = CreateBlocks(factory, config, barrierRoot, positions, gapsCoordinates);

				ApplyGaps(blocks, gapsCoordinates);

				_barriers.Add(barrierRoot, blocks);
			}
		}

		private BlockController[] CreateBlocks(ICommonFactory factory, GameConfig config, Transform parent,
			IReadOnlyList<Vector3> positions, Vector3Int[] gapsCoordinates)
		{
			var blocks = new BlockController[positions.Count];
			var width = positions.Count / (config.TotalBlocksInFigure + config.BarrierExtraHeightAmount);
			var yCoordinate = 0;
			var xCoordinateLimit = Mathf.FloorToInt((float) width / 2);
			var xCounter = -xCoordinateLimit;

			for (var i = 0; i < blocks.Length; i++)
			{
				var coordinates = new Vector3Int(xCounter, yCoordinate, 0);
				var isGap = gapsCoordinates.Any(c => c.x == coordinates.x && c.y == coordinates.y);

				blocks[i] = new BlockController();
				blocks[i].CreateView(factory, config.BlockPrefab, parent, coordinates);
				blocks[i].SetPosition(positions[i]);
				blocks[i].SetColor(config.DefaultBlockMaterial, Randomizer.GetRandomColor(false));
				blocks[i].SetActivity(!isGap);

				yCoordinate++;

				if (yCoordinate == config.TotalBlocksInFigure + config.BarrierExtraHeightAmount)
				{
					yCoordinate = 0;
					xCounter++;
				}
			}

			return blocks;
		}

		private void ApplyGaps(BlockController[] blocks, Vector3Int[] gapsCoordinates)
		{
			//foreach (var vector2Int in gapsCoordinates)
			//{
			//	Debug.Log(vector2Int);
			//}
		}
	}
}
