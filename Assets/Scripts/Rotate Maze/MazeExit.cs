using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            //GameManager.instance.AddPoint(1);
            SceneManager.LoadScene("Rotate Dice");
        }
        else if (other.CompareTag("Player2"))
        {
            //GameManager.instance.AddPoint(2);
            SceneManager.LoadScene("Rotate Dice");
        }
    }
}
