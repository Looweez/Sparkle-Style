using UnityEngine;
using UnityEngine.UI;

public class DressUpManager : MonoBehaviour
{
    public SpriteRenderer topSlot;
    public SpriteRenderer bottomSlot;
    public SpriteRenderer shoesSlot;
    public SpriteRenderer hairSlot;
    public SpriteRenderer socksSlot;
    public SpriteRenderer outerwearSlot;
    public SpriteRenderer fullbodySlot;

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
            case "Hair":
                hairSlot.sprite = newSprite;
                break;
            case "Socks":
                socksSlot.sprite = newSprite;
                break;
            case "Outerwear":
                outerwearSlot.sprite = newSprite;
                break;
            case "Fullbody":
                fullbodySlot.sprite = newSprite;
                break;
        }
    }
}
