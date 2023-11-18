using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Vector2 startPos;
    public int maxHealth = 100;
    public int Health;
    public Animator anim;
    [SerializeField] Animator transitionsAnim;
    private Rigidbody2D rb;
    private bool hasPlayedDeathAnimation = false;

    void Start()
    {
        Health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0 && !hasPlayedDeathAnimation)
        {
            Die();
        }
    }

    private void Die()
    {

        rb.simulated = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.velocity = Vector2.zero;
        anim.SetTrigger("isDeath");     
        hasPlayedDeathAnimation = true;       
        StartCoroutine(RespawnAfterDelay(1.5f)); // เริ่ม Coroutine สำหรับการ Respawn หลังจากการชนที่กำหนดเวลา*/
    }

    private IEnumerator RespawnAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        anim.SetTrigger("isAlive"); // เรียกใช้ isAlive เมื่อตัวละคร Respawn
        transform.position = startPos;
        rb.simulated = true;
        rb.constraints = RigidbodyConstraints2D.None; // ให้วัตถุกลับมาขยับได้เหมือนเดิม
        rb.velocity = Vector2.zero; // หยุดความเร็วของวัตถุ
        hasPlayedDeathAnimation = false;
    }
}
