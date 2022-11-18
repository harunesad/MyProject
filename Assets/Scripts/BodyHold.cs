using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHold : MonoBehaviour
{
    public static BodyHold instance;
    Animator bodyAnim;
    public bool hold;
    public GameObject holdObj;

    float lastFrameFingerPositionXPlayer;
    float moveFactorXPlayer;
    private void Awake()
    {
        instance = this;
        bodyAnim = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        lastFrameFingerPositionXPlayer = Input.mousePosition.x;
    }
    private void OnMouseDrag()
    {
        holdObj = gameObject;
        LimitBodyPos();
        AnimatorControl();

        moveFactorXPlayer = Input.mousePosition.x - lastFrameFingerPositionXPlayer;
        lastFrameFingerPositionXPlayer = Input.mousePosition.x;
    }
    private void OnMouseUp()
    {
        bodyAnim.SetBool("HoldLeft", false);
        bodyAnim.SetBool("HoldRight", false);

        moveFactorXPlayer = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && holdObj.layer == 6 && hold == false)
        {
            hold = true;
            bodyAnim.SetTrigger("Crash");
            ObjectHold.instance.moveFactorBall = 0;
        }
    }
    void LimitBodyPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        float posX = mousePos.x;
        float posY = mousePos.y;

        posX = Mathf.Clamp(posX, -9, 9);
        posY = Mathf.Clamp(posY, -1.4f, 2.4f);
        transform.position = new Vector2(posX, posY);
    }
    void AnimatorControl()
    {
        if (moveFactorXPlayer > 0)
        {
            bodyAnim.SetBool("HoldLeft", false);
            bodyAnim.SetBool("HoldRight", true);
        }
        if (moveFactorXPlayer < 0)
        {
            bodyAnim.SetBool("HoldRight", false);
            bodyAnim.SetBool("HoldLeft", true);
        }
    }
}
