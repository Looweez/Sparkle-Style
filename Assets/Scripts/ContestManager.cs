using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestManager : MonoBehaviour
{
    public ClothingContest currentContest;
    public DressUpManager dressUpManager;
    public TextMeshProUGUI resultText;

    void Start()
    {
        OutfitData outfit = PlayerOutfitManager.instance.GetOutfit();
        dressUpManager.topSlot.sprite = outfit.top;
        dressUpManager.bottomSlot.sprite = outfit.bottom;
        dressUpManager.shoesSlot.sprite = outfit.shoes;

        // Run scoring
        int score = CalculateScore(outfit);

        // Show result
        if (score >= currentContest.scoreToWin)
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "You Lose";
        }

        resultText.gameObject.SetActive(true);
    }

    public int CalculateScore(OutfitData outfit)
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
    
    IEnumerator ShowResultThenCutscene()
    {
        resultText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Bedroom");
    }
}
