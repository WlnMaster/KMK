using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    public Animator anim;

    IEnumerator Start()
    {
        if (anim != null)
        {
            anim.Play("YourAnimationName"); // ให้เล่นอนิเมชันที่มีชื่อว่า "YourAnimationName" ใน Animator
            yield return new WaitForSeconds(4f); // รอเป็นเวลา 2 วินาที
            DisOut();
            SceneManager.LoadScene(1); // โหลดหน้าถัดไป
        }
        else
        {
            Debug.Log("Animator not assigned. Please assign the Animator component in the Inspector.");
        }
    }
    private void DisOut()
    {
        anim.SetTrigger("DisOut");
    }
}
