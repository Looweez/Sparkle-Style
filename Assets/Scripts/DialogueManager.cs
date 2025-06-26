using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    
    public GameObject dialogueBoxUI;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;
    
    public bool isDialogueActive = false;

    public float typingSpeed;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // prevent duplicates
            return;
        }

        instance = this;
        lines = new Queue<DialogueLine>();
    }
    private void Start()
    {
        if (instance == null)
            instance = this;
        
        lines = new Queue<DialogueLine>();
        dialogueBoxUI.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("StartDialogue was called!");
        isDialogueActive = true;
        dialogueBoxUI.SetActive(true);
        //animator.Play("Show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }
    

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;
        
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        //animator.Play("Hide");
        dialogueBoxUI.SetActive(false);
    }
}
