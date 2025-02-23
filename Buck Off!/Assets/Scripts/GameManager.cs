using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip musicClip2;
    public bool startPlaying;
    public BullMovement bull;
    public bool hasRider;

    [SerializeField] MainMenu sceneManager;

    public static GameManager instance;
    public int currentScore;
    [SerializeField] int scorePerNote = 100;
    [SerializeField] int scorePerGoodNote = 125;
    [SerializeField] int scorePerPerfectNote = 150;
    public int missedNotes;



    public int currentMultiplier;
    public int multiplerTracker;
    public int[] multiplierThresholds;

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI multiplierTMP;
    [SerializeField] TextMeshProUGUI startTMP;
    [SerializeField] GameObject startBG;

    [SerializeField] GameObject musicLine;
    [SerializeField] GameObject musicLine2;

    [SerializeField] BeatScroller _beatScroller;


    [SerializeField] GameObject[] allNotes;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Delay(music.clip.length));

        hasRider = false;
        currentScore = 0;
        currentMultiplier = 1;
        instance = this;
        missedNotes = 0;

        allNotes = GameObject.FindGameObjectsWithTag("Note");
        StartCoroutine(Delay(music.clip.length));
    }

    // Update is called once per frame
    void Update()
    {
        //make the music play
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                hasRider = true;
                Destroy(startTMP);
                Destroy(startBG);
                _beatScroller.hasStarted = true;


                music.Play();

                // Wait for the audio to have finished
                //StartCoroutine(Delay(music.clip.length));


                // Assign the other clip and play it
                music.clip = musicClip2;
                music.Play();
            }
        }

        if (!music.isPlaying && hasRider)
        {
            //change the gaurds
            //hasRider = false;
            Delay(0);
            music.Play();
        }
        spawnMoreNotes();
        GlobalManager.points = currentScore;
        GameOver();
    }
    //a note helper method
    public void NoteHit()
    {
        multiplerTracker++;
        missedNotes = 0;
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
    //the following functions handle how accurate the user is at hitting notes
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
    //a function to handle missed notes
    public void NoteMiss()
    {
        missedNotes++;
        currentMultiplier = 1;
        multiplerTracker = 0;
        multiplierTMP.text = "Multiplier: " + currentMultiplier + "x";
    }

    //a function that repositions the notes endlessly
    public void spawnMoreNotes()
    {
        bool isPlaying = false;
        //Debug.Log(musicLine.gameObject.transform.position.x);
        foreach (GameObject note in allNotes)
        {
            if (note.activeSelf)
            {
                isPlaying = true;
            }
        }
        if (!isPlaying)
        {
            Debug.Log("respawned notes");
            //Vector3 temp = new Vector3(musicLine.gameObject.transform.position.x, 230f, 0.0f);
            //musicLine.transform.position += temp;
            musicLine2.SetActive(true);
            music.clip = musicClip2;
            _beatScroller.beatTempo = 176;
            //force them to gameover

            sceneManager.GameOverScene();

        }
    }

    public void GameOver()
    {
        if (missedNotes == 3)
        {
            sceneManager.GameOverScene();
        }
    }

    private IEnumerator Delay(float num)
    {
        if (num == 0)
        {
            num = 1.5f;
        }
        //1.5 second buffer
        yield return new WaitForSeconds(num);
    }
}
