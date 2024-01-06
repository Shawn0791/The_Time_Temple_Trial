using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMazeManager : MonoBehaviour
{
    public GameObject map;
    public float rotateSpeed;
    public Transform center;

    public float rotateCD=10;
    private float rotateTimer;
    private bool rotating;
    private float rotateAngle;
    void Start()
    {
        rotateTimer = rotateCD;
    }

    void Update()
    {
        if (rotateTimer > 0)
        {
            rotateTimer -= Time.deltaTime;
        }
        else
        {
            rotating = true;
            rotateTimer = rotateCD;
        }

        Rotating();
    }

    private void Rotating()
    {
        if (rotating)
        {
            if (rotateAngle < 90)
            {
                rotateAngle += rotateSpeed * Time.deltaTime;
                map.transform.RotateAround(center.position,-transform.forward, rotateSpeed * Time.deltaTime);
            }
            else
            {
                rotating = false;
                rotateAngle = 0;
            }

        }
    }
}
