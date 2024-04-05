using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.UserShip
{
    public abstract class UserShipModel : MonoBehaviour
    {
        [SerializeField] protected string _shipName;
        [SerializeField] protected float _horizontalSpeed;
        [SerializeField] protected float _verticalSpeed;
        
        public string ShipName => _shipName;
        public float HorizontalSpeed => _horizontalSpeed;

        public float VerticalSpeed => _verticalSpeed;
    }
}