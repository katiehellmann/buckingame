using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
            transform.Rotate(Vector3.forward * -90);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(0,0,0);
        }
    }

    void Right()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.back * -90);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0, 0, 0);
        }

    }

    void Up()
    {
        transform.position = defaultPos;
    }


    void Down()
    {
        transform.position = defaultPos;

    }
}
