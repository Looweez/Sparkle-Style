using UnityEngine;

public class ClothingButton : MonoBehaviour
{
    public DressUpManager manager;
    public string category; 
    public Sprite spriteToApply;
    public GameObject highlight;
    public ClothingGenre genre;

    private void Start()
    {
        SetHighlight(false);
    }

    public void OnClick()
    {
        bool alreadyEquipped = manager.IsWearing(category, spriteToApply);

        if (alreadyEquipped)
        {
            manager.UnequipClothing(category);
            SetHighlight(false);
        }
        else
        {
            manager.EquipClothing(category, spriteToApply);
            SetHighlight(true);
            NotifyOthersToUnhighlight();
        }
    }

    public void SetHighlight(bool active)
    {
        if (highlight != null)
            highlight.SetActive(active);
    }

    void NotifyOthersToUnhighlight()
    {
        ClothingButton[] allButtons = FindObjectsOfType<ClothingButton>();
        foreach (ClothingButton button in allButtons)
        {
            if (button != this && button.category == this.category)
            {
                button.SetHighlight(false);
            }
        }
    }
    
}
