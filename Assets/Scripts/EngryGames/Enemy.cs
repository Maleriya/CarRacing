using UnityEngine;

public class Enemy : IEnemy
{
    private string _name;

    private int _moneyPlayer;
    private int _healthPlayer;
    private int _powerPlayer;

    private int _level => _powerPlayer + 1;
    private int _debuff;
    public Enemy(string name)
    {
        _name = name;
        _debuff = 3;
    }
    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                var dataHealth = dataPlayer as Health;
                _healthPlayer = dataHealth.CountHealth;
                break;
            case DataType.Power:
                var dataPower = dataPlayer as Power;
                _powerPlayer = dataPower.CountPower;
                break;
            case DataType.Money:
                var dataMoney = dataPlayer as Money;
                _moneyPlayer = dataMoney.CountMoney;
                break;
            default:
                break;
        }

        Debug.Log($"Enemy {_name}, change {dataType}");
    }

    public int Power
    {
        get
        {
            var localPower = _powerPlayer - _debuff;
            var localHelf = _healthPlayer - _debuff;
            var power = _level + (localPower >= 0 ? localPower : 0) - _moneyPlayer + (localHelf >= 0 ? localHelf : 0);
            return power;
        }
    }
}