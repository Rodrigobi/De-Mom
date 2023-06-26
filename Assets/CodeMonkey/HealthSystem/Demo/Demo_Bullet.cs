using UnityEngine;
using CodeMonkey.HealthSystemCM;

namespace CodeMonkey.HealthSystemCM {

    public class Demo_Bullet : MonoBehaviour {

        public float destroyDelay = 5f;

        private void Start() {
            float bulletSpeed = 100f;
            GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

            // Destroy the bullet after the specified delay
            Destroy(gameObject, destroyDelay);
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if (collider2D.TryGetComponent(out Ghost ghost)) {
                ghost.Damage();
                Destroy(gameObject);
            }
        }

    }

}
