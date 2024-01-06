using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Dush : MonoBehaviour
{
    [Header("Dush")]
    public float dushCD;
    public float dushTime;
    public float dushSpeed;
    public float dushHitForce;
    public bool isDushing;
    public BoxCollider dushColl;

    private Rigidbody rb;
    private float dushTimer;
    private float dushCDTimer;
    private Vector3 dushDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        DushReady();
        Dushing();
        DushTimer();
    }
    private void DushReady()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dushCDTimer <= 0)
        {
            dushTimer = dushTime;
            dushCDTimer = dushCD;
            //record the vector of velocity
            dushDir = rb.velocity.normalized;
            isDushing = true;
            dushColl.enabled = true;
        }
    }

    private void Dushing()
    {
        if (isDushing)
        {
            rb.velocity = dushDir * dushSpeed;
        }
    }

    private void DushTimer()
    {
        if (isDushing)
        {
            if (dushTimer > 0)
            {
                dushTimer -= Time.deltaTime;
            }
            else
            {
                isDushing = false;
                dushColl.enabled = false;
            }
        }

        if (dushCDTimer > 0)
        {
            dushCDTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerGetHit>().GetHitBack(dushDir, dushHitForce, 100);
        }
    }
}
