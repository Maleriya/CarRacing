using Profile;
using System.Collections.Generic;
using Tools;
using UI;
using UnityEngine;

namespace Game.Controllers
{
    internal class MainController : BaseController
    {
        public MainController(Transform placeForUi, PlayerProfileModel playerProfile, List<ItemConfig> itemConfigs, IInventoryView inventoryView,
            List<AbilityItemConfig> abilityConfigs, IAbilityCollectionView abilityCollectionView,
            DailyRewardView dailyRewardView, FightWindowView fightWindowView, CurrencyView currencyView, StartFightView startFightView)
        {
            _playerProfile = playerProfile;
            _placeForUi = placeForUi;
            _itemConfigs = itemConfigs;
            _inventoryView = inventoryView;
            _abilityConfigs = abilityConfigs;
            _abilityCollectionView = abilityCollectionView;
            _dailyRewardView = dailyRewardView;
            _fightWindowView = fightWindowView;
            _currencyView = currencyView;
            _startFightView = startFightView;

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
        private AbilitiesController _abilitiesController;
        List<AbilityItemConfig> _abilityConfigs;
        IAbilityCollectionView _abilityCollectionView;

        private readonly DailyRewardView _dailyRewardView;
        private readonly FightWindowView _fightWindowView;
        private readonly CurrencyView _currencyView;
        private readonly StartFightView _startFightView;

        private DailyRewardController _dailyRewardController;
        private FightWindowController _fightWindowController;
        private CurrencyController _currencyController;
        private StartFightController _startFightController;

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _playerProfile);
                    _gameController?.Dispose();
                    _dailyRewardController?.Dispose();
                    _inventoryController?.Dispose();
                    _abilitiesController?.Dispose();
                    break;
                case GameState.Game:
                    _inventoryController = new InventoryController(_itemConfigs, _inventoryView);
                    _inventoryController.ShowInventory();

                    _abilitiesController = new AbilitiesController(_abilityConfigs, _abilityCollectionView);
                    _abilitiesController.ShowAbilities();

                    _gameController = new GameController(_playerProfile);
                    _startFightController = new StartFightController(_placeForUi, _playerProfile, _startFightView);

                    _mainMenuController?.Dispose();
                    _fightWindowController?.Dispose();
                    break;
                case GameState.DailyReward:
                    _dailyRewardController = new DailyRewardController(_placeForUi, _playerProfile, _dailyRewardView, _currencyView);
                    _dailyRewardController.RefreshView();

                    _mainMenuController?.Dispose();
                    break;
                case GameState.Fight:
                    _fightWindowController = new FightWindowController(_placeForUi, _playerProfile, _fightWindowView);
                    _fightWindowController.RefreshView();

                    _gameController?.Dispose();
                    _startFightController?.Dispose();
                    _inventoryController?.Dispose();
                    _abilitiesController?.Dispose();
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        protected override void OnDispose()
        {
            DisposeAllControllers();
            _playerProfile.CurrentState.UnSubscribeOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void DisposeAllControllers()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _fightWindowController?.Dispose();
            _dailyRewardController?.Dispose();
            _startFightController?.Dispose();
            _inventoryController?.Dispose();
            _abilitiesController?.Dispose();
        }
    }

}
