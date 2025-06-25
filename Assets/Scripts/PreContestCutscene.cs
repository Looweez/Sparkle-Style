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

    void Start()
    {
        ClothingGenre genre = ContestDataCarrier.instance.selectedContest.requiredGenre;

        Dialogue chosenDialogue = genre switch
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

        DialogueManager.instance.StartDialogue(chosenDialogue);
    }

    void Update()
    {
        if (!DialogueManager.instance.isDialogueActive)
        {
            SceneManager.LoadScene("Contest");
        }
    }
}
