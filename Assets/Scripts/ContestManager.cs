using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestManager : MonoBehaviour
{
    [Header("Character Slots")]
    public SpriteRenderer topSlot;
    public SpriteRenderer bottomSlot;
    public SpriteRenderer shoesSlot;
    public SpriteRenderer hairSlot;
    public SpriteRenderer socksSlot;
    public SpriteRenderer fullbodySlot;
    public SpriteRenderer outerwearSlot;

    [Header("UI")]
    public TextMeshProUGUI resultText;
    public float displayDuration = 5f; // seconds before auto-return

    private void Start()
    {
        // 1. Load and apply the saved outfit
        var outfit = PlayerOutfitManager.instance.GetOutfit();
        topSlot.sprite    = outfit.top;
        bottomSlot.sprite = outfit.bottom;
        shoesSlot.sprite  = outfit.shoes;
        hairSlot.sprite = outfit.hair;
        socksSlot.sprite = outfit.socks;
        fullbodySlot.sprite = outfit.fullbody;
        outerwearSlot.sprite = outfit.outerwear;

        // 2. Calculate score
        int score = CalculateScore(outfit);
        ContestDataCarrier.instance.lastScore = score;

        // 3. Display win/lose
        var contest = ContestDataCarrier.instance.selectedContest;
        if (score >= contest.scoreToWin)
            resultText.text = "✨ You Win! ✨";
        else
            resultText.text = "💔 You Lose 💔";

        resultText.gameObject.SetActive(true);

        // 4. Auto-return after a delay
        StartCoroutine(AutoReturn());
    }

    private int CalculateScore(OutfitData outfit)
    {
        int score = 0;
        var required = ContestDataCarrier.instance.selectedContest.requiredGenre;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.top)    == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.bottom) == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.shoes)  == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.hair)  == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.socks)  == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.fullbody)  == required) score += 5;
        if (ClothingDatabase.instance.GetGenreForSprite(outfit.outerwear)  == required) score += 5;
        
        return score;
    }

    private IEnumerator AutoReturn()
    {
        yield return new WaitForSeconds(displayDuration);
        SceneManager.LoadScene("Bedroom");
    }

    // Optional: call this from a “Continue” button instead of auto-return
    public void OnContinueButton()
    {
        SceneManager.LoadScene("Bedroom");
    }
    
}
