using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Purpose: Manages User Input Buttons and their states
/// Author: Katie Hellmann, https://www.youtube.com/watch?v=cZzf1FQQFA0&list=PLLPYMaP0tgFKZj5VG82316B63eet0Pvsv
/// </summary>
public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    [SerializeField] KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //this changes the sprite based on the state of key to press
        if (Input.GetKeyDown(keyToPress))
        {
            _spriteRenderer.sprite = pressedSprite;
        }

        if (Input.GetKeyUp(keyToPress)) { 
            _spriteRenderer.sprite = defaultSprite;
        }

    }
}
