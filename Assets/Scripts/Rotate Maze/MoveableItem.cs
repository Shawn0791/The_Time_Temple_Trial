using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableItem : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float speed;

    private bool dir;

    private void Update()
    {
        if (dir)
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pos1.position) < 0.1f)
            dir = false;
        else if (Vector3.Distance(transform.position, pos2.position) < 0.1f)
            dir = true;
    }
}
