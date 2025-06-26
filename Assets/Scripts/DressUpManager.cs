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
    
    public Sprite defaultTop;
    public Sprite defaultBottom;
    public Sprite defaultHair;
    
    public void ApplyDefaultOutfit() // so girl is not naked lol
    {
        if (topSlot.sprite == null)
            topSlot.sprite = defaultTop;

        if (bottomSlot.sprite == null)
            bottomSlot.sprite = defaultBottom;

        if (hairSlot.sprite == null)
            hairSlot.sprite = defaultHair;
    }

    private void Start()
    {
        ApplyDefaultOutfit();
        
    }

    public bool IsWearing(string category, Sprite sprite)
    {
        return GetSlot(category)?.sprite == sprite;
    }

    public void EquipClothing(string category, Sprite newSprite)
    {
        SpriteRenderer slot = GetSlot(category);
        if (slot != null)
            slot.sprite = newSprite;
    }

    public void UnequipClothing(string category)
    {
        SpriteRenderer slot = GetSlot(category);
        if (slot != null)
            slot.sprite = null;
    }

    public Sprite GetEquippedSprite(string category)
    {
        return GetSlot(category)?.sprite;
    }


        private SpriteRenderer GetSlot(string category)
        {
            switch (category)
            {
                case "Top": return topSlot;
                case "Bottom": return bottomSlot;
                case "Shoes": return shoesSlot;
                case "Hair": return hairSlot;
                case "Socks": return socksSlot;
                case "Outerwear": return outerwearSlot;
                case "Fullbody": return fullbodySlot;
                default: return null;
            }
        }
        
        public void RemoveAllClothing()
        {
            topSlot.sprite = null;
            bottomSlot.sprite = null;
            shoesSlot.sprite = null;
            hairSlot.sprite = null;
            socksSlot.sprite = null;
            outerwearSlot.sprite = null;
            fullbodySlot.sprite = null;
        }
        
        

    
}
