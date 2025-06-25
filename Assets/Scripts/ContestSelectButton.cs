using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestSelectButton : MonoBehaviour
{
    public ClothingContest contestToLoad; // Drag in via Inspector

    public void OnClick()
    {
        ContestDataCarrier.instance.selectedContest = contestToLoad;
        SceneManager.LoadScene("ContestCutscene");
    }
}
