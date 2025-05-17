using UnityEngine;
using UnityEngine.UI;

public class DressUpManager : MonoBehaviour
{
    public SpriteRenderer topSlot;
    public SpriteRenderer bottomSlot;
    public SpriteRenderer shoesSlot;

    public void changeClothing(string category, Sprite newSprite)
    {
        switch (category)
        {
            case "Top":
                topSlot.sprite = newSprite;
                break;
            case "Bottom":
                bottomSlot.sprite = newSprite;
                break;
            case "Shoes":
                shoesSlot.sprite = newSprite;
                break;
        }
    }
}
