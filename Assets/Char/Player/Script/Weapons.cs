using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public float delayTime2 = 0.7f; // เวลาล่าช้าสำหรับ shoot2
    private bool canShoot1 = true;
    private bool canShoot2 = true;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Update
    void Update()
    {
        if (!anim.GetBool("isDeath")) // ตรวจสอบว่า anim bool ของ death เป็น false หรือไม่
        {

            if (Input.GetButtonDown("Fire1"))
            {
                if (canShoot1)
                {
                    shoot1();
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                if (canShoot2)
                {
                    shoot2();
                    canShoot2 = false;
                    StartCoroutine(ResetShoot2());
                }
            }
        }
    }

    [SerializeField] private AudioSource bullet1SoundEffect;
    [SerializeField] private AudioSource bullet2SoundEffect;
    void shoot1()
    {
        Instantiate(BulletPrefab1, FirePoint.position, FirePoint.rotation);
        bullet1SoundEffect.Play();
    }

    void shoot2()
    {
        Instantiate(BulletPrefab2, FirePoint.position, FirePoint.rotation);
        bullet2SoundEffect.Play();
    }

    //delay 2
    IEnumerator ResetShoot2()
    {
        yield return new WaitForSeconds(delayTime2);
        canShoot2 = true;
    }

   // void OnTriggerEnter2D(Collider2D hitInfo)
   // {
      //  Debug.Log(hitInfo.name);
       // Destroy(gameObject);
   // }
}
