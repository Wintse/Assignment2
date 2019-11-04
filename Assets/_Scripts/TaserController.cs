using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserController : MonoBehaviour
{
    public GameController gameController;

    [Header("Sounds")]
    private AudioSource _explosionSound;
   

    // Start is called before the first frame update
    void Start()
    {
        _explosionSound = gameController.audioSource[(int)Sound.EXPLOSION];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            _explosionSound.Play();
            Destroy(other.gameObject);
        }

       
    }
}
