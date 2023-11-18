using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScripts : MonoBehaviour
{
    public Text pointsTexi;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsTexi.text = score.ToString() + "POINTS";
    }
}
