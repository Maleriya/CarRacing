using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class CompInputView : BaseInputView
    {
        private bool _isButtonDown;

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
            _isButtonDown = false;
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            Debug.Log("0");
            Vector3 direction = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.D))
                _isButtonDown = true;

            if (Input.GetKeyUp(KeyCode.D))
                _isButtonDown = false;

            if (_isButtonDown)
                direction.z = 1;

            if (direction.sqrMagnitude > 1)
                direction.Normalize();

            OnRightMove(direction.sqrMagnitude / 20 * _speed);
        }
    }
}
