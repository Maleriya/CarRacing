using DG.Tweening;
using Game.Controllers;
using Profile;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FightWindowController : BaseController
{
    private FightWindowView _fightWindowView;
    PlayerProfileModel _playerProfile;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _countCrime;

    private Money _money;
    private Power _power;
    private Health _health;

    private Enemy _enemy;

    public FightWindowController(Transform placeForUI, PlayerProfileModel playerProfile, FightWindowView fightWindowView)
    {
        _playerProfile = playerProfile;

        _fightWindowView = GameObject.Instantiate(fightWindowView, placeForUI);
        AddGameObject(_fightWindowView.gameObject);
    }

    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Flappy");

        _money = new Money();
        _money.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _health = new Health();
        _health.Attach(_enemy);

        _fightWindowView.AddButtonMoney.onClick.AddListener(() => ChangeMoney(true));
        _fightWindowView.MinusButtonMoney.onClick.AddListener(() => ChangeMoney(false));

        _fightWindowView.AddButtonHealth.onClick.AddListener(() => ChangeHealth(true));
        _fightWindowView.MinusButtonHealth.onClick.AddListener(() => ChangeHealth(false));

        _fightWindowView.AddButtonPower.onClick.AddListener(() => ChangePower(true));
        _fightWindowView.MinusButtonPower.onClick.AddListener(() => ChangePower(false));

        _fightWindowView.AddButtonCrime.onClick.AddListener(() => ChangeCrime(true));
        _fightWindowView.MinusButtonCrime.onClick.AddListener(() => ChangeCrime(false));

        _fightWindowView.AddButtonCrime.onClick.AddListener(() => voidShake(_fightWindowView.AddButtonCrime));
        _fightWindowView.MinusButtonCrime.onClick.AddListener(() => voidShake(_fightWindowView.MinusButtonCrime));
        _fightWindowView.AddButtonMoney.onClick.AddListener(() => voidShake(_fightWindowView.AddButtonMoney));
        _fightWindowView.MinusButtonMoney.onClick.AddListener(() => voidShake(_fightWindowView.MinusButtonMoney));
        _fightWindowView.AddButtonHealth.onClick.AddListener(() => voidShake(_fightWindowView.AddButtonHealth));
        _fightWindowView.MinusButtonHealth.onClick.AddListener(() => voidShake(_fightWindowView.MinusButtonHealth));
        _fightWindowView.AddButtonPower.onClick.AddListener(() => voidShake(_fightWindowView.AddButtonPower));
        _fightWindowView.MinusButtonPower.onClick.AddListener(() => voidShake(_fightWindowView.MinusButtonPower));
        _fightWindowView.ButtonPass.onClick.AddListener(() => voidShake(_fightWindowView.ButtonPass));
        _fightWindowView.ButtonFight.onClick.AddListener(() => voidShake(_fightWindowView.ButtonFight));

        _fightWindowView.ButtonPass.onClick.AddListener(Pass);
        _fightWindowView.ButtonFight.onClick.AddListener(Fight);
        _fightWindowView.ButtonLeaveFight.onClick.AddListener(CloseWindow);
    }

    protected override void OnDispose()
    {
        _fightWindowView.AddButtonMoney.onClick.RemoveAllListeners();
        _fightWindowView.MinusButtonMoney.onClick.RemoveAllListeners();

        _fightWindowView.AddButtonHealth.onClick.RemoveAllListeners();
        _fightWindowView.MinusButtonHealth.onClick.RemoveAllListeners();

        _fightWindowView.AddButtonPower.onClick.RemoveAllListeners();
        _fightWindowView.MinusButtonPower.onClick.RemoveAllListeners();

        _fightWindowView.AddButtonCrime.onClick.RemoveAllListeners();
        _fightWindowView.MinusButtonCrime.onClick.RemoveAllListeners();

        _fightWindowView.ButtonPass.onClick.RemoveAllListeners();
        _fightWindowView.ButtonFight.onClick.RemoveAllListeners();
        _fightWindowView.ButtonLeaveFight.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _power.Detach(_enemy);
        _health.Detach(_enemy);

        base.OnDispose();
    }

    private void CloseWindow()
    {
        _playerProfile.CurrentState.Value = Tools.GameState.Game;
    }

    private void Pass()
    {
        string result = "<color=#07FF00>Pass!!!</color>";
        Debug.Log(result);
        _fightWindowView.PopupView.ShowPopup(result);
    }
    private void Fight()
    {
        string result = _allCountPowerPlayer >= _enemy.Power ? "<color=#07FF00>Win!!!</color>" : "<color=#FF0000>Lose!!!</color>";
        Debug.Log(result);
        _fightWindowView.PopupView.ShowPopup(result);
    }

    private void voidShake(Button button)
    {
        button.transform.DOShakePosition(1, 5);
    }
    private void ChangeDataWindow(int countDataType, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _fightWindowView.CountMoneyText.text = $"Player Money: {countDataType}";
                _money.CountMoney = countDataType;
                break;
            case DataType.Power:
                _fightWindowView.CountPowerText.text = $"Player Power: {countDataType}";
                _power.CountPower = countDataType;
                break;
            case DataType.Health:
                _fightWindowView.CountHealthText.text = $"Player Health: {countDataType}";
                _health.CountHealth = countDataType;
                break;
            default:
                break;
        }

        _fightWindowView.CountPowerEnemyText.text = $"Enemy Power: {_enemy.Power}";
    }
    private void ChangeHealth(bool _isAddCount)
    {
        if (_isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer = _allCountHealthPlayer == 0 ? 0 : _allCountHealthPlayer - 1;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void ChangePower(bool _isAddCount)
    {
        if (_isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer = _allCountPowerPlayer == 0 ? 0 : _allCountPowerPlayer - 1;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeMoney(bool _isAddCount)
    {
        if (_isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer = _allCountMoneyPlayer == 0 ? 0 : _allCountMoneyPlayer - 1;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }

    private void ChangeCrime(bool _isAddCount)
    {
        if (_isAddCount)
            _countCrime++;
        else
            _countCrime = _countCrime == 0 ? 0 : _countCrime - 1;

        _fightWindowView.CountCrimeText.text = $"Player Crime: {_countCrime}";

        ChangePass(CheckPass());
    }

    private bool CheckPass()
    {
        if (_countCrime <= 2)
            return true;

        return false;
    }

    private void ChangePass(bool doActive)
    {
        if (_fightWindowView.ButtonPass.gameObject.active != doActive)
            _fightWindowView.ButtonPass.gameObject.SetActive(doActive);
    }
}