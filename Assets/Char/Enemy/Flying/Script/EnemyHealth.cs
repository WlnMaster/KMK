using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float DelayHurt = 0.5f;
    public float DelayDeath = 1.5f;
    public GameObject deathEffect;
    private Animator anim; // เพิ่มการอ้างอิงไปยัง Animator
    private Rigidbody2D rb; // เพิ่มการอ้างอิงไปยัง Rigidbody2D

    private void Start()
    {
        anim = GetComponent<Animator>(); // ดึงคอมโพเนนต์ Animator ของวัตถุ
        rb = GetComponent<Rigidbody2D>(); // ดึงคอมโพเนนต์ Rigidbody2D ของวัตถุ
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            anim.SetBool("isHurt", true); // เล่นอนิเมชันที่ระแวดระวังหรือเจ็บ
            StartCoroutine(ResetHurtAnimation());
        }
    }

    IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(DelayHurt); // รอเวลาเป็นเวลาที่คุณต้องการก่อนที่จะเปลี่ยนค่า
        anim.SetBool("isHurt", false);
    }

    IEnumerator DieCoroutine()
    {    
        anim.SetTrigger("isDeath"); // เรียกใช้ Trigger "isDeath" เพื่อเล่นอนิเมชันตาย
        rb.simulated = false; // ปิดการใช้งานการจำลองของ Rigidbody ทำให้วัตถุไม่สามารถขยับได้
        yield return new WaitForSeconds(DelayDeath); // รอเวลาเพื่อให้เล่นอนิเมชันเสร็จสมบูรณ์

        Destroy(gameObject); // ทำลายวัตถุ
    }

    void Die()
    {
        StartCoroutine(DieCoroutine()); // เริ่ม Coroutine ที่จะทำลายวัตถุ
    }

    void Update()
    {
        if (anim.GetBool("isHurt"))
        {
            // เช็คว่าตอนนี้มีการเล่นอนิเมชันที่เกิดจากการเจ็บ
        }
    }
}
