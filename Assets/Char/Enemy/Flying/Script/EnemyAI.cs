using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;

    private Vector3 originalPosition;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public float enemyChaseDistance = 5.0f;
    public int damage = 10; // ค่าความเสียหายที่การโจมตีทำให้

    public float returnSpeed = 0.5f; // เพิ่มความเร่งให้กับการกลับเริ่มต้น

    void Start()
    {
        timeBtwShots = Time.time;
        player = GameObject.FindGameObjectWithTag("P");
        originalPosition = transform.position;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < enemyChaseDistance)
        {
            chase = true;
        }
        else
        {
            chase = false;

            ReturnToStartingPoint();
        }

        if (timeBtwShots <= 0 && chase)
        {
            Shoot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (chase)
        {
            Chase();
        }
        else
        {
            ReturnToStartingPoint();
        }

        Flip();
    }
    

    void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void ReturnToStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime); // ใช้ความเร่งในการกลับ
    }

    void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}