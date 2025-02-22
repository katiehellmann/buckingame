using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Purpose: Controls the Note's behaviors, such as being able to be pressed and them they are destroyed
/// Author: Katie Hellmann, https://www.youtube.com/watch?v=cZzf1FQQFA0&list=PLLPYMaP0tgFKZj5VG82316B63eet0Pvsv
/// </summary>
public class Note : MonoBehaviour
{
    public bool canBePressed;
    [SerializeField] KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed) { 
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMiss();
        }
    }
}
