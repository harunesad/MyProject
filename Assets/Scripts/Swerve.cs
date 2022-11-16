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
            Debug.Log("sdsa");
            ball.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1);
        }
        else
        {
            ball.transform.DOScale(new Vector3(1, 1, 1), 1);
        }
        //if (swerveSystem.moveFactorXPlayer > 0)
        //{
        //    playerAnim.SetTrigger("Left");
        //    //playerAnim.SetBool("Hold", false);
        //}
        //else if(swerveSystem.moveFactorXPlayer == 0)
        //{
        //    playerAnim.SetBool("Hold", true);
        //}

        //Debug.Log(swerveSystem.moveFactorXBall);
    }
}
