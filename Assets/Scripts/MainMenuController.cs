using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //handling menu ui
    
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;
    
    void Start()
    {
        startGameButton.onClick.AddListener(OnStartButtonClicked);
        //startGameButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Bedroom");
    }
    
    /*private void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("quit the game");
    }*/
    
    
}
