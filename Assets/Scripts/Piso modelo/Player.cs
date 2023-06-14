using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DialogManager.isActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }

        // Check if the agent is moving and set the "IsMoving" parameter accordingly
        bool isAgentMoving = agent.velocity.magnitude > 0.1f;
        animator.SetBool("IsMoving", isAgentMoving);

        // Flip the character horizontally based on movement direction
        if (agent.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (agent.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Restrict rotation to only the X-axis
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.y = 0f;
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
