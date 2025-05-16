using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    // handling crafting menu ui

    [SerializeField] private Button exitCraftingButton;

    void Start()
    {
        exitCraftingButton.onClick.AddListener(OnExitCraftingButtonClicked);
    }

    private void OnExitCraftingButtonClicked()
    {
        SceneManager.LoadScene("Bedroom");
    }
}
