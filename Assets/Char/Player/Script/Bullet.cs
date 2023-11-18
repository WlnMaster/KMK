using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public float delayTime = 80f; // เวลาล่าช้า
    private bool canShoot = true;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
    
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (canShoot)
        {       
            if (hitInfo.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = hitInfo.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            if (!hitInfo.gameObject.CompareTag("P"))
            {
                canShoot = false;
                StartCoroutine(DelayedDestroy());
            }
           
            {
              Debug.Log(hitInfo.name);
              Destroy(gameObject);
             }
        }

    }
}
