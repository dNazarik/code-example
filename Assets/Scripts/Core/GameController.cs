using Figure;
using UnityEngine;

namespace Core
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private GameConfig _config;

		private FigureController _figure;
		private ICommonFactory _commonFactory;

		private void Awake()
		{
			_commonFactory = new CommonFactory();

			StartGame();
		}

		private void StartGame()
		{
			GenerateFigure();
		}

		private void GenerateFigure()
		{
			_figure = new FigureController(_commonFactory, _config);
		}
	}
}
