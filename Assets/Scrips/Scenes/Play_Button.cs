using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_Button : MonoBehaviour {

    [SerializeField]
    Sprite VibOffImg, VibOnImg;

    [SerializeField]
    Image VibImg;

    private void Start()
    {
        InitVib();
    }

    public void Play()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Scenes1");
            PlayerPrefs.DeleteKey("S");
        }
    }

    //public void Quit()
    //{
    //    Application.Quit();
    //}

    public void OnVibrationButtonClicked()
    {
        if (!PlayerPrefs.HasKey("UseVibration"))
        {
            PlayerPrefs.SetInt("UseVibration", 0);

        }
        else
        {
            int useVol = PlayerPrefs.GetInt("UseVibration");

            if (useVol == 0)
            {
                PlayerPrefs.SetInt("UseVibration", 1);
            }
            else
            {
                PlayerPrefs.SetInt("UseVibration", 0);
            }
        }

        InitVib();
    }

    private void InitVib()
    {
        if (PlayerPrefs.HasKey("UseVibration") && PlayerPrefs.GetInt("UseVibration") == 0)
        {
            VibImg.sprite = VibOffImg;
        }
        else
        {
            VibImg.sprite = VibOnImg;
        }
    }

    public void OnShareButtonClick()
    {
        new NativeShare().SetSubject("Try This Game!").SetText("Hi Try Hexa Rush game today, it's available for FREE! \n My high score is " + PlayerPrefs.GetInt("BestScore") + "!! \n Can you beat it?")
            .SetUrl("https://play.google.com/store/search?q=pub%3ABoltAim&c=apps").Share();


        //.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))

    }

    public void KofiLink()
    {
        Application.OpenURL("https://ko-fi.com/divijmanik");
    }
}
