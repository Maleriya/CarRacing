using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class TapTapInput : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);  
        }

        private void Move()
        {
            if (Input.touchCount <= 0)
                return;

            Vector3 direction = Vector3.zero;
            direction.z = Input.GetTouch(0).position.x - Screen.width / 2 > 0 ? 1 : -1;

            float speedMove = direction.sqrMagnitude / 20 * _speed;

            if (direction.z > 0)
                OnRightMove(speedMove);
            else
                OnLeftMove(speedMove);
        }
    }
}
