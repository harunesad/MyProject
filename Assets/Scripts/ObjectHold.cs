using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        if (gameObject.name == "Ball")
        {
            //Debug.Log("sdsa");
            SwerveSystem.instance.SystemBall();
        }
        if (gameObject.name == "Player")
        {
            SwerveSystem.instance.SystemPlayer();
            if (SwerveSystem.instance.moveFactorXPlayer >= 0)
            {
                playerAnim.SetTrigger("Right");
                playerAnim.SetBool("HoldRight", true);
                playerAnim.SetBool("HoldLeft", false);
            }
            if (SwerveSystem.instance.moveFactorXPlayer < 0)
            {
                playerAnim.SetTrigger("Left");
                playerAnim.SetBool("HoldLeft", true);
                playerAnim.SetBool("HoldRight", false);
                Debug.Log(SwerveSystem.instance.moveFactorXPlayer);
            }
        }
    }
    private void OnMouseUp()
    {
        if (gameObject.name == "Player")
        {
            playerAnim.SetBool("Hold", false);
        }
    }
}
