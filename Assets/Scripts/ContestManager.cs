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
        if (PlayerOutfitManager.instance == null)
        {
            Debug.LogError("PlayerOutfitManager.instance is null!");
            return;
        }
        
        Debug.Log("PlayerOutfitManager.instance: " + PlayerOutfitManager.instance);

        var outfit = PlayerOutfitManager.instance.GetOutfit();

        if (outfit == null)
        {
            Debug.LogError("PlayerOutfitManager returned a null outfit!");
            return;
        }

        // Continue with applying the sprites and scoring
        topSlot.sprite    = outfit.top;
        bottomSlot.sprite = outfit.bottom;
        shoesSlot.sprite  = outfit.shoes;
        hairSlot.sprite   = outfit.hair;
        socksSlot.sprite  = outfit.socks;
        fullbodySlot.sprite = outfit.fullbody;
        outerwearSlot.sprite = outfit.outerwear;

        int score = CalculateScore(outfit);
        ContestDataCarrier.instance.lastScore = score;

        var contest = ContestDataCarrier.instance.selectedContest;
        resultText.text = (score >= contest.scoreToWin) ? " You Win! " : " You Lose ";
        resultText.gameObject.SetActive(true);

        StartCoroutine(AutoReturn());
    }
    
    private int CalculateScore(OutfitData outfit)
    {
        int score = 0;
        var required = ContestDataCarrier.instance.selectedContest.requiredGenre;
        Debug.Log("Scoring outfit for genre: " + required);
        
        void ScoreSlot(Sprite sprite, string label)
        {
            if (sprite == null)
            {
                Debug.Log($"{label} sprite is null – nothing worn.");
                return;
            }

            var genre = ClothingDatabase.instance.GetGenreForSprite(sprite);
            Debug.Log($"{label} genre: {genre}");

            if (genre == required)
            {
                score += 5;
                Debug.Log($"{label} matched! +5 points");
            }
            else
            {
                Debug.Log($"{label} didn't match.");
            }
        }
        
        ScoreSlot(outfit.top, "Top");
        ScoreSlot(outfit.bottom, "Bottom");
        ScoreSlot(outfit.shoes, "Shoes");
        ScoreSlot(outfit.hair, "Hair");
        ScoreSlot(outfit.socks, "Socks");
        ScoreSlot(outfit.fullbody, "Fullbody");
        ScoreSlot(outfit.outerwear, "Outerwear");

        
        Debug.Log("Final score: " + score);
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
