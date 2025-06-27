using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContestController : MonoBehaviour
{
    // contest ui and selection
    
    public ClothingContest contestToLoad;
    [SerializeField] private Button exitComputerButton;
    [SerializeField] private Button computerTutorialButton;

    public Dialogue computerTutorialDialogue;

    void Start()
    {
        exitComputerButton.onClick.AddListener(OnExitComputerClick);
        computerTutorialButton.onClick.AddListener(OnTutorialButtonClick);
    }

    public void OnClick()
    {
        ContestDataCarrier.instance.selectedContest = contestToLoad;
        SceneManager.LoadScene("Contest");
    }
    
    public void OnExitComputerClick()
    {
        SceneManager.LoadScene("Bedroom");
    }

    public void OnTutorialButtonClick()
    {
        computerTutorialButton.interactable = false;
        if (computerTutorialDialogue != null)
        {
            DialogueManager.instance.StartDialogue(computerTutorialDialogue);
        }
    }
            
}
