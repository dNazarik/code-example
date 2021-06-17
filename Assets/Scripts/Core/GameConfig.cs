using UnityEngine;

namespace Core
{
	[CreateAssetMenu(fileName = Constants.GameConfigName, menuName = Constants.GameConfigMenuName)]
	public class GameConfig : ScriptableObject
	{
		public GameObject BlockPrefab;
		public Material DefaultBlockMaterial;
		public int TotalBlocksInFigure;
		public int NotDefaultBlocks;
		public int BarrierExtraHeightAmount;
		public int BarriersAmount;
		public int BarriersOffset;
		public float BlocksGap;
		public float FigureBaseSpeed;
	}
}
