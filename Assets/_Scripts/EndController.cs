using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndController : MonoBehaviour
{
    public GameObject endButton;

    void Start()
    {
        endButton.GetComponentInChildren<Text>().text = "Play Again?";
    }

    public void OnEndButtonClick()
    {

        SceneManager.LoadScene("Main");

    }
}
