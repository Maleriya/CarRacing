using Profile;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;

namespace Game.Controllers
{
    internal class MainController : BaseController
    {
        public MainController(Transform placeForUi, PlayerProfileModel playerProfile, List<ItemConfig> itemConfigs, IInventoryView inventoryView)
        {
            _playerProfile = playerProfile;
            _placeForUi = placeForUi;
            _itemConfigs = itemConfigs;
            _inventoryView = inventoryView;

            OnChangeGameState(_playerProfile.CurrentState.Value);
            playerProfile.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly Transform _placeForUi;
        private readonly PlayerProfileModel _playerProfile;
        private InventoryController _inventoryController;
        private readonly List<ItemConfig> _itemConfigs;
        private IInventoryView _inventoryView;
        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _playerProfile.CurrentState.UnSubscribeOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _playerProfile);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _inventoryController = new InventoryController(_itemConfigs, _inventoryView);
                    _inventoryController.ShowInventory();

                    _gameController = new GameController(_playerProfile);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }
    }

}
