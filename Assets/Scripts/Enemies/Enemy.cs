using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Setup Settings")]
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask;
    public LayerMask playerMask;

    [Header("Health Settings")]
    public float health;

    [Header("Patrolling Settings")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Attacking Settings")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firepoint;
    public AudioSource gunAudioSource;
   [SerializeField] AudioSource audioSource;

    [Header("States Settings")]
    public float sightRange;
    public float attackRange;
    bool playerInSightRange;
    bool playerInAttackRange;

    private void Awake()
    {
        // Finds the player's game object and gets its transform
        player = GameObject.Find("Player").transform;

        // Gets the enemy's NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Gets the enemy's Audio Source
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        /* If the player is not in the sight range and not in the attack range 
           the enemy will return to their patrol */
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        /* If the player is in the sight range and not in the attack range 
           the enemy will chase the player */
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        /* If the player is not in the sight range and is in the attack range 
           the enemy will attack the player */
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walk point reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // 
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        // Calls the function set destination as the player position
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            gunAudioSource.Play();
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        // Takes away health 
        health -= damage;
        audioSource.Play();

        // If the enemy's health is 0 than invoke the destory enemy function
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        // Give the player points for destroying the enemy
        ScoreManager.instance.score += 100;
        // Removes the game object from the game
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Draws a wire sphere to visualise the attack range and sight range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
