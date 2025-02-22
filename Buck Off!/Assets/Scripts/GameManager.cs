using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller _beatScroller;

    public static GameManager instance;
    public int currentScore;
    [SerializeField] int scorePerNote = 100;
    [SerializeField] int scorePerGoodNote = 125;
    [SerializeField] int scorePerPerfectNote = 150;



    public int currentMultiplier;
    public int multiplerTracker;
    public int[] multiplierThresholds;

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI multiplierTMP;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentMultiplier = 1;
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
        multiplerTracker++;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplerTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplerTracker)
            {
                multiplerTracker = 0;
                currentMultiplier++;
            }
        }

        //currentScore += scorePerNote *currentMultiplier;
        scoreTMP.text = "Score: " + currentScore;
        multiplierTMP.text = "Multiplier: " + currentMultiplier + "x";

    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
    }

    public void NoteMiss()
    {
        currentMultiplier = 1;
        multiplerTracker = 0;
        multiplierTMP.text = "Multiplier: " + currentMultiplier + "x";

    }
}
