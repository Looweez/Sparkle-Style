using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContestController : MonoBehaviour
{
    // contest ui and selection
    
    public ClothingContest contestToLoad;
    [SerializeField] private Button exitComputerButton;

    void Start()
    {
        exitComputerButton.onClick.AddListener(OnExitComputerClick);
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
            
}
