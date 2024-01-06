using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeedMax;
    public float smoothTime;
    [Header("Jump")]
    public float jumpF;
    public float rayDis;
    public bool isGround;
    public LayerMask ground;
    public Transform rayLeftPos;
    public Transform rayRightPos;

    private RaycastHit hitInfo_L;
    private RaycastHit hitInfo_R;
    private Rigidbody rb;
    private Animator anim;
    private float velocityX;
    private float velocityZ;
    private Vector3 velocity;
    private float refX;
    private float refZ;
    private Transform PlayerBody;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        PlayerBody = transform.GetChild(0);
    }

    private void Update()
    {
        if (GetComponent<Player2Dush>().isDushing == false &&
            GetComponent<PlayerGetHit>().isDead == false)
        {
            //Jump();
            Movement();
        }

        Debuging();
    }
    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal2");
        float v = Input.GetAxisRaw("Vertical2");
        if (h != 0)
        {
            velocityX = Mathf.SmoothDamp(rb.velocity.x, moveSpeedMax * h * Mathf.Sqrt(1 - v * v / 2), ref velocity.x, smoothTime);
            anim.SetBool("isMoving", true);
        }

        if (v != 0)
        {
            velocityZ = Mathf.SmoothDamp(rb.velocity.z, moveSpeedMax * v * Mathf.Sqrt(1 - h * h / 2), ref velocity.z, smoothTime);
            anim.SetBool("isMoving", true);
        }

        if (h == 0 && v == 0)
        {
            anim.SetBool("isMoving", false);
            velocityX = 0;
            velocityZ = 0;
            float vx = Mathf.SmoothDamp(rb.velocity.x, 0, ref refX, smoothTime);
            float vz = Mathf.SmoothDamp(rb.velocity.z, 0, ref refZ, smoothTime);
            rb.velocity = new Vector3(vx, rb.velocity.y, vz);
        }
        else
        {
            //rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(velocityX, rb.velocity.y, velocityZ).normalized * moveSpeedMax, ref velocity, smoothTime, smoothSpeed);
            rb.velocity = new Vector3(velocityX, rb.velocity.y, velocityZ);

            FacingForward();
        }

    }

    private void FacingForward()
    {
        PlayerBody.forward = new Vector3(velocityX, 0, velocityZ).normalized;
    }

    private void Jump()
    {
        bool left = Physics.Raycast(rayLeftPos.position, -transform.up, out hitInfo_L, rayDis, ground);
        bool right = Physics.Raycast(rayRightPos.position, -transform.up, out hitInfo_R, rayDis, ground);

        if (hitInfo_L.collider == null && hitInfo_R.collider == null)
        {
            isGround = false;
        }
        else
        {
            isGround = true;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && isGround)
        {
            rb.AddForce(new Vector3(0, jumpF, 0));
        }
    }

    private void Debuging()
    {
        //Ground detection rays
        if (hitInfo_L.collider != null)
        {
            Debug.DrawLine(rayLeftPos.position, hitInfo_L.point, Color.red);
        }
        else
        {
            Debug.DrawLine(rayLeftPos.position, rayLeftPos.position - transform.up * rayDis, Color.green);
        }

        if (hitInfo_R.collider != null)
        {
            Debug.DrawLine(rayRightPos.position, hitInfo_R.point, Color.red);
        }
        else
        {
            Debug.DrawLine(rayRightPos.position, rayRightPos.position - transform.up * rayDis, Color.green);
        }

        //Debug.Log(rb.velocity.sqrMagnitude);
        //Debug.Log("x: "+velocityX+" z: "+velocityZ);
    }

}
