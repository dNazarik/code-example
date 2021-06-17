using UnityEngine;

namespace Block
{
	public class BlockView : MonoBehaviour
	{
		[SerializeField] private Transform _transform;
		[SerializeField] private Renderer _renderer;

		public void SetPosition(Vector3 position) => _transform.localPosition = position;
		public void SetActivity(bool isActive) => _renderer.enabled = isActive;

		public void SetColor(Material sourceMaterial, Color color)
		{
			var material = new Material(sourceMaterial) {color = color};

			_renderer.material = material;
		}
	}
}
