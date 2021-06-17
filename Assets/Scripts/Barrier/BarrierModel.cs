using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Barrier
{
	public class BarrierModel
	{
		public static readonly Vector3 FirstBarrierPosition = new Vector3(0.0f, 0.2f, 0.0f);
		public const string BarrierName = "Barrier_";
		private const int BarrierWidth = 11; //blocks

		private readonly GameConfig _config;

		public BarrierModel(GameConfig config) => _config = config;

		public Vector3[] GetBarrierWallPositions(Vector3 middleBlockPosition, int height)
		{
			var result = new List<Vector3>(height * BarrierWidth);
			var widthLimit = Mathf.FloorToInt((float) BarrierWidth / 2);

			for (var i = 0; i < BarrierWidth; i++)
			{
				for (var j = 0; j < height; j++)
				{
					var position = new Vector3(middleBlockPosition.x + _config.BlocksGap * (i - widthLimit),
						middleBlockPosition.y + _config.BlocksGap * j, 0.0f);
					result.Add(position);
				}
			}

			return result.ToArray();
		}

		public Vector2Int[] GetGapsMaximumRadius(Vector2Int[] gapsCoordinates)
		{
			var result = new Vector2Int[gapsCoordinates.Length];

			for (var i = 0; i < gapsCoordinates.Length; i++)
			{
				if (gapsCoordinates[i].x == 0)
				{
					result[i] = new Vector2Int(gapsCoordinates[i].y, 1);

					continue;
				}

				result[i] = new Vector2Int(gapsCoordinates[i].y, gapsCoordinates[i].x * 2);
			}

			return result;
		}
	}
}
