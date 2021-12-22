using System;

namespace Tools
{
    internal interface IReadOnlySubscritionAction
    {
        void SubscribeOnChange(Action subscribtionAction);
        void UnSubscribeOnChange(Action unSubscriptionAction);
    }
}
