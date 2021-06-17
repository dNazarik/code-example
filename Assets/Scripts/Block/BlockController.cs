using Core;
using UnityEngine;

namespace Block
{
	public class BlockController
	{
		private readonly BlockModel _model;

		private BlockView _view;

		public BlockController() => _model = new BlockModel();
		public void SetPosition(Vector3 position) => _view.SetPosition(position);
		public void SetColor(Material sourceMaterial, Color color) => _view.SetColor(sourceMaterial, color);
		public Vector3 GetPosition() => _view.transform.localPosition;
		public Vector3Int GetCoordinates() => _model.BlockCoordinates;
		public bool IsActive() => _model.IsActive;

		public void CreateView(ICommonFactory factory, GameObject prefab, Transform parent, Vector3Int coordinates)
		{
			_view = factory.InstantiateObject<BlockView>(prefab, parent);
			_view.name = coordinates.ToString();
			_model.BlockCoordinates = coordinates;
		}

		public void SetActivity(bool activity)
		{
			_model.IsActive = activity;

			_view.SetActivity(activity);
		}
	}
}
