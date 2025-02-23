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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("eeerrrrrrmmmmmmm no sound.....help");
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            //random number from 1-10
            button.onClick.AddListener(() => PlayRandomSound(Random.Range(1, 11)));
        }
    }

    public void PlayRandomSound(int randomNumber)
    {
        if (audioSource != null && (sound1 != null || sound2 != null))
        {
            if (randomNumber <= 5)
                audioSource.PlayOneShot(sound1);
            else
                audioSource.PlayOneShot(sound2);
        }
    }
}