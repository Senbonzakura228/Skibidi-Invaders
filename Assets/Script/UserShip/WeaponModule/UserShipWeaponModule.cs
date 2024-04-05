using System;
using System.Collections;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;


namespace Script.UserShip.WeaponModule
{
    public class UserShipWeaponModule : MonoBehaviour
    {
        [SerializeField] private Cartridge cartridge;
        [SerializeField] private Transform attackPoint;
        private Cartridge _specialCartridge;
        private int _specialCartridgeCount;
        private Coroutine _attackRoutine;

        private async void Start()
        {
            await Task.Delay(1200);
            _attackRoutine = StartCoroutine(BaseAttack());
        }

        public void AddSpecialCartridge(CartridgePoint cartridgePoint)
        {
            _specialCartridge = cartridgePoint.Cartridge;
            _specialCartridgeCount = cartridgePoint.Count;
        }

        public void SpecialAttack()
        {
            if (_specialCartridgeCount <= 0) return;
            Attack(_specialCartridge);
        }

        private IEnumerator BaseAttack()
        {
            for (;;)
            {
                Attack(cartridge);
                yield return new WaitForSeconds(cartridge.Cooldown);
            }
        }

        private void Attack(Cartridge _cartridge)
        {
            Instantiate(_cartridge, new Vector3(attackPoint.position.x, attackPoint.position.y), attackPoint.rotation);
        }

        private void OnDisable()
        {
            StopCoroutine(_attackRoutine);
        }
    }
}