using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
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
        }
    }
    private void OnMouseUp()
    {
        
    }
}
