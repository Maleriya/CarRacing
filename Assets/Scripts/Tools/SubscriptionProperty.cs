using System;

namespace Tools
{
    public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private T _value;
        private Action<T> _onChange;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _onChange?.Invoke(_value);
            }
        }

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            _onChange += subscriptionAction;
        }

        public void UnSubscribeOnChange(Action<T> unSubscriptionAction)
        {
            _onChange -= unSubscriptionAction;
        }
    }
}
