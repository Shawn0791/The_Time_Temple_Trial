using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement : MonoBehaviour
{
    public float rotateCD = 10;
    public float rotateSpeed;
    public LayerMask rayMask;

    //private Rigidbody rb;
    private float rotateTimer;
    private bool canRotate;
    public bool rotating;//others script can know
    private float scale;
    private RaycastHit left1Info, left2Info, left3Info, left4Info, left5Info;
    private RaycastHit right1Info, right2Info, right3Info, right4Info, right5Info;
    private RaycastHit front1Info, front2Info, front3Info, front4Info, front5Info;
    private RaycastHit behind1Info, behind2Info, behind3Info, behind4Info, behind5Info;
    private Vector3 ZTop = new Vector3();
    private Vector3 ZUM = new Vector3();
    private Vector3 Center = new Vector3();
    private Vector3 ZLM = new Vector3();
    private Vector3 ZBottom = new Vector3();
    private Vector3 XLeft = new Vector3();
    private Vector3 XCL = new Vector3();
    private Vector3 XCR = new Vector3();
    private Vector3 XRight = new Vector3();
    private List<Vector3> points = new List<Vector3>();
    private List<Vector3> axes = new List<Vector3>();
    private int randomNum;
    private float rotateAngle;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        rotateTimer = Random.Range(0, rotateCD);
        scale = transform.localScale.x;

    }
    private void Update()
    {
        RotateTimer();
        RayOriPos();
        LeftRotateRays();
        RightRotateRays();
        FrontRotateRays();
        BehindRotateRays();
        Rotating();
    }

    private void RotateTimer()
    {
        if (rotateTimer > 0)
            rotateTimer -= Time.deltaTime;
        else if (rotateTimer <= 0 && !canRotate)
        {
            ChooseRotateDirection();
            canRotate = true;
        }
    }

    private void RayOriPos()
    {
        ZTop = new Vector3(transform.position.x, transform.position.y - 0.4f * scale, transform.position.z + 0.5f * scale);
        ZUM = new Vector3(transform.position.x, transform.position.y - 0.4f * scale, transform.position.z + 0.25f * scale);
        Center = new Vector3(transform.position.x, transform.position.y - 0.4f * scale, transform.position.z);
        ZLM = new Vector3(transform.position.x, transform.position.y - 0.4f * scale, transform.position.z - 0.25f * scale);
        ZBottom = new Vector3(transform.position.x, transform.position.y - 0.4f * scale, transform.position.z - 0.5f * scale);
        XLeft = new Vector3(transform.position.x - 0.5f * scale, transform.position.y - 0.4f * scale, transform.position.z);
        XCL = new Vector3(transform.position.x - 0.25f * scale, transform.position.y - 0.4f * scale, transform.position.z);
        XCR = new Vector3(transform.position.x + 0.25f * scale, transform.position.y - 0.4f * scale, transform.position.z);
        XRight = new Vector3(transform.position.x + 0.5f * scale, transform.position.y - 0.4f * scale, transform.position.z);
    }
    private void LeftRotateRays()
    {
        bool RayLeft1 = Physics.Raycast(ZTop, -Vector3.right, out left1Info, scale * 1.5f, rayMask);
        if (RayLeft1)
            Debug.DrawLine(ZTop, left1Info.point, Color.red);
        else
            Debug.DrawLine(ZTop, ZTop - Vector3.right * scale * 1.5f, Color.black);

        bool RayLeft2 = Physics.Raycast(ZUM, -Vector3.right, out left2Info, scale * 1.5f, rayMask);
        if (RayLeft2)
            Debug.DrawLine(ZUM, left2Info.point, Color.red);
        else
            Debug.DrawLine(ZUM, ZUM - Vector3.right * scale * 1.5f, Color.black);

        bool RayLeft3 = Physics.Raycast(Center, -Vector3.right, out left3Info, scale * 1.5f, rayMask);
        if (RayLeft3)
            Debug.DrawLine(Center, left3Info.point, Color.red);
        else
            Debug.DrawLine(Center, Center - Vector3.right * scale * 1.5f, Color.black);

        bool RayLeft4 = Physics.Raycast(ZLM, -Vector3.right, out left4Info, scale * 1.5f, rayMask);
        if (RayLeft4)
            Debug.DrawLine(ZLM, left4Info.point, Color.red);
        else
            Debug.DrawLine(ZLM, ZLM - Vector3.right * scale * 1.5f, Color.black);

        bool RayLeft5 = Physics.Raycast(ZBottom, -Vector3.right, out left5Info, scale * 1.5f, rayMask);
        if (RayLeft5)
            Debug.DrawLine(ZBottom, left5Info.point, Color.red);
        else
            Debug.DrawLine(ZBottom, ZBottom - Vector3.right * scale * 1.5f, Color.black);
    }
    private void RightRotateRays()
    {
        bool RayRight1 = Physics.Raycast(ZTop, Vector3.right, out right1Info, scale * 1.5f, rayMask);
        if (RayRight1)
            Debug.DrawLine(ZTop, right1Info.point, Color.red);
        else
            Debug.DrawLine(ZTop, ZTop + Vector3.right * scale * 1.5f, Color.blue);

        bool RayRight2 = Physics.Raycast(ZUM, Vector3.right, out right2Info, scale * 1.5f, rayMask);
        if (RayRight2)
            Debug.DrawLine(ZUM, right2Info.point, Color.red);
        else
            Debug.DrawLine(ZUM, ZUM + Vector3.right * scale * 1.5f, Color.blue);

        bool RayRight3 = Physics.Raycast(Center, Vector3.right, out right3Info, scale * 1.5f, rayMask);
        if (RayRight3)
            Debug.DrawLine(Center, right3Info.point, Color.red);
        else
            Debug.DrawLine(Center, Center + Vector3.right * scale * 1.5f, Color.blue);

        bool RayRight4 = Physics.Raycast(ZLM, Vector3.right, out right4Info, scale * 1.5f, rayMask);
        if (RayRight4)
            Debug.DrawLine(ZLM, right4Info.point, Color.red);
        else
            Debug.DrawLine(ZLM, ZLM + Vector3.right * scale * 1.5f, Color.blue);

        bool RayRight5 = Physics.Raycast(ZBottom, Vector3.right, out right5Info, scale * 1.5f, rayMask);
        if (RayRight5)
            Debug.DrawLine(ZBottom, right5Info.point, Color.red);
        else
            Debug.DrawLine(ZBottom, ZBottom + Vector3.right * scale * 1.5f, Color.blue);
    }
    private void FrontRotateRays()
    {
        bool RayFront1 = Physics.Raycast(XLeft, Vector3.forward, out front1Info, scale * 1.5f, rayMask);
        if (RayFront1)
            Debug.DrawLine(XLeft, front1Info.point, Color.red);
        else
            Debug.DrawLine(XLeft, XLeft + Vector3.forward * scale * 1.5f, Color.green);

        bool RayFront2 = Physics.Raycast(XCL, Vector3.forward, out front2Info, scale * 1.5f, rayMask);
        if (RayFront2)
            Debug.DrawLine(XCL, front2Info.point, Color.red);
        else
            Debug.DrawLine(XCL, XCL + Vector3.forward * scale * 1.5f, Color.green);

        bool RayFront3 = Physics.Raycast(Center, Vector3.forward, out front3Info, scale * 1.5f, rayMask);
        if (RayFront3)
            Debug.DrawLine(Center, front3Info.point, Color.red);
        else
            Debug.DrawLine(Center, Center + Vector3.forward * scale * 1.5f, Color.green);

        bool RayFront4 = Physics.Raycast(XCR, Vector3.forward, out front4Info, scale * 1.5f, rayMask);
        if (RayFront4)
            Debug.DrawLine(XCR, front4Info.point, Color.red);
        else
            Debug.DrawLine(XCR, XCR + Vector3.forward * scale * 1.5f, Color.green);

        bool RayFront5 = Physics.Raycast(XRight, Vector3.forward, out front5Info, scale * 1.5f, rayMask);
        if (RayFront5)
            Debug.DrawLine(XRight, front5Info.point, Color.red);
        else
            Debug.DrawLine(XRight, XRight + Vector3.forward * scale * 1.5f, Color.green);
    }
    private void BehindRotateRays()
    {
        bool RayBehind1 = Physics.Raycast(XLeft, -Vector3.forward, out behind1Info, scale * 1.5f, rayMask);
        if (RayBehind1)
            Debug.DrawLine(XLeft, behind1Info.point, Color.red);
        else
            Debug.DrawLine(XLeft, XLeft - Vector3.forward * scale * 1.5f, Color.yellow);

        bool RayBehind2 = Physics.Raycast(XCL, -Vector3.forward, out behind2Info, scale * 1.5f, rayMask);
        if (RayBehind2)
            Debug.DrawLine(XCL, behind2Info.point, Color.red);
        else
            Debug.DrawLine(XCL, XCL - Vector3.forward * scale * 1.5f, Color.yellow);

        bool RayBehind3 = Physics.Raycast(Center, -Vector3.forward, out behind3Info, scale * 1.5f, rayMask);
        if (RayBehind3)
            Debug.DrawLine(Center, behind3Info.point, Color.red);
        else
            Debug.DrawLine(Center, Center - Vector3.forward * scale * 1.5f, Color.yellow);

        bool RayBehind4 = Physics.Raycast(XCR, -Vector3.forward, out behind4Info, scale * 1.5f, rayMask);
        if (RayBehind4)
            Debug.DrawLine(XCR, behind4Info.point, Color.red);
        else
            Debug.DrawLine(XCR, XCR - Vector3.forward * scale * 1.5f, Color.yellow);

        bool RayBehind5 = Physics.Raycast(XRight, -Vector3.forward, out behind5Info, scale * 1.5f, rayMask);
        if (RayBehind5)
            Debug.DrawLine(XRight, behind5Info.point, Color.red);
        else
            Debug.DrawLine(XRight, XRight - Vector3.forward * scale * 1.5f, Color.yellow);
    }

    private void Rotating()
    {
        if (canRotate && rotating)
        {
            if (rotateAngle < 90)
            {
                transform.RotateAround(points[randomNum], axes[randomNum], -rotateSpeed * Time.deltaTime);
                rotateAngle += rotateSpeed * Time.deltaTime;
            }
            else
            {
                rotateAngle = 0;
                rotateTimer = rotateCD;
                points.Clear();
                axes.Clear();
                canRotate = false;
                rotating = false;
                //reset the rotation(clear rotated decimals)
            }
        }
    }

    private void ChooseRotateDirection()
    {
        float X = transform.position.x;
        float Y = transform.position.y;
        float Z = transform.position.z;
        int index = 0;
        if (left1Info.collider == null&&
            left2Info.collider == null &&
            left3Info.collider == null &&
            left4Info.collider == null &&
            left5Info.collider == null )
        {
            points.Add(new Vector3(X - scale / 2, Y - scale / 2, Z));
            axes.Add(-Vector3.forward);
            index++;
        }
        if (right1Info.collider == null&& 
            right2Info.collider == null && 
            right3Info.collider == null && 
            right4Info.collider == null && 
            right5Info.collider == null )
        {
            points.Add(new Vector3(X + scale / 2, Y - scale / 2, Z));
            axes.Add(Vector3.forward);
            index++;
        }
        if (front1Info.collider == null&&
            front2Info.collider == null &&
            front3Info.collider == null &&
            front4Info.collider == null &&
            front5Info.collider == null )
        {
            points.Add(new Vector3(X, Y - scale / 2, Z + scale / 2));
            axes.Add(-Vector3.right);
            index++;
        }
        if (behind1Info.collider == null&&
            behind2Info.collider == null &&
            behind3Info.collider == null &&
            behind4Info.collider == null &&
            behind5Info.collider == null )
        {
            points.Add(new Vector3(X, Y - scale / 2, Z - scale / 2));
            axes.Add(Vector3.right);
            index++;
        }

        if (index != 0)
        {
            randomNum = Random.Range(0, index);
            rotating = true;
        }
        else
        {
            rotateTimer = rotateCD;
            canRotate = false;
        }
    }
}
