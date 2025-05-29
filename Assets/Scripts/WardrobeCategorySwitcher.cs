using UnityEngine;

public class WardrobeCategorySwitcher : MonoBehaviour
{
    // switching panels (the categories) in wardrobe
    
    public GameObject topsPanel;
    public GameObject bottomsPanel;
    public GameObject shoesPanel;
    public GameObject socksPanel;
    public GameObject fullbodyPanel;
    public GameObject outerwearPanel;
    public GameObject hairPanel;
    public GameObject accessoriesPanel;

    public void ShowCategory(string category)
    {
        topsPanel.SetActive(category == "Tops");
        bottomsPanel.SetActive(category == "Bottoms");
        shoesPanel.SetActive(category == "Shoes");
        socksPanel.SetActive(category == "Socks");
        fullbodyPanel.SetActive(category == "Fullbody");
        outerwearPanel.SetActive(category == "Outerwear");
        hairPanel.SetActive(category == "Hair");
        accessoriesPanel.SetActive(category == "Accessories");
    }
}
