using UnityEngine;
using CodeMonkey.HealthSystemCM;


public class Ghost : MonoBehaviour, IGetHealthSystem 
{
    private HealthSystem healthSystem;
    public float moveSpeed = 10f;
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
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            // Get a new random target position
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-150f, 150f); // Increase the range to -50 and 50
        float y = Random.Range(-75f, 75f); // Increase the range to -25 and 25
        return new Vector3(x, y, 0f);
    }

    private bool IsMoving()
    {
        return Vector3.Distance(transform.position, targetPosition) > 0.1f;
    }

    public void Damage() {
        healthSystem.Damage(20);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e) {
        
        
        Destroy(gameObject);
    }

    public HealthSystem GetHealthSystem() {
        return healthSystem;
    }
}
