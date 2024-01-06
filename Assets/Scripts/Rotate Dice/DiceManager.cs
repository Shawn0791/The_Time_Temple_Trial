using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameObject UI;
    public static DiceManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        UI.SetActive(true);
    }
}
