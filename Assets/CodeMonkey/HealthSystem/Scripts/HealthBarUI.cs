using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.HealthSystemCM {

    public class HealthBarUI : MonoBehaviour {

        [SerializeField] private GameObject getHealthSystemGameObject;
        [SerializeField] private Image image;

        private HealthSystem healthSystem;
        private Transform enemyTransform;
        private Transform mainCameraTransform;
        private Vector3 offset;

        private void Start() {
            if (HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem)) {
                SetHealthSystem(healthSystem);
            }

            mainCameraTransform = Camera.main.transform;

            // Assign the enemy transform reference
            enemyTransform = transform;

            // Calculate the offset between the health bar and the enemy
            offset = transform.position - enemyTransform.position;
        }

        public void SetHealthSystem(HealthSystem healthSystem) {
            if (this.healthSystem != null) {
                this.healthSystem.OnHealthChanged -= HealthSystem_OnHealthChanged;
            }
            this.healthSystem = healthSystem;

            UpdateHealthBar();

            healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }

        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e) {
            UpdateHealthBar();
        }

        private void UpdateHealthBar() {
            image.fillAmount = healthSystem.GetHealthNormalized();
        }

        private void LateUpdate() {
            // Position the health bar at the enemy's position with the offset
            transform.position = enemyTransform.position + offset;

            // Lock the health bar's rotation to the camera's rotation
            transform.rotation = mainCameraTransform.rotation;
        }

        private void OnDestroy() {
            if (healthSystem != null)
            {
                healthSystem.OnHealthChanged -= HealthSystem_OnHealthChanged;
            }
        }

    }

}



