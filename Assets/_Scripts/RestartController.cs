using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RestartController : MonoBehaviour
{
    public GameObject restartButton;

    void Start()
    {
        restartButton.GetComponentInChildren<Text>().text = "Restart";
    }

    public void OnRestartButtonClick()
    {
       
        SceneManager.LoadScene("Main");

    }
}
