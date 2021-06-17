using System;
using UnityEngine;

namespace Core
{
	public class InputController : IUpdatable
	{
		public event Action<bool> OnSwipeDetected; //arg0: is left swipe

		private float _startTouchPosition;

		public void Update(float deltaTime)
		{
#if !UNITY_EDITOR
			if(Input.touchCount == 0)
				return;
#endif

			if (Input.GetMouseButtonDown(0))
				_startTouchPosition = Input.mousePosition.x;

			var currentTouchPosition = Input.mousePosition.x;
			
			if (Input.GetMouseButtonUp(0))
			{
				var offset = _startTouchPosition - currentTouchPosition;
				var isLeft = offset > 0.0f;

				if (Math.Abs(offset) > float.Epsilon)
					OnSwipeDetected?.Invoke(isLeft);
			}
		}
	}
}
