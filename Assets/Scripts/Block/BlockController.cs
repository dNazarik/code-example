using Core;
using UnityEngine;

namespace Block
{
	public class BlockController
	{
		private BlockView _view;

		public void SetPosition(Vector3 position) => _view.SetPosition(position);
		public Vector3 GetPosition() => _view.transform.localPosition;

		public void CreateView(ICommonFactory factory, GameObject prefab, Transform parent)
			=> _view = factory.InstantiateObject<BlockView>(prefab, parent);

		public void SetColor(Material sourceMaterial, Color color) => _view.SetColor(sourceMaterial, color);
	}
}
