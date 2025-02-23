using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullMovement : MonoBehaviour
{
    [SerializeField] GameObject bull;
    [SerializeField] GameObject personOn, personOff;

    Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.hasRider == true) {
            Left();
            Right();
            Up();
            Down();
        }

    }

    void Left()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * -20);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(Vector3.back * -20);
        }
    }

    void Right()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.back * -20);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -20);
        }

    }

    void Up()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, .5f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            transform.position = defaultPos;
        }
        
    }


    void Down()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0f, -.5f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            transform.position = defaultPos;
        }

    }
}
