using UnityEngine;

namespace Script.Enemy
{
    public class SwarmShip: MonoBehaviour
    {
        [SerializeField] private float _shipWidth;
        [SerializeField] private float _shipHeight;

        public float ShipWidth => _shipWidth;
    }
}