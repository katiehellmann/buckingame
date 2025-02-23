using System.Collections;
using UnityEngine;

public class AppearAfterDelay : MonoBehaviour
{
    public GameObject objectToAppear; // Assign the object in the Inspector
    public float delay = 2f; // Time in seconds before it appears

    void Start()
    {
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(false); // Hide the object initially
            StartCoroutine(ShowObjectAfterDelay());
        }
    }

    IEnumerator ShowObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        objectToAppear.SetActive(true); // Show the object after the delay
    }
}
