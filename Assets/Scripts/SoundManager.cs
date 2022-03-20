using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip hittingHotdog, crushMen, speedUp;
    public AudioSource audioSource;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsOver == true)
        {
            audioSource.Stop();
        }
    }

    public void playSounds(string soundEffect)
    {
        switch (soundEffect)
        {
            case "CrushMen":
                audioSource.PlayOneShot(crushMen);
                break;
            case "Hotdog":
                audioSource.PlayOneShot(hittingHotdog);
                break;
            case "Speedup":
                audioSource.PlayOneShot(speedUp);
                break;
        }
    }
}
