using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreContestCutscene : MonoBehaviour
{
    public Dialogue girlyDialogue;
    public Dialogue gothDialogue;
    public Dialogue decoraDialogue;
    public Dialogue streetwearDialogue;
    public Dialogue casualDialogue;
    public Dialogue chicDialogue;
    public Dialogue preppyDialogue;

    private bool cutsceneStarted = false;
    void Start()
    {
        StartCoroutine(BeginCutsceneAfterDelay());
    }

    IEnumerator BeginCutsceneAfterDelay()
    {
        yield return new WaitForEndOfFrame(); // delay 1 frame to ensure everything is loaded

        var genre = ContestDataCarrier.instance.selectedContest.requiredGenre;
        Debug.Log("Genre detected: " + genre);

        Dialogue selectedDialogue = genre switch
        {
            ClothingGenre.Girly => girlyDialogue,
            ClothingGenre.Goth => gothDialogue,
            ClothingGenre.Decora => decoraDialogue,
            ClothingGenre.Streetwear => streetwearDialogue,
            ClothingGenre.Casual => casualDialogue,
            ClothingGenre.Chic => chicDialogue,
            ClothingGenre.Preppy => preppyDialogue,
            _ => null
        };

        if (selectedDialogue != null)
        {
            Debug.Log("Starting cutscene dialogue for genre: " + genre);
            DialogueManager.instance.StartDialogue(selectedDialogue);
            cutsceneStarted = true;
        }
        else
        {
            Debug.LogError("No dialogue found for selected genre.");
        }
    }

    void Update()
    {
        if (cutsceneStarted && !DialogueManager.instance.isDialogueActive)
        {
            SceneManager.LoadScene("Contest"); // Load runway/contest scoring scene
        }
    }
}
