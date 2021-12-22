using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class FollowTouchController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        private readonly FollowTouchView _followTouchView;

        public FollowTouchController()
        {
            _resourcePath = new ResourcePath("Prefabs/TouchTrail");
            _followTouchView = LoadView();
            _followTouchView.Init();
        }

        private FollowTouchView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.Load<GameObject>(_resourcePath));
            AddGameObject(objView);
            return objView.GetComponent<FollowTouchView>();
        }
    }
}
