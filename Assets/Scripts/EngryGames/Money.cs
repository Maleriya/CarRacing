public class Money : DataPlayer
{
    private int _countMoney;

    public int CountMoney
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                base.Notifier(DataType.Money);
            }
        }
    }
}

