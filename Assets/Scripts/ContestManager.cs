using UnityEngine;

public class ContestManager : MonoBehaviour
{
    public ClothingContest currentContest;
    public DressUpManager dressUpManager;

    public int CalculateScore()
    {
        int score = 0;

        if (GetGenre(dressUpManager.topSlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.bottomSlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.shoesSlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.hairSlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.outerwearSlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.fullbodySlot) == currentContest.requiredGenre) score += 5;
        if (GetGenre(dressUpManager.socksSlot) == currentContest.requiredGenre) score += 5;
        
        return score;
    }

    private ClothingGenre? GetGenre(SpriteRenderer slot)
    {
        // You’ll need a way to map a sprite to its genre
        // e.g., a ClothingDatabase or Dictionary<Sprite, ClothingGenre>
        return ClothingDatabase.instance.GetGenreForSprite(slot.sprite);
    }
}
