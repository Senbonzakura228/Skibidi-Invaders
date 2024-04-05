using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Script.UserShip.MovableModule
{
    public class UserSpaceShipMoveModule : MonoBehaviour
    {
        private UserShipView _userShipView;
        private Vector2 direction = new Vector2();
        private bool _isMove;
        private HorizontalMove _horizontalMove = HorizontalMove.Idle;
        private VerticalMove _verticalMove = VerticalMove.Idle;

        public void Initialize(UserShipView view)
        {
            _userShipView = view;
        }

        public void MoveLeft()
        {
            if (_horizontalMove == HorizontalMove.Left) return;
            _horizontalMove = _horizontalMove == HorizontalMove.Right ? HorizontalMove.LeftRight : HorizontalMove.Left;
            direction.x = -_userShipView.UserShipModel.HorizontalSpeed;
            StartMove();
        }

        public void StopMoveLeft()
        {
            if (_horizontalMove == HorizontalMove.Right) return;
            if (_horizontalMove == HorizontalMove.LeftRight)
            {
                MoveRight();
                return;
            }

            _horizontalMove = HorizontalMove.Idle;
            direction.x = 0;
        }

        public void MoveRight()
        {
            if (_horizontalMove == HorizontalMove.Right) return;
            _horizontalMove = _horizontalMove == HorizontalMove.Left ? HorizontalMove.LeftRight : HorizontalMove.Right;
            direction.x = _userShipView.UserShipModel.HorizontalSpeed;
            StartMove();
        }

        public void StopMoveRight()
        {
            if (_horizontalMove == HorizontalMove.Left) return;
            if (_horizontalMove == HorizontalMove.LeftRight)
            {
                MoveLeft();
                return;
            }

            _horizontalMove = HorizontalMove.Idle;
            direction.x = 0;
        }
        
        public void MoveUp()
        {
            if (_verticalMove == VerticalMove.Up) return;
            _verticalMove = _verticalMove == VerticalMove.Down ? VerticalMove.UpDown : VerticalMove.Up;
            direction.y = _userShipView.UserShipModel.VerticalSpeed;
            StartMove();
        }

        public void StopMoveUp()
        {
            if (_verticalMove == VerticalMove.Down) return;
            if (_verticalMove == VerticalMove.UpDown)
            {
                MoveDown();
                return;
            }

            _verticalMove = VerticalMove.Idle;
            direction.y = 0;
        }

        public void MoveDown()
        {
            if (_verticalMove == VerticalMove.Down) return;
            _verticalMove = _verticalMove == VerticalMove.Up ? VerticalMove.UpDown : VerticalMove.Down;
            direction.y = -_userShipView.UserShipModel.VerticalSpeed;
            StartMove();
        }

        public void StopMoveDown()
        {
            if (_verticalMove == VerticalMove.Up) return;
            if (_verticalMove == VerticalMove.UpDown)
            {
                MoveUp();
                return;
            }

            _verticalMove = VerticalMove.Idle;
            direction.y = 0;
        }

        private void StartMove()
        {
            if (_isMove) return;
            if (_horizontalMove == HorizontalMove.Idle && _verticalMove == VerticalMove.Idle)
            {
                _isMove = false;
                return;
            }

            _isMove = true;
            MainThreadDispatcher.StartUpdateMicroCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (_isMove)
            {
                transform.Translate(direction * Time.deltaTime);
                yield return null;
            }
        }
    }
}