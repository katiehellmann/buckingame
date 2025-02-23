using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Purpose: Controls the Note's behaviors, such as being able to be pressed and them they are destroyed
/// Author: Katie Hellmann, https://www.youtube.com/watch?v=cZzf1FQQFA0&list=PLLPYMaP0tgFKZj5VG82316B63eet0Pvsv
/// </summary>
public class Note : MonoBehaviour
{
    public bool canBePressed;
    [SerializeField] KeyCode keyToPress;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject goodEffect;
    [SerializeField] GameObject perfectEffect;
    [SerializeField] GameObject missEffect;

    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed) { 
                gameObject.SetActive(false);
                // GameManager.instance.NoteHit();
                if (Mathf.Abs(transform.position.y) > .25f)
                {
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    Debug.Log("normal hit");
                    hit = true;
                }
                else if (Mathf.Abs(transform.position.y) > .08f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("good hit");
                    hit = true;
                }
                else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("perfect hit");
                    hit = true;
                }
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
            if (gameObject.activeSelf)
            {
                canBePressed = false;
                Debug.Log("missed.");
                GameManager.instance.NoteMiss();
                Instantiate(missEffect, (transform.position), missEffect.transform.rotation);
                gameObject.SetActive(false);
            }
        }
    }
}
