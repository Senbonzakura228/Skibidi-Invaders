using System.Collections.Generic;
using UnityEngine;

namespace Script.Enemy
{
    public class SwarmView : MonoBehaviour
    {
        [SerializeField] private SwarmModel swarmModel;
        private Dictionary<int, Dictionary<int, SwarmShip>> _ships = new Dictionary<int, Dictionary<int, SwarmShip>>();

        private void Start()
        {
            CreateShips();
        }

        private void CreateShips()
        {
            var swarmShipWidth = swarmModel.SwarmShip.ShipWidth + swarmModel.DistanceBetweenHorizontal;
            var startXPosition = swarmModel.SpawnPosition.x -
                swarmModel.ColumnsCount * swarmShipWidth / 2;
            Debug.Log(startXPosition);
            var currentSpawnPosition =
                new Vector2(
                    startXPosition,
                    swarmModel.SpawnPosition.y
                );

            for (int i = 0; i < swarmModel.RowsCount; i++)
            {
                currentSpawnPosition.x += swarmShipWidth;
                _ships.Add(i, new Dictionary<int, SwarmShip>());
                for (int j = 0; j < swarmModel.ColumnsCount; j++)
                {
                    var ship = Instantiate(swarmModel.SwarmShip, currentSpawnPosition,
                        swarmModel.SwarmShip.transform.rotation);
                    _ships[i].Add(j, ship);
                    currentSpawnPosition.x += swarmModel.DistanceBetweenHorizontal + swarmModel.SwarmShip.ShipWidth / 2;
                }

                currentSpawnPosition.x = startXPosition;
                currentSpawnPosition.y += swarmModel.DistanceBetweenVertical;
            }
        }
    }
}