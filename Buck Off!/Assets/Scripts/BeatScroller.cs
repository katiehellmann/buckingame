using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Purpose: Makes the arrows scroll down the screen
/// Author:Katie Hellmann, https://www.youtube.com/watch?v=cZzf1FQQFA0&list=PLLPYMaP0tgFKZj5VG82316B63eet0Pvsv
/// </summary>
public class BeatScroller : MonoBehaviour
{
    [SerializeField] float beatTempo;
    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        //convert to tempo/sec
        beatTempo = beatTempo / 60.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        { 
            if (Input.anyKeyDown) {
                hasStarted = true;
             }
        }
        else
        {
            transform.position -= new Vector3(0.0f, beatTempo * Time.deltaTime, 0.0f);
        }
        
    }
}
