using System;
using GameState;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] spawnPrefabs;
        
        [SerializeField]
        private Vector3 spawnPos;

        [SerializeField]
        private float spawnDelay = 3;
       
        [SerializeField]
        private GameObject notRandomSpawnPrefab;

        public SpawnManager(Vector3 spawnPos)
        {
            this.spawnPos = spawnPos;
        }

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), 1, spawnDelay);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void SpawnObstacle()
        {
            if (!GameStateData.GameOver)
            {
                var index = Random.Range(0, spawnPrefabs.Length);
                var spawnPrefab = spawnPrefabs[index];
                if (notRandomSpawnPrefab != null)
                {
                    spawnPrefab = notRandomSpawnPrefab;
                }
                Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);
            }
        }
        
    }
}
