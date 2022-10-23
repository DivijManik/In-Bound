using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float hueValue;

    int useVib = 1;

    public GameObject gameoverPanel;

    public GameObject ShootEffectPrefabSquare;

    public static PlayerController Instance;

    public float BallDuration = 5f;
    public float BallScale = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        hueValue = Random.Range(0, 1f);
        Camera.main.backgroundColor = UnityEngine.Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        hueValue += 0.08f;

        if (PlayerPrefs.HasKey("UseVibration"))
            useVib = PlayerPrefs.GetInt("UseVibration", 1);
    }

    public void BadCollision()
    {
        if (useVib == 1)
        {
            Vibration.VibrateNope();
        }

        //transform.GetComponent<LineRenderer>().sortingOrder = 0;
        gameoverPanel.SetActive(true);
        Time.timeScale = 1;

        Score.instance.ChangeColor();

        StartCoroutine(Wail());
    }

    public void PlayerScore()
    {
        //if (Score.instance.currenScore <= 3)
        //{
        //    GameObject shootEffectObj = Instantiate(ShootEffectPrefabHexagon, transform.position, Quaternion.identity);
        //    shootEffectObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = UnityEngine.Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        //    Destroy(shootEffectObj, 1.0f);
        //}
        //else if (Score.instance.currenScore >= 4 && FindObjectOfType<Score>().currenScore <= 10)
        //{

        //}
        //else if (Score.instance.currenScore >= 13)
        //{
        //    GameObject shootEffectObj = Instantiate(ShootEffectPrefabTriangle, transform.position, Quaternion.identity);
        //    shootEffectObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = UnityEngine.Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        //    Destroy(shootEffectObj, 1.0f);
        //}

        GameObject shootEffectObj = Instantiate(ShootEffectPrefabSquare, transform.position, Quaternion.identity);
        shootEffectObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = UnityEngine.Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        Destroy(shootEffectObj, 1.0f);
        

        
        ChangeBackgroundColor();

        Score.instance.AddScore();
        if (useVib == 1)
        {
            Vibration.VibratePop();
        }

        if (BallDuration > 3f)
            BallDuration -= 0.2f;
        else if (BallDuration != 3f)
            BallDuration = 3f;

        if (BallDuration == 3f && BallScale <= 1.7f)
        {
            BallScale += 0.1f;
        }
    }

    public void ChangeBackgroundColor()
    {
        Camera.main.backgroundColor = UnityEngine.Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        hueValue += 0.08f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    IEnumerator Wail()
    {
        yield return new WaitForSeconds(1.9f);

        Time.timeScale = 0;

        StartCoroutine(Wail());
    }

    public void stopCoRoutines()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("S");

        SceneManager.LoadScene("Scenes1");
    }
}
