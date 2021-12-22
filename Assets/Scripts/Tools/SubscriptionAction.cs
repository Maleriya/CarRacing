using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    internal class SubscriptionAction : IReadOnlySubscritionAction
    {
        private Action _action;

        public void Invoke()
        {
            _action?.Invoke();
        }

        public void SubscribeOnChange(Action subscribtionAction)
        {
            _action += subscribtionAction;
        }

        public void UnSubscribeOnChange(Action unSubscriptionAction)
        {
            _action -= unSubscriptionAction;
        }
    }
}
