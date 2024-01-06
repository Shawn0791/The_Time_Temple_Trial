using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeekManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject ui1;
    public GameObject ui2;

    private float switchCD = 10;
    private float switchTimer;
    private bool canSwitch;

    void Start()
    {
        switchTimer = switchCD;
    }

    void Update()
    {
        SwitchPlayer();

        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }
        else
        {
            canSwitch = true;
        }
    }

    private void SwitchPlayer()
    {
        if (canSwitch)
        {
            player1.GetComponent<Player1Dush>().enabled = !player1.GetComponent<Player1Dush>().enabled;
            player2.GetComponent<Player2Dush>().enabled = !player2.GetComponent<Player2Dush>().enabled;
            ui1.SetActive(!player1.GetComponent<Player1Dush>().enabled);
            ui2.SetActive(!player2.GetComponent<Player2Dush>().enabled);
            switchTimer = switchCD;
            canSwitch = false;
        }
    }
}
