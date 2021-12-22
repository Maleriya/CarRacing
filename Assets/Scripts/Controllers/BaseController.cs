using System;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extension;

namespace Game.Controllers
{
    internal abstract class BaseController : IDisposable
    {
        protected List<BaseController> _baseControllers;
        protected List<GameObject> _gameObjects;
        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            DisposeControllers();
            DisposeGameObjects();
            OnDispose();
            _isDisposed = true;
        }

        private void DisposeGameObjects()
        {
            if (_gameObjects == null)
                return;

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Destroy();
            }
            _gameObjects.Clear();
        }

        private void DisposeControllers()
        {
            if (_baseControllers == null)
                return;

            foreach (var baseController in _baseControllers)
            {
                baseController.Dispose();
            }
            _baseControllers.Clear();
        }

        protected void AddController(BaseController baseController)
        {
            _baseControllers ??= new List<BaseController>();
            _baseControllers.Add(baseController);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {

        }
    }
}
