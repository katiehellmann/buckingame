using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSound : MonoBehaviour
{
    //set audio clips
    public AudioClip sound1;
    public AudioClip sound2;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Auto-adds AudioSource
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(PlayRandomSound);
        }
    }

    void PlayRandomSound()
    {
        int randomNumber = Random.Range(1, 11); // 1-10

        if (sound1 != null && sound2 != null)
        {
            audioSource.PlayOneShot(randomNumber <= 5 ? sound1 : sound2);
        }
    }
}
