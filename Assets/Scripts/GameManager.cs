using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int player1Point;
    private int player2Point;
    public Text player1Text;
    public Text player2Text;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddPoint(int a)
    {
        if (a == 1)
        {
            player1Point++;
            RefreshUI();
        }
        else
        {
            player2Point++;
            RefreshUI();
        }
    }

    private void RefreshUI()
    {
        player1Text.text = player1Point.ToString();
        player2Text.text = player2Point.ToString();
    }
}
