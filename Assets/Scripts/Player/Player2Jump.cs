using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Jump : MonoBehaviour
{
    [Header("Jump")]
    public float jumpF;
    public float rayDis;
    public float dropConst;
    public bool isGround;
    public LayerMask ground;
    public Transform rayLeftPos;
    public Transform rayRightPos;

    private RaycastHit hitInfo_L;
    private RaycastHit hitInfo_R;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        if (!isGround)
        {
            //通过下坠常数，空中速度快为0时，下坠常数a越大，即越快度过这个状态
            float a = dropConst * 5 - Mathf.Abs(rb.velocity.y);
            rb.velocity -= Vector3.up * a * Time.deltaTime;
        }
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
}
