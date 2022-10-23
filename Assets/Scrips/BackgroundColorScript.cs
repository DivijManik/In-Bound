using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackgroundColorScript : MonoBehaviour
{
    [SerializeField]
    Color[] RandColours;

    [SerializeField]
    TextMeshProUGUI bestScoreText;


    void Start()
    {
        transform.GetComponent<Camera>().backgroundColor  = RandColours[Random.Range(0, RandColours.Length)];
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        Time.timeScale = 1;
    }
}
