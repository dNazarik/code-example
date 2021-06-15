using UnityEngine;

namespace Figure
{
	public class FigureView : MonoBehaviour
	{
		private Transform _transform;

		public void Init()
		{
			_transform = transform;
		}

		public void SetPosition(Vector3 position) => _transform.localPosition = position;
	}
}
