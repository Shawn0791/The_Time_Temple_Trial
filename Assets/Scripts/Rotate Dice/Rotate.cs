using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float velocity;
    static float b = Mathf.Pow(2, 0.5f);
    bool isLook = true;
    bool goR = false;
    bool goL = false;
    int goRi = 0;
    int goLi = 0;

    Vector3 vector = new Vector3();

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(3.535534f, 2, 4.949748f);
        transform.Rotate(new Vector3(0, 45, 0));
    }
    void Update()
    {
        //Quaternion.AngleAxis(angle, axis) * (position - center);
        //transform.RotateAround(new Vector3(0, -0.5f, 0.5f), Vector3.right, 20 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) && isLook)
        {
            isLook = false;
            goR = true;
            goRi = 0;
            vector = transform.position;
            transform.RotateAround(new Vector3(vector.x + b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, -1), 6);
        }
        if (goR)
        {
            goRi += 6;
            if (goRi < 90)
            {
                Debug.Log(transform.eulerAngles.x);
                transform.RotateAround(new Vector3(vector.x + b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, -1), 6);
            }
            else
            {
                isLook = true;
                goR = false;
                goRi = 0;
            }
        }

        if (Input.GetKey(KeyCode.A) && isLook)
        {
            isLook = false;
            goL = true;
            vector = transform.position;
            transform.RotateAround(new Vector3(vector.x - b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, 1), 6);
        }
        if (goL)
        {
            goLi += 6;
            if (goLi < 90)
            {
                Debug.Log(goLi);
                transform.RotateAround(new Vector3(vector.x - b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, 1), 6);
            }
            else
            {
                isLook = true;
                goL = false;
                goLi = 0;
            }
        }
    }
}
