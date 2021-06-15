using UnityEngine;

namespace Block
{
	public class BlockView : MonoBehaviour
	{
		[SerializeField] private Transform _transform;

		public void SetPosition(Vector3 position) => _transform.localPosition = position;
	}
}
