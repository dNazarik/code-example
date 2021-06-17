using System.Collections.Generic;
using Barrier;
using Figure;
using UnityEngine;

namespace Core
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private GameConfig _config;
		[SerializeField] private Transform _cameraTransform;

		private FigureController _figure;
		private BarrierController _barrier;
		private ICommonFactory _commonFactory;
		private InputController _inputController;
		private List<IUpdatable> _updatables;

		private void Awake()
		{
			_commonFactory = new CommonFactory();
			_updatables = new List<IUpdatable>();

			StartGame();
		}

		private void OnDestroy()
		{
			if (_inputController != null)
				_inputController.OnSwipeDetected -= _figure.Swipe;
		}

		private void Update()
		{
			var deltaTime = Time.deltaTime;

			foreach (var updatable in _updatables)
				updatable?.Update(deltaTime);
		}

		private void StartGame()
		{
			_inputController = new InputController();

			_updatables.Add(_inputController);

			GenerateFigure();

			GenerateBarriers();
		}

		private void GenerateFigure()
		{
			_figure = new FigureController(_commonFactory, _config);

			if(_inputController != null)
				_inputController.OnSwipeDetected += _figure.Swipe;

			_updatables.Add(_figure);

			_cameraTransform.SetParent(_figure.GetFigureTransform());
		}

		private void GenerateBarriers() => _barrier = new BarrierController(_commonFactory, _config, _figure.GetMiddleBlockPosition());
	}
}
