using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeController : MonoBehaviour
{
    //handling wardrobe ui
    
    [SerializeField] private Button exitWardrobeButton;
    
    void Start()
    {
        exitWardrobeButton.onClick.AddListener(OnExitWardrobeButtonClicked);
    }

    private void OnExitWardrobeButtonClicked()
    {
        SceneManager.LoadScene("Bedroom");
    }
    
    
}
