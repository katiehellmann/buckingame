using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GlobalManager.points;
        scoreText2.text = "Score: " + GlobalManager.points;

    }


}
