using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscribeOnChange(Action<T> unSubscriptionAction);
    }
}
