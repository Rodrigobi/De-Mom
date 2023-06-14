using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class Demo_DefenseGame : MonoBehaviour {

        [SerializeField] private Transform pfZombie;
        [SerializeField] private float minX = -100f;
        [SerializeField] private float maxX = 100f;
        [SerializeField] private float minY = -25f;
        [SerializeField] private float maxY = 25f;
        [SerializeField] private float spawnTimerMax = 2.5f;

        private float spawnTimer;

        private void Update() {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f) {
                spawnTimer += spawnTimerMax;
                SpawnZombie();
            }
        }

        private void SpawnZombie() {
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Instantiate(pfZombie, spawnPosition, Quaternion.identity);
        }

    }

}
