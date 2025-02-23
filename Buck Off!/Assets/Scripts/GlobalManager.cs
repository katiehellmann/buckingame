using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager _instance;
    public static GlobalManager Instance { get { return _instance; } }
    public static int points { get; set; } //how much money the player has

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
