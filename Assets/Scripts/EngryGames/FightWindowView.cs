using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class FightWindowView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _countMoneyText;

    [SerializeField]
    private TMP_Text _countHealthText;

    [SerializeField]
    private TMP_Text _countPowerText;

    [SerializeField]
    private TMP_Text _countCrimeText;

    [SerializeField]
    private TMP_Text _countPowerEnemyText;

    [SerializeField]
    private Button _addButtonMoney;

    [SerializeField]
    private Button _minusButtonMoney;

    [SerializeField]
    private Button _addButtonHealth;

    [SerializeField]
    private Button _minusButtonHealth;

    [SerializeField]
    private Button _addButtonPower;

    [SerializeField]
    private Button _minusButtonPower;

    [SerializeField]
    private Button _addButtonCrime;

    [SerializeField]
    private Button _buttonFight;

    [SerializeField]
    private Button _buttonPass;

    [SerializeField]
    private PopupView _popupView;

    [SerializeField]
    private Button _minusButtonCrime;

    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;

    private Money _money;
    private Power _power;
    private Health _health;

    private Enemy _enemy;

    private int _countCrime;

    private void Start()
    {
        _enemy = new Enemy("Enemy Flappy");

        _money = new Money();
        _money.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _health = new Health();
        _health.Attach(_enemy);

        _addButtonMoney.onClick.AddListener(() => ChangeMoney(true));
        _minusButtonMoney.onClick.AddListener(() => ChangeMoney(false));

        _addButtonHealth.onClick.AddListener(() => ChangeHealth(true));
        _minusButtonHealth.onClick.AddListener(() => ChangeHealth(false));

        _addButtonPower.onClick.AddListener(() => ChangePower(true));
        _minusButtonPower.onClick.AddListener(() => ChangePower(false));

        _addButtonCrime.onClick.AddListener(() => ChangeCrime(true));
        _minusButtonCrime.onClick.AddListener(() => ChangeCrime(false));

        _addButtonCrime.onClick.AddListener(() => voidShake(_addButtonCrime));
        _minusButtonCrime.onClick.AddListener(() => voidShake(_minusButtonCrime));
        _addButtonMoney.onClick.AddListener(() => voidShake(_addButtonMoney));
        _minusButtonMoney.onClick.AddListener(() => voidShake(_minusButtonMoney));
        _addButtonHealth.onClick.AddListener(() => voidShake(_addButtonHealth));
        _minusButtonHealth.onClick.AddListener(() => voidShake(_minusButtonHealth));
        _addButtonPower.onClick.AddListener(() => voidShake(_addButtonPower));
        _minusButtonPower.onClick.AddListener(() => voidShake(_minusButtonPower));
        _buttonPass.onClick.AddListener(() => voidShake(_buttonPass));
        _buttonFight.onClick.AddListener(() => voidShake(_buttonFight));

        _buttonPass.onClick.AddListener(Pass);
        _buttonFight.onClick.AddListener(Fight);
    }

    private void OnDisable()
    {
        _addButtonMoney.onClick.RemoveAllListeners();
        _minusButtonMoney.onClick.RemoveAllListeners();

        _addButtonHealth.onClick.RemoveAllListeners();
        _minusButtonHealth.onClick.RemoveAllListeners();

        _addButtonPower.onClick.RemoveAllListeners();
        _minusButtonPower.onClick.RemoveAllListeners();

        _addButtonCrime.onClick.RemoveAllListeners();
        _minusButtonCrime.onClick.RemoveAllListeners();

        _buttonPass.onClick.RemoveAllListeners();
        _buttonFight.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _power.Detach(_enemy);
        _health.Detach(_enemy);
    }
    private void Pass()
    {
        string result = "<color=#07FF00>Pass!!!</color>";
        Debug.Log(result);
        _popupView.ShowPopup(result);
    }
    private void Fight()
    {
        string result = _allCountPowerPlayer >= _enemy.Power ? "<color=#07FF00>Win!!!</color>" : "<color=#FF0000>Lose!!!</color>";
        Debug.Log(result);
        _popupView.ShowPopup(result);
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
                _countMoneyText.text = $"Player Money: {countDataType}";
                _money.CountMoney = countDataType;
                break;
            case DataType.Power:
                _countPowerText.text = $"Player Power: {countDataType}";
                _power.CountPower = countDataType;
                break;
            case DataType.Health:
                _countHealthText.text = $"Player Health: {countDataType}";
                _health.CountHealth = countDataType;
                break;
            default:
                break;
        }

        _countPowerEnemyText.text = $"Enemy Power: {_enemy.Power}";
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

        _countCrimeText.text = $"Player Crime: {_countCrime}";

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
        if (_buttonPass.gameObject.active != doActive)
            _buttonPass.gameObject.SetActive(doActive);
    }
}