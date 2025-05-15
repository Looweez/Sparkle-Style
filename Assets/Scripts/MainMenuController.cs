using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //handling menu
    
    [SerializeField] private Button startGameButton;
    
    void Start()
    {
        startGameButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Bedroom");
    }
}
