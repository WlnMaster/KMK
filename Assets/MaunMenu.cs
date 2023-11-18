using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaunMenu : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        Screen.SetResolution(1080, 1920);
    }
    void Start()
    {
 
        if (anim != null)
        {
            Screen.SetResolution(1080, 1920);
            // ให้เล่นอนิเมชันที่ชื่อว่า "YourAnimationName" ที่อยู่ใน Animator component
            anim.Play("YourAnimationName");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
