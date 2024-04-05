using System;
using UniRx;
using UnityEngine;

namespace Script.UserShip
{
    public abstract class UserShipController : MonoBehaviour
    {
        private UserShipView _view;
        protected readonly CompositeDisposable _disposable = new CompositeDisposable();

        public void Initialize(UserShipView view)
        {
            _view = view;
        }

        protected void Start()
        {
            SubscribeToActions();
        }

        protected virtual void SubscribeToActions()
        {
        }

        protected void MoveLeft()
        {
            _view.MovableModule.MoveLeft();
        }

        protected void MoveRight()
        {
            _view.MovableModule.MoveRight();
        }

        protected void StopLeftMove()
        {
            _view.MovableModule.StopMoveLeft();
        }

        protected void StopRightMove()
        {
            _view.MovableModule.StopMoveRight();
        }

        protected void MoveUp()
        {
            _view.MovableModule.MoveUp();
        }

        protected void MoveDown()
        {
            _view.MovableModule.MoveDown();
        }

        protected void StopUpMove()
        {
            _view.MovableModule.StopMoveUp();
        }

        protected void StopDownMove()
        {
            _view.MovableModule.StopMoveDown();
        }

        protected void SpecialAttack()
        {
            _view.WeaponModule.SpecialAttack();
        }

        public void AddSpecialCartridge(CartridgePoint cartridgePoint)
        {
            _view.WeaponModule.AddSpecialCartridge(cartridgePoint);
        }

        private void OnDestroy()
        {
            _disposable.Clear();
        }
    }
}