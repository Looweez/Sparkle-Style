using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedroomController : MonoBehaviour
{
    //handling button clicks from bedroom scene
    
    [SerializeField] private Button wardrobeButton;
    [SerializeField] private Button computerButton;
    [SerializeField] private Button craftingButton;
    
    void Start()
    {
        wardrobeButton.onClick.AddListener(OnWardrobeButtonClicked);
        computerButton.onClick.AddListener(OnComputerButtonClicked);
        craftingButton.onClick.AddListener(OnCraftingButtonClicked);
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
}
