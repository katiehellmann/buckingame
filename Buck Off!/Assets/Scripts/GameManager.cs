using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller _beatScroller;

    public static GameManager instance;
    public int currentScore;
    [SerializeField] int scorePerNote = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //make the music play
        if (!startPlaying) { 
        if (Input.anyKeyDown)
            {
                startPlaying = true;
                _beatScroller.hasStarted = true;


                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        currentScore += scorePerNote;
    }

    public void NoteMiss()
    {

    }
}
