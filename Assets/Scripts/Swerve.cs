using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swerve : MonoBehaviour
{
    SwerveSystem swerveSystem;
    public GameObject ball;
    private void Awake()
    {
        swerveSystem = GetComponent<SwerveSystem>();
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (swerveSystem.moveFactorBall > 0)
        {
            Debug.Log("sdsa");
            ball.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }
        else
        {
            ball.transform.DOScale(new Vector3(1, 1, 1), 1);
        }
        //Debug.Log(swerveSystem.moveFactorXBall);
    }
}
