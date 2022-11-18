using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectHold : MonoBehaviour
{
    public static ObjectHold instance;
    //public GameObject ball;
    Vector3 lastFrameFingerPositionBall;
    public float moveFactorBall;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        ScaleControl();
    }
    private void OnMouseDown()
    {
        BodyHold.instance.hold = false;
        lastFrameFingerPositionBall = Input.mousePosition;
    }
    private void OnMouseDrag()
    {
        if (!BodyHold.instance.hold)
        {
            BodyHold.instance.holdObj = gameObject;
            LimitObjectPos();

            lastFrameFingerPositionBall.z = transform.position.z;
            moveFactorBall = Vector3.Distance(Input.mousePosition, lastFrameFingerPositionBall);
            lastFrameFingerPositionBall = Input.mousePosition;
        }
    }
    private void OnMouseUp()
    {
        moveFactorBall = 0f;
    }
    void LimitObjectPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        float posX = mousePos.x;
        float posY = mousePos.y;

        posX = Mathf.Clamp(posX, -9.25f, 9.25f);
        posY = Mathf.Clamp(posY, -3, 3.75f);
        transform.position = new Vector2(posX, posY);
    }
    public void ScaleControl()
    {
        if (moveFactorBall > 0)
        {
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }
        else
        {
            transform.DOScale(new Vector3(1, 1, 1), 1);
        }
    }
}
