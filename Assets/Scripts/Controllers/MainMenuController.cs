using Game.Controllers;
using Profile;
using Tools;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private MainMenuView _menuView;
        private readonly PlayerProfileModel _playerProfile;
        private readonly ResourcePath _resourcePath;

        public MainMenuController(Transform placeForUI, PlayerProfileModel player)
        {
            _resourcePath = new ResourcePath("Prefabs/MainMenu");
            _playerProfile = player;
            _menuView = LoadMenuView(placeForUI);
            _menuView.Init(StartGame);
        }

        private void StartGame()
        {
            _playerProfile.CurrentState.Value = GameState.Game;
            _playerProfile.AnalyticTools.SendMessage("start_game");
            _playerProfile.AdsShower.ShowInterstitial();
        }

        private MainMenuView LoadMenuView(Transform placeForUI)
        {
            GameObject gameObject = Object.Instantiate(ResourceLoader.Load<GameObject>(_resourcePath), placeForUI, false);
            AddGameObject(gameObject);
            return gameObject.GetComponent<MainMenuView>();
        }
    }
}
