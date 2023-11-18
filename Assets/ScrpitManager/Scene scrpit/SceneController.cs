using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionsAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadTargetScene(sceneName)); // เรียกใช้ StartCoroutine โดยส่ง sceneName เข้าไป
    }

    IEnumerator LoadTargetScene(string sceneName) // เปลี่ยนชื่อเมธอดให้ไม่ซ้ำกัน
    {
        transitionsAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName); // ใช้ SceneManager.LoadScene แทน SceneManager.LoadSceneAsync
        transitionsAnim.SetTrigger("Start");
    }

    public void NextLevel()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel() // เปลี่ยนชื่อเมธอดให้ไม่ซ้ำกัน
    {
        transitionsAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // ใช้ SceneManager.LoadScene แทน SceneManager.LoadSceneAsync
        transitionsAnim.SetTrigger("Start");
    }
}
