using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    public float hpMax;
    public bool isDead;

    private Rigidbody rb;
    private float hp;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = hpMax;
    }

    public void GetHit(float damage)
    {
        hp -= damage;
        CheckStatus();
    }

    public void GetHitBack(Vector3 dir, float force, float damage)
    {
        Debug.Log("HitBack");
        rb.AddForce((dir + Vector3.up) * force);
        hp -= damage;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (hp <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        isDead = true;
        Debug.Log("you dead");
    }
}
