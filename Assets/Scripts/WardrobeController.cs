using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeController : MonoBehaviour
{
    //handling wardrobe ui
    public DressUpManager dressUpManager;
    
    [SerializeField] private Button exitWardrobeButton;
    [SerializeField] private Button removeAllButton;
    [SerializeField] private Button readyButton;
    [SerializeField] private Button wardrobeTutorialButton;
    
    [SerializeField] private SpriteRenderer topSlot;
    [SerializeField] private SpriteRenderer bottomSlot;
    [SerializeField] private SpriteRenderer shoesSlot;
    [SerializeField] private SpriteRenderer hairSlot;
    [SerializeField] private SpriteRenderer socksSlot;
    [SerializeField] private SpriteRenderer outerwearSlot;
    [SerializeField] private SpriteRenderer fullbodySlot;
    
    public Dialogue wardrobeTutorialDialogue;
    
    void Start()
    {
        exitWardrobeButton.onClick.AddListener(OnExitWardrobeButtonClicked);
        removeAllButton.onClick.AddListener(OnRemoveAllButtonClicked);
        readyButton.onClick.AddListener(OnReadyClicked);
        wardrobeTutorialButton.onClick.AddListener(OnTutorialButtonClicked);
    }

    private void OnExitWardrobeButtonClicked()
    {
        SceneManager.LoadScene("Bedroom");
    }
    
    public void RemoveAllHighlights()
    {
        ClothingButton[] allButtons = FindObjectsOfType<ClothingButton>();
        foreach (ClothingButton button in allButtons)
        {
            button.SetHighlight(false);
        }
    }
    
    public void OnRemoveAllButtonClicked()
    {
        dressUpManager.RemoveAllClothing();
        RemoveAllHighlights();
        dressUpManager.ApplyDefaultOutfit();
    }
    
    private void OnReadyClicked()
    {
        PlayerOutfitManager.instance.SaveOutfit(topSlot.sprite, bottomSlot.sprite, shoesSlot.sprite, hairSlot.sprite, socksSlot.sprite, outerwearSlot.sprite, fullbodySlot.sprite);
        SceneManager.LoadScene("Bedroom");
    }
    
    private void OnTutorialButtonClicked()
    {
        wardrobeTutorialButton.interactable = false;
        if (wardrobeTutorialButton != null)
        {
            DialogueManager.instance.StartDialogue(wardrobeTutorialDialogue);
        }
    }
    
}
