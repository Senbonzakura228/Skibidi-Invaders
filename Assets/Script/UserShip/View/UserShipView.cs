using System.Collections;
using Script.UserShip.MovableModule;
using Script.UserShip.WeaponModule;
using UniRx;
using UnityEngine;

namespace Script.UserShip
{
    public abstract class UserShipView: MonoBehaviour
    {
        [SerializeField] private UserShipWeaponModule weaponModule;
        [SerializeField] private UserSpaceShipMoveModule movableModule;
        protected CompositeDisposable _disposable = new CompositeDisposable();
        protected UserShipModel _userShipModel;

        public UserShipWeaponModule WeaponModule => weaponModule;
        public UserSpaceShipMoveModule MovableModule => movableModule;
        public UserShipModel UserShipModel => _userShipModel;

        public void Initialize(UserShipModel model)
        {
            _userShipModel = model;
            movableModule.Initialize(this);
        }

        public void TakeDamage()
        {
            
        }
    }
}