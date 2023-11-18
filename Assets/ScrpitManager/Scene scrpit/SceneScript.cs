using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour

{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("P"))
        {
            if (goNextLevel)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
        }
    }
}
