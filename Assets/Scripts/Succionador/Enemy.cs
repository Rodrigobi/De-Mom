using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class Enemy : MonoBehaviour
{
    private HealthSystem healthSystem;
    
    public float moveSpeed = 2f;

    private Vector3 targetPosition;
    private Animator animator;

    private void Awake() 
    {
        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
    }
    
    private void Start()
    {
        targetPosition = GetRandomPosition();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        animator.SetBool("isMoving", IsMoving());
    }

    private void Move()
    {
        // Calculate the direction to the target position
        Vector3 direction = targetPosition - transform.position;
        // Normalize the direction vector
        direction.Normalize();
        // Calculate the angle between the current facing direction and the target direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        // Create a rotation based on the calculated angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Rotate the enemy towards the target direction
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Get a new random target position
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);
        return new Vector3(x, y, 0f);
    }

    private bool IsMoving()
    {
        return Vector3.Distance(transform.position, targetPosition) > 0.1f;
    }

    public void Damage() 
    {
        healthSystem.Damage(60);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e) 
    {
        Destroy(gameObject);
    }
}
