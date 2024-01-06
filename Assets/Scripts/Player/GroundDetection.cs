using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public LayerMask groundLayer;
    public RaycastHit hitInfo;
    public float detectionDis;
    public float rotateSpeed;
    public List<GameObject> cubes;
    public List<GameObject> cubes1;
    public List<GameObject> cubes2;

    public GameObject lastGroundObj;//need to be public
    private Vector3 targetNormal;
    public bool isGroup1;

    private void Start()
    {
        ResetCubeGroup();
    }

    void Update()
    {
        Detecting();
        Rotating();
    }
    private void Detecting()
    {
        bool isHit = Physics.Raycast(transform.position, -transform.up, out hitInfo, detectionDis, groundLayer);
        if (hitInfo.collider != null) 
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

        if (lastGroundObj == null && hitInfo.collider != null)
            lastGroundObj = hitInfo.transform.gameObject;
        else if (lastGroundObj != null) 
        {
            if (lastGroundObj != hitInfo.transform.gameObject)
            {
                //creat empty object and move in
                GameObject cubeParent = new GameObject("cubeParent");
                cubeParent.transform.position = hitInfo.point;
                for (int i = 0; i < cubes.Count; i++)
                {
                    cubes[i].transform.parent = cubeParent.transform;
                }
                //change the targetNormal
                targetNormal = hitInfo.normal;

                lastGroundObj = hitInfo.transform.gameObject;
            }
        }
    }

    private void Rotating()
    {
        //transform.up = targetNormal;
        // code in update that makes the player gravity goes towards the center
        //Vector3 gravity = (EartyCenter.position - PlayerCenter.position).nornmalized;
        //playerRB.AddForce(gravity * GravityForce);

        //Debug.Log("Angle: "+Vector3.Angle(transform.up, hitInfo.transform.up)+"\n"+"up: "+transform.up+" "+"hitObj.up: "+ hitInfo.transform.up);
        //if player's normal and current floor's normal have a angle
        if (Vector3.Angle(transform.up, hitInfo.transform.up) > 0.2f)
        {
            //rotate smoothly until no angle
            Transform cubeParent = cubes[0].transform.parent;
            Vector3 a = transform.up - targetNormal.normalized;
            //Debug.Log("vector3: " + a);
            if (a.z <= 0.1 && a.z >= -0.1) //if vector3.z==0
            {
                //that means need to rotate in the plane with X and Y
                cubeParent.transform.up = Vector3.MoveTowards(cubeParent.transform.up,
                    new Vector3(-targetNormal.x, targetNormal.y, targetNormal.z), rotateSpeed * Time.deltaTime);
            }
            else if (a.x <= 0.1 && a.x >= -0.1) //if vector3.x==0
            {
                //that means need to rotate in the plane with Y and Z
                cubeParent.transform.up = Vector3.MoveTowards(cubeParent.transform.up,
                    new Vector3(targetNormal.x, targetNormal.y, -targetNormal.z), rotateSpeed * Time.deltaTime);
            }
        }
        else if (cubes[0].transform.parent.tag != "Ground" 
            && Vector3.Angle(transform.up, hitInfo.transform.up) < 0.2f) 
        {
            GameObject cubeParent = cubes[0].transform.parent.gameObject;
            GameObject map = GameObject.FindGameObjectWithTag("Ground");
            //move them out and delete the old parents
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].transform.parent = map.transform;
            }
            Destroy(cubeParent);
        }
    }

    public void CheckTheMap()
    {
        GameObject map = hitInfo.collider.transform.parent.gameObject;
        Debug.Log("check");
        cubes.Clear();
        lastGroundObj = null;
        for (int i = 0; i < map.transform.childCount; i++)
        {
            cubes.Add(map.transform.GetChild(i).gameObject);
        }
        Debug.Log(map.name);
    }

    public void SwitchCubeGroup()
    {
        cubes.Clear();
        isGroup1 = !isGroup1;
        ResetCubeGroup();
    }

    private void ResetCubeGroup()
    {
        if (isGroup1)
        {
            //cubes = cubes1;
            for (int i = 0; i < cubes1.Count; i++)
            {
                cubes.Add(cubes1[i]);
            }
        }
        else
        {
            //cubes = cubes2;
            for (int i = 0; i < cubes1.Count; i++)
            {
                cubes.Add(cubes2[i]);
            }
        }
    }
}
