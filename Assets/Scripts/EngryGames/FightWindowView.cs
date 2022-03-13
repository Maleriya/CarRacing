using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour
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

    [SerializeField]
    private Button _buttonLeaveFight;

    public TMP_Text CountMoneyText => _countMoneyText;
    public TMP_Text CountHealthText => _countHealthText;
    public TMP_Text CountPowerText  => _countPowerText;
    public TMP_Text CountCrimeText => _countCrimeText;
    public TMP_Text CountPowerEnemyText => _countPowerEnemyText;
    public Button AddButtonMoney => _addButtonMoney;
    public Button MinusButtonMoney => _minusButtonMoney;
    public Button AddButtonHealth => _addButtonHealth;
    public Button MinusButtonHealth => _minusButtonHealth;
    public Button AddButtonPower => _addButtonPower;
    public Button MinusButtonPower => _minusButtonPower;
    public Button AddButtonCrime => _addButtonCrime;
    public Button ButtonFight => _buttonFight;
    public Button ButtonPass => _buttonPass;
    public PopupView PopupView => _popupView;
    public Button MinusButtonCrime => _minusButtonCrime;
    public Button ButtonLeaveFight => _buttonLeaveFight;


    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _countCrime;

    private Money _money;
    private Power _power;
    private Health _health;

    private Enemy _enemy;
    
}