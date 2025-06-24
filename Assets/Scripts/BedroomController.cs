using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedroomController : MonoBehaviour
{
    //handling button clicks from bedroom scene
    
    [SerializeField] private Button wardrobeButton;
    [SerializeField] private Button computerButton;
    [SerializeField] private Button craftingButton;
    [SerializeField] private Button exitBedroomButton;
    [SerializeField] private Button tutorialButton;
    
    public Dialogue tutorialDialogue;
    
    void Start()
    {
        wardrobeButton.onClick.AddListener(OnWardrobeButtonClicked);
        computerButton.onClick.AddListener(OnComputerButtonClicked);
        craftingButton.onClick.AddListener(OnCraftingButtonClicked);
        exitBedroomButton.onClick.AddListener(OnExitBedroomButtonClicked);
        tutorialButton.onClick.AddListener(OnTutorialButtonClicked);
    }

    private void OnWardrobeButtonClicked()
    {
        SceneManager.LoadScene("Wardrobe");
    }
    
    private void OnComputerButtonClicked()
    {
        SceneManager.LoadScene("Computer");
    }
    
    private void OnCraftingButtonClicked()
    {
        SceneManager.LoadScene("Crafting");
    }
    
    private void OnExitBedroomButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTutorialButtonClicked()
    {
        tutorialButton.interactable = false;
        if (tutorialDialogue != null)
        {
            DialogueManager.instance.StartDialogue(tutorialDialogue);
        }
    }
}
