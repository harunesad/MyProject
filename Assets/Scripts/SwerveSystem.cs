using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    public static SwerveSystem instance;
    public GameObject ball;
    public GameObject player;
    //float lastFrameFingerPositionX;
    Vector3 lastFrameFingerPositionBall;
    float lastFrameFingerPositionXPlayer;
    public float moveFactorBall;
    public float moveFactorXPlayer;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        //System();
    }
    public void SystemBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //lastFrameFingerPositionX = Input.mousePosition.x;
            lastFrameFingerPositionBall = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            //moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            //lastFrameFingerPositionX = Input.mousePosition.x;
            lastFrameFingerPositionBall.z = ball.transform.position.z;
            moveFactorBall = Vector3.Distance(Input.mousePosition, lastFrameFingerPositionBall);
            lastFrameFingerPositionBall = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorBall = 0f;
        }
    }
    public void SystemPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionXPlayer = Input.mousePosition.x;
            //lastFrameFingerPositionXPlayer = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorXPlayer = Input.mousePosition.x - lastFrameFingerPositionXPlayer;
            //lastFrameFingerPositionX = Input.mousePosition.x;
            //lastFrameFingerPositionXPlayer.z = player.transform.position.z;
            //moveFactorXPlayer = Vector3.Distance(Input.mousePosition, lastFrameFingerPositionXPlayer);
            lastFrameFingerPositionXPlayer = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorXPlayer = 0f;
        }
    }

}
