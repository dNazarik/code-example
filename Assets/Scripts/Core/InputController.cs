using System;
using UnityEngine;

namespace Core
{
	public class InputController : IUpdatable
	{
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
					Debug.Log(isLeft ? "LEFT" : "RIGHT");
				else
					Debug.Log("MISSLICK");
			}
		}
	}
}
