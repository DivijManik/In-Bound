using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int currenScore = 0;
    public TextMeshProUGUI curreScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestText;

    [SerializeField]
    TextMeshProUGUI bestScoreText1;

    public static Score instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        bestScoreText1.text = bestScoreText.text;
        curreScoreText.text = currenScore.ToString();
    }
	
    public void AddScore()
    {
        if (PlayerController.Instance.gameoverPanel.gameObject.activeInHierarchy)
            return;

        currenScore++;
        curreScoreText.text = currenScore.ToString();

        if(currenScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currenScore.ToString();
            bestScoreText1.text = bestScoreText.text;
            PlayerPrefs.SetInt("BestScore", currenScore);
        }
    }

    public void ChangeColor()
    {
        curreScoreText.color = UnityEngine.Color.white;
        bestScoreText.color = UnityEngine.Color.white;
        bestText.color = UnityEngine.Color.white;
    }
}
