using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawRate = 1f;

    [SerializeField]
    Transform BallPrefab;

    //public GameObject hexagonPrefab;
    //public GameObject squarePrefab;
    //public GameObject trianglePrefal;

    public GameObject Hexagon;
    public GameObject Square;
    public GameObject Triangle;

    private float nextTimeToSpaw = 0f;

    int count = 1;

	void Update () {
        if(Time.time > nextTimeToSpaw && !PlayerController.Instance.gameoverPanel.activeInHierarchy) //&& Score.instance.currenScore <= 3)
        {
            transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));

            Transform t  = Instantiate(BallPrefab, transform.position + transform.right * 7f, Quaternion.identity);

            nextTimeToSpaw = Time.time + 1f / spawRate;

            count++;

            if (count % 10 == 0 && spawRate <= 1f)
                spawRate += 0.1f;

        }

        //else if(Time.time > nextTimeToSpaw && Score.instance.currenScore >= 4 && Score.instance.currenScore <=12)
        //{

        //    Hexagon.SetActive(false);
        //    Square.SetActive(true);

        //    StartCoroutine(Wail());

        //    nextTimeToSpaw = Time.time + 1f / spawRate;
        //}
        //else if(Time.time > nextTimeToSpaw && Score.instance.currenScore >= 20)
        //{

        //    Square.SetActive(false);
        //    Triangle.SetActive(true);

        //    StartCoroutine(Wail1());

        //    nextTimeToSpaw = Time.time + 1f / spawRate;
        //}
	}

    //IEnumerator Wail()
    //{
    //    yield return new WaitForSeconds(2f);

    //    Instantiate(squarePrefab, Vector3.zero, Quaternion.identity);
    //}

    //IEnumerator Wail1()
    //{
    //    yield return new WaitForSeconds(2f);

    //    Instantiate(trianglePrefal, Vector3.zero, Quaternion.identity);
    //}

}
