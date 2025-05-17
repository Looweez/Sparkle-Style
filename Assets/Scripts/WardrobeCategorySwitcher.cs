using UnityEngine;

public class WardrobeCategorySwitcher : MonoBehaviour
{
    // switching panels (the categories) in wardrobe
    
    public GameObject topsPanel;
    public GameObject bottomsPanel;
    public GameObject shoesPanel;

    public void ShowCategory(string category)
    {
        topsPanel.SetActive(category == "Tops");
        bottomsPanel.SetActive(category == "Bottoms");
        shoesPanel.SetActive(category == "Shoes");
    }
}
