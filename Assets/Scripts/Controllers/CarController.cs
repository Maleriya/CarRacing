using Tools;
using UnityEngine;

namespace Game.Controllers
{
    internal class CarController : BaseController
    {
        private readonly ResourcePath _viewPath;
        private readonly CarView _carView;

        public CarController()
        {
            _viewPath = new ResourcePath("Prefabs/Car_Type_R");
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            Vector3 pos = new Vector3(0.0f, -3.0f);
            var objView = Object.Instantiate(ResourceLoader.Load<GameObject>(_viewPath), pos, Quaternion.identity);
            AddGameObject(objView);

            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    }
}

