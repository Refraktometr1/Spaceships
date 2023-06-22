using Codebase.Spaceships;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Services
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _mainCanvas;
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private Button _createShip;
        private StaticDataService _staticDataService;
        
        private void Awake()
        {
            _staticDataService = new StaticDataService();
            _staticDataService.Load();
        }

        private void Start()
        {
            var mainCanvas = Instantiate(_mainCanvas);
            var createShipButton = Instantiate(_createShip, mainCanvas.transform);
            
            var _gameFactory = new GameFactory(mainCanvas, slotPrefab, _staticDataService);
            
            createShipButton.onClick.AddListener(() => _gameFactory.CreateShip(ShipType.MillenniumFalcon, 1)); 
        }
    }
}