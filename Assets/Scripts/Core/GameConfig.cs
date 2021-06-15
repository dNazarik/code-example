using UnityEngine;

namespace Core
{
	[CreateAssetMenu(fileName = Constants.GameConfigName, menuName = Constants.GameConfigMenuName)]
	public class GameConfig : ScriptableObject
	{
		public GameObject BlockPrefab;
		public int TotalBlocksInFigure;
		public int NotDefaultBlocks;
		public float BlocksGap;
	}
}
