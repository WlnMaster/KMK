using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public FlyingEnemyScript[] enemyArray;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("P"))
        {
            foreach (FlyingEnemyScript enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("P"))
        {
            foreach (FlyingEnemyScript enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }

    void Start()
    {
        // เพิ่มโค้ดที่คุณต้องการให้เริ่มต้นในนี้
    }

    // Update is called once per frame
    void Update()
    {
        // เพิ่มโค้ดที่คุณต้องการให้อัปเดตในนี้
    }
}
