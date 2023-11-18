
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
    // properties / variables
    [SerializeField]
    Transform player;
    [SerializeField]
    float RayCastRange;
    [SerializeField]
    Transform CastPoint;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    bool isFacingLeft;
    Vector3 initialScale;
    //Start
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isFacingLeft = true;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer(RayCastRange))
        {
            //Enemy
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        var castDist = distance;
        if (isFacingLeft)
        {
            castDist = -distance;
        }
        Vector2 endPos = CastPoint.position + Vector3.right * castDist; //new vector2
        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("P"))
            {
                //lets The Enemy
                val = true;
            }
            else
            {
                val = false;

            }
            Debug.DrawLine(CastPoint.position, hit.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
        }
        return val;
    }
    //---------------------------------------------------------
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            if (isFacingLeft) // ตรวจสอบการหันทิศ
            {
                transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
                isFacingLeft = false;
            }
        }
        else
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            if (!isFacingLeft) // ตรวจสอบการหันทิศ
            {
                transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
                isFacingLeft = true;
            }
        }

    }
    //------------------------------------------------------
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }
}
