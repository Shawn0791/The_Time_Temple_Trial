using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCrush : MonoBehaviour
{
    public BoxCollider boxColl;

    private void Update()
    {
        if (GetComponent<DiceMovement>().rotating == true && boxColl.enabled == false) 
        {
            boxColl.enabled = true;
        }
        else if(GetComponent<DiceMovement>().rotating == false&& boxColl.enabled == true)
        {
            boxColl.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerGetHit>().GetHit(100);
            DiceManager.instance.GameOver();
        }
    }
}
