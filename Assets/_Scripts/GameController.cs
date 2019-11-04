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

    [Header("Audio Settings")]
    public Sound activeSoundClip;
    public AudioSource[] audioSource;


    // Start is called before the first frame update
    void Start()
    {
        SceneConfiguration();
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
            SceneManager.LoadScene("Restart");
        }
    }

    public void CollectedUpdate()
    {
        collectedText.text = "COLLECTED: " + collected + "/13";
    }

    private void SceneConfiguration()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                activeSoundClip = Sound.NONE;
                break;
            case "Main":
                activeSoundClip = Sound.NIGHTESCAPE;
                break;
            case "End":
                activeSoundClip = Sound.NONE;
                break;
            case "Restart":
                activeSoundClip = Sound.NONE;
                break;
        }

        if ((activeSoundClip != Sound.NONE) && (activeSoundClip != Sound.NUM))
        {
            AudioSource activeAudioSource = audioSource[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            //activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }
    }

    public void OnStartButtonClick()
    {
        
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");

    }


}
