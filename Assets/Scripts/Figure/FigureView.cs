using System.Threading.Tasks;
using UnityEngine;

namespace Figure
{
	public class FigureView : MonoBehaviour
	{
		private Transform _transform, _rotator;

		public void Init()
		{
			_transform = transform;
			_rotator = _transform.GetChild(0);
		}

		public void SetPosition(Vector3 position) => _transform.localPosition = position;
		public void MoveForward(float speed) => _transform.Translate(Vector3.forward * speed);

		public async Task Rotate(bool isClockwise)
		{
			var startRotation = _rotator.localRotation;
			var targetRotation = _rotator.localRotation * Quaternion.Euler(0, isClockwise ? 90.0f : -90.0f, 0);
			var deltaTime = Time.deltaTime;
			var timer = 0.0f;

			while (timer < FigureModel.RotationTime)
			{
				await Task.Delay(1);

				_rotator.localRotation = Quaternion.Lerp(startRotation, targetRotation, timer);

				timer = timer + deltaTime;
			}

			_rotator.localRotation = targetRotation;
		}
	}
}
