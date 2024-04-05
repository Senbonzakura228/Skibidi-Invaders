using UnityEngine;

namespace Script.Enemy
{
    [CreateAssetMenu(fileName = "BaseSwarm", menuName = "Swarm/BaseSwarm", order = 1)]
    public class SwarmModel : ScriptableObject
    {
        [SerializeField] private int rowsCount;
        [SerializeField] private int columnsCount;
        [SerializeField] private SwarmShip swarmShip;
        [SerializeField] private float distanceBetweenHorizontal;
        [SerializeField] private float distanceBetweenVertical;
        [SerializeField] private Vector3 spawnPosition;

        public int RowsCount => rowsCount;

        public int ColumnsCount => columnsCount;

        public SwarmShip SwarmShip => swarmShip;

        public float DistanceBetweenHorizontal => distanceBetweenHorizontal;

        public float DistanceBetweenVertical => distanceBetweenVertical;

        public Vector3 SpawnPosition => spawnPosition;
    }
}