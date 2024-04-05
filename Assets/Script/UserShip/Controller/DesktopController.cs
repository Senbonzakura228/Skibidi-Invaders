using UniRx;
using UnityEngine;

namespace Script.UserShip
{
    public class DesktopController : UserShipController
    {
        protected override void SubscribeToActions()
        {
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A)).Subscribe(k => MoveLeft())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D)).Subscribe(k => MoveRight())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.A)).Subscribe(k => StopLeftMove())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.D)).Subscribe(k => StopRightMove())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.W)).Subscribe(k => MoveUp())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.S)).Subscribe(k => MoveDown())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.W)).Subscribe(k => StopUpMove())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyUp(KeyCode.S)).Subscribe(k => StopDownMove())
                .AddTo(_disposable);
            Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.Q)).Subscribe(k => SpecialAttack())
                .AddTo(_disposable);
        }
    }
}