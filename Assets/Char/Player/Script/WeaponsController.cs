using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsConl : MonoBehaviour
{
    public Transform firepoint;
    public GameObject ammoType;

    public float shotSpeed;
    public float shotCounter, fireRate;

    private Animator playerAnim; //Animation
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
            playerAnim.SetBool("Shoot", true);
        }
        else
        {
            shotCounter = 0;
            playerAnim.SetBool("Shoot", false);
        }

    }
    [SerializeField] private AudioSource bullet1SoundEffect;
    void Shoot()
    {
        GameObject shot = Instantiate(ammoType,firepoint.position,firepoint.rotation);
        bullet1SoundEffect.Play();
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(firepoint.right * shotSpeed, ForceMode2D.Impulse);
        Destroy(shot.gameObject,1f);
    }


}
