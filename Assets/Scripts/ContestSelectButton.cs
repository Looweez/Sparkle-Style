using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestSelectButton : MonoBehaviour
{
    public ClothingContest contestToLoad;

    public void OnClick()
    {
        ContestDataCarrier.instance.selectedContest = contestToLoad;
        SceneManager.LoadScene("ContestCutscene"); // whatever your cutscene scene is named
    }
}
