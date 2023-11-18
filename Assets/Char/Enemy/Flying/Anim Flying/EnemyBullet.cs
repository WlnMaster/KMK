using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    private Transform player;
    private Vector2 target;
    private bool hasReachedTarget = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("P").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        if (!hasReachedTarget)
        {
            float distance = Vector2.Distance(transform.position, target);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (distance < 0.1f) // เมื่อระยะห่างน้อยกว่าค่าที่กำหนด
            {
                hasReachedTarget = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "P")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
