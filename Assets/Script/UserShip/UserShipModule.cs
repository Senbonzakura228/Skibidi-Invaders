using System;
using UnityEngine;
using Zenject;

namespace Script.UserShip
{
    public class UserShipModule : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [SerializeField] private UserShipView _view;
        [SerializeField] private UserShipModel _model;
        private UserShipController _controller;

        private void Awake()
        {
            PrepareController();
            _view.Initialize(_model);
        }

        private void PrepareController()
        {
            UserShipController prefab;
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                prefab =
                    Resources.Load<UserShipController>(
                        "ShipController/" + "ShipMobile" + "Controller");
            }
            else
            {
                prefab =
                    Resources.Load<UserShipController>("ShipController/" + "ShipDesktop" +
                                                       "Controller");
            }

            _controller = _diContainer.InstantiatePrefab(prefab, transform).GetComponent<UserShipController>();
            _controller.Initialize(_view);
        }
    }
}