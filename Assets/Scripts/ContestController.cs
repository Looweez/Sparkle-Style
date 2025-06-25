using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestController : MonoBehaviour
{
    // contest ui and selection
    
    public ClothingContest contestToLoad;

    public void OnClick()
    {
        ContestDataCarrier.instance.selectedContest = contestToLoad;
        SceneManager.LoadScene("Contest");
    }
}
