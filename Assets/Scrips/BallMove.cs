using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class BallMove : MonoBehaviour
{
    Transform Point;

    void Start()
    {
        transform.localScale = new Vector2(PlayerController.Instance.BallScale, PlayerController.Instance.BallScale);

        Point = PlayerController.Instance.transform.parent;
        transform.DOMove(Point.position, PlayerController.Instance.BallDuration).SetEase(Ease.Linear);
    }
}
