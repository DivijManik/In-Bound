using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

//const int poit = 3;
public class Player : MonoBehaviour
{

    public float speed = 1700f;
    [SerializeField]
    private HingeJoint2D hingeJoint2D;
    private JointMotor2D jointMotor;


    void Start () {

        jointMotor = hingeJoint2D.motor;
    }
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        }

        // MOBILE
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                jointMotor.motorSpeed = speed;
                hingeJoint2D.motor = jointMotor;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                jointMotor.motorSpeed = -speed;
                hingeJoint2D.motor = jointMotor;
            }
        }
    }

   



}
