using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            //GameManager.instance.AddPoint(1);
            LoadNextScene();
        }
        else if (other.CompareTag("Player2"))
        {
            //GameManager.instance.AddPoint(2);
            LoadNextScene();
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("Rotate Maze");
    }
}
