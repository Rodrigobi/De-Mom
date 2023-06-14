using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float coneAngle = 45f;
    public float coneDistance = 5f;
    public LayerMask enemyLayer;

    private Transform playerTransform;
    private Animator animator;
    private bool isSucking = false;
    private float damageDelay = 0.2f; // Adjust the delay value as needed
    private float nextDamageTime = 0f;

    private void Start()
    {
        playerTransform = transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            SetSuckingAnimation(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            SetSuckingAnimation(false);
        }

        if (isSucking)
        {
            PerformAttack();
        }
    }

    private void RotateToMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - playerTransform.position;
        float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void PerformAttack()
    {
        if (Time.time >= nextDamageTime)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerTransform.position, coneDistance, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                Vector2 directionToEnemy = enemy.transform.position - playerTransform.position;
                float angle = Vector2.Angle(playerTransform.up, directionToEnemy);

                if (angle < coneAngle * 0.5f)
                {
                    // Apply damage or perform any desired action here
                }
            }

            nextDamageTime = Time.time + damageDelay;
        }
    }

    private void SetSuckingAnimation(bool isSucking)
    {
        if (animator != null)
        {
            this.isSucking = isSucking;
            animator.SetBool("isSucking", isSucking);
        }
    }
}
