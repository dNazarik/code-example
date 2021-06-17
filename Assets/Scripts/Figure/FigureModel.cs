﻿using Core;
using UnityEngine;

namespace Figure
{
	public class FigureModel
	{
		public const float RotationTime = 1.0f;
		public const string FigureName = "Figure";
		public const string RotatorName = "Rotator";
		public static readonly Vector3 SpawnPosition = new Vector3(0.0f, 0.2f, -6.0f);

		private readonly GameConfig _config;

		public bool IsRotating { get; set; }

		public FigureModel(GameConfig config) => _config = config;
		public float GetMovementSpeed(float deltaTime) => _config.FigureBaseSpeed * deltaTime;

		public Vector3 GetSideBlockPosition(BlockType type, Vector3 sourceBlockPosition, float gap)
		{
			switch (type)
			{
				case BlockType.Back:
					return sourceBlockPosition + Vector3.back * gap;
				case BlockType.Forward:
					return sourceBlockPosition + Vector3.forward * gap;
				case BlockType.Left:
					return sourceBlockPosition + Vector3.left * gap;
				case BlockType.Right:
					return sourceBlockPosition + Vector3.right * gap;
				default:
					return sourceBlockPosition;
			}
		}

		public int GetCoordinateByBlockType(BlockType type)
		{
			switch (type)
			{
				case BlockType.Left:
					return -1;
				case BlockType.Right:
					return 1;
				default:
					return 0;
			}
		}
	}
}
