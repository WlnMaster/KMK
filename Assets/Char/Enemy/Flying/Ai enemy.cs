using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // กำหนด waypoints สำหรับศัตรู
    public float moveSpeed = 2.0f; // ความเร็วการเคลื่อนที่ของศัตรู
    private int currentWaypoint = 0;
    private bool movingForward = true;

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 targetPosition = waypoints[currentWaypoint].position;
        Vector3 moveDirection = targetPosition - transform.position;

        if (moveDirection.magnitude < 0.1f)
        {
            if (movingForward)
            {
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = waypoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypoint--;
                if (currentWaypoint < 0)
                {
                    currentWaypoint = 0;
                    movingForward = true;
                }
            }
        }

        // เคลื่อนที่ศัตรู
        Vector3 moveVector = moveDirection.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);
        if (moveDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        }
    }
}
