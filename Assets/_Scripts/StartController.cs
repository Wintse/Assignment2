using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject startButton;

    void Start()
    {
        startButton.GetComponentInChildren<Text>().text = "Start";
    }

    public void OnStartButtonClick()
    {

        SceneManager.LoadScene("Main");

    }
}
