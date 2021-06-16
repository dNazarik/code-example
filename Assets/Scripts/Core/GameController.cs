using System.Collections.Generic;
using Figure;
using UnityEngine;

namespace Core
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private GameConfig _config;
		[SerializeField] private Transform _cameraTransform;

		private FigureController _figure;
		private ICommonFactory _commonFactory;
		private InputController _inputController;
		private List<IUpdatable> _updatables;

		private void Awake()
		{
			_commonFactory = new CommonFactory();
			_updatables = new List<IUpdatable>();

			StartGame();
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
		}

		private void GenerateFigure()
		{
			_figure = new FigureController(_commonFactory, _config);

			_updatables.Add(_figure);

			_cameraTransform.SetParent(_figure.GetFigureTransform());
		}
	}
}
