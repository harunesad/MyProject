using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    private void OnMouseDown()
    {
        BodyHold.instance.hold = false;
    }
    private void OnMouseDrag()
    {
        if (!BodyHold.instance.hold)
        {
            BodyHold.instance.holdObj = gameObject;
            LimitObjectPos();
            SwerveSystem.instance.SystemBall();
        }
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
}
