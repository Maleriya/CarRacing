using Game.Controllers;
using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputGameController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        private BaseInputView _inputView;

        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _resourcePath = new ResourcePath("Prefabs/CompInputView");
            _inputView = LoadInputView();
            _inputView.Init(leftMove, rightMove, car.Speed);

            if (_inputView as TapTapInput)
            {
                var cursorTrail = new FollowTouchController();
                AddController(cursorTrail);
            }
        }

        private BaseInputView LoadInputView()
        {
            GameObject gameObject = Object.Instantiate(ResourceLoader.Load<GameObject>(_resourcePath));
            AddGameObject(gameObject);
            return gameObject.GetComponent<BaseInputView>();

        }
    }
}
