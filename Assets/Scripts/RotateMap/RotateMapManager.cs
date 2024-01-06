using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMapManager : MonoBehaviour
{
    public Transform player1;
    public Transform start1;
    public Transform player2;
    public Transform start2;

    private float ChangeCD = 10;
    private float changeTimer;

    void Start()
    {
        changeTimer = ChangeCD;
    }

    void Update()
    {
        ResetPlayer();
        SwitchPlayer();
    }

    private void SwitchPlayer()
    {
        if (changeTimer > 0)
            changeTimer -= Time.deltaTime;
        else if (changeTimer <= 0 ) 
        {
            Vector3 a = player1.position;
            player1.position = player2.position;
            player2.position = a;
            changeTimer = ChangeCD;

            GameObject b = player1.GetComponent<GroundDetection>().lastGroundObj;
            player1.GetComponent<GroundDetection>().lastGroundObj = player2.GetComponent<GroundDetection>().lastGroundObj;
            player2.GetComponent<GroundDetection>().lastGroundObj = b;
            player1.GetComponent<GroundDetection>().SwitchCubeGroup();
            player2.GetComponent<GroundDetection>().SwitchCubeGroup();
        }
    }

    private void ResetPlayer()
    {
        if (player1.position.y < -30)
        {
            player1.position = player1.transform.GetComponent<GroundDetection>().lastGroundObj.transform.position + Vector3.up;
        }
        if(player2.position.y < -30)
        {
            player2.position = player2.transform.GetComponent<GroundDetection>().lastGroundObj.transform.position + Vector3.up;
        }
    }


}
