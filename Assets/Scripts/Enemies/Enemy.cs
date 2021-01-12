using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy instance { set; get; }

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
    public GameObject projectile;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firepoint;
    AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
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

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack
            //Rigidbody rb = Instantiate(projectile, firepoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            audioSource.Play();
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
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        ScoreManager.instance.score += 100;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
