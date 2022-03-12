using Game.Controllers;
using Profile;
using UnityEngine;

public class StartFightController : BaseController
{
    private StartFightView _startFightView;
    private PlayerProfileModel _playerProfile;

    public StartFightController(Transform placeForUI, PlayerProfileModel playerProfile, StartFightView startFightView)
    {
        _playerProfile = playerProfile;
        _startFightView = GameObject.Instantiate(startFightView, placeForUI);
        AddGameObject(_startFightView.gameObject);

        SubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _startFightView.StartFightButton.onClick.AddListener(StartFight);
    }

    private void StartFight()
    {
        _playerProfile.CurrentState.Value = Tools.GameState.Fight;
    }

    protected override void OnDispose()
    {
        _startFightView.StartFightButton.onClick.RemoveAllListeners();

        base.OnDispose();
    }
}