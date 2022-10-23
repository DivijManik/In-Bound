using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject squarePrefab;
    public GameObject Point;

    public GameObject triaglePrefab;

    public bool check = true, check1 = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (check && FindObjectOfType<Score>().currenScore >= 20 && FindObjectOfType<Score>().currenScore <= 27 )
        {
            StartCoroutine(Wail());
        }

        if(check1 && FindObjectOfType<Score>().currenScore >= 42)
        {
            StartCoroutine(Wail1());
        }

    }

    IEnumerator Wail()
    {
        yield return new WaitForSeconds(0.1f);

        if(check == true)
        {
            Instantiate(squarePrefab, Point.transform.position, Quaternion.identity);
            //FindObjectOfType<Score>().currenScore = 12;
            check = false;
        }

        //StartCoroutine(Wail());
    }

    IEnumerator Wail1()
    {
        yield return new WaitForSeconds(0.1f);

        if (check1 == true)
        {
            Instantiate(triaglePrefab, Point.transform.position, Quaternion.identity);
            //FindObjectOfType<Score>().currenScore = 12;
            check1 = false;
        }

        //StartCoroutine(Wail1());
    }

}
