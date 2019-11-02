using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //[Header("Game Objects")]

    [Header("UI Settings")]
    public Text healthText;
    public Text collectedText;

    [SerializeField]
    public int health;
    public int collected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthUpdate();
        CollectedUpdate();
    }

    public void HealthUpdate()
    {
        healthText.text = "HEALTH: " + health;
        if (health == 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    public void CollectedUpdate()
    {
        collectedText.text = "COLLECTED: " + collected;
    }


}
