using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHold : MonoBehaviour
{
    public static BodyHold instance;
    public Animator playerAnim;
    public bool hold;
    public GameObject holdObj;
    private void Awake()
    {
        instance = this;
    }
    private void OnMouseDrag()
    {
        holdObj = gameObject;
        LimitBodyPos();
        SwerveSystem.instance.SystemPlayer();
        AnimatorControl();
    }
    private void OnMouseUp()
    {
        playerAnim.SetBool("HoldLeft", false);
        playerAnim.SetBool("HoldRight", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && holdObj.layer == 6 && hold == false)
        {
            hold = true;
            playerAnim.SetTrigger("Crash");
            SwerveSystem.instance.moveFactorBall = 0;
        }
    }
    void LimitBodyPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        float posX = mousePos.x;
        float posY = mousePos.y;
        posX = Mathf.Clamp(posX, -8.25f, 8.25f);
        posY = Mathf.Clamp(posY, -1.4f, 2.4f);
        transform.position = new Vector2(posX, posY);
    }
    void AnimatorControl()
    {
        if (SwerveSystem.instance.moveFactorXPlayer > 0)
        {
            playerAnim.SetBool("HoldLeft", false);
            playerAnim.SetBool("HoldRight", true);
        }
        if (SwerveSystem.instance.moveFactorXPlayer < 0)
        {
            playerAnim.SetBool("HoldRight", false);
            playerAnim.SetBool("HoldLeft", true);
        }
    }
}
