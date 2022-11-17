using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swerve : MonoBehaviour
{
    SwerveSystem swerveSystem;
    public GameObject ball;
    public Animator playerAnim;
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
            ball.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }
        else
        {
            ball.transform.DOScale(new Vector3(1, 1, 1), 1);
        }
    }
}
