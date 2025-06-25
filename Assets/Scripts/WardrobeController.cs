using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeController : MonoBehaviour
{
    //handling wardrobe ui
    public DressUpManager dressUpManager;
    
    [SerializeField] private Button exitWardrobeButton;
    [SerializeField] private Button removeAllButton;
    
    
    void Start()
    {
        exitWardrobeButton.onClick.AddListener(OnExitWardrobeButtonClicked);
        removeAllButton.onClick.AddListener(OnRemoveAllButtonClicked);
        
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
    
    
    
}
