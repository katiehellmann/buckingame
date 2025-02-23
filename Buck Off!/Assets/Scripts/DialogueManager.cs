using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=DOP_G5bsySA
    //script that will manage the buttons, text, and parse all the lines and text onto the screen for dialogue reading


    public static DialogueManager Instance;

    public TextMeshProUGUI dialogueText;
    public Button continueButton;
    public Button backButton;
    public Animator animator;


    //stack preserves and stores dialogue lines
    private Queue<string> dialogueLines;
    private Stack<string> previousLines; 

    private bool isDialogueActive = false;

    //speed at which letters are typed
    public float typingSpeed = 0.1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        //adds new lines to strings
        dialogueLines = new Queue<string>();
        previousLines = new Stack<string>();
    }

    //start dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;


        // \/ not needed
        //animator.Play("show");


        //clear stacks for new dialogue
        dialogueLines.Clear();
        previousLines.Clear();

        //queue dialogue lines
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(dialogueLine.line);
        }

        DisplayNextLine();

        //continue button, hide back button
        continueButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }


        //push the current line onto the stack
        string line = dialogueLines.Dequeue();
        previousLines.Push(line);

        //show next line
        StopAllCoroutines();
        StartCoroutine(TypeSentence(line));

        //hide if nowhere to go
        continueButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(previousLines.Count > 1);
    }

    IEnumerator TypeSentence(string line)
    {
        //letters to dialogue text
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            //wait for typing
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;


        // \/ not needed
        //animator.Play("hide");

        //hide after dialogue over
        continueButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }


    // \/ not needed

    //public void DisplayPreviousLine()
    //{
    //    if (previousLines.Count > 1) // Ensure there's a previous line to go back to
    //    {
    //        string previousLine = previousLines.Pop(); // Get the last line from the stack
    //        dialogueText.text = previousLine; // Display it
    //        backButton.gameObject.SetActive(previousLines.Count > 1); // Hide back button if no more previous lines
    //    }
    //}
}
