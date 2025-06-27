using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContestManager : MonoBehaviour
{
    
    [Header("Sound Effects")]
    public AudioSource cheerAudioSource;
    public AudioSource shutterAudioSource;
    
    
    [Header("Character Slots")]
    public SpriteRenderer topSlot;
    public SpriteRenderer bottomSlot;
    public SpriteRenderer shoesSlot;
    public SpriteRenderer hairSlot;
    public SpriteRenderer socksSlot;
    public SpriteRenderer fullbodySlot;
    public SpriteRenderer outerwearSlot;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public float displayDuration = 5f;
    public float suspenseDelay = 2f;

    private int finalScore;
    

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
        
        topSlot.sprite    = outfit.top;
        bottomSlot.sprite = outfit.bottom;
        shoesSlot.sprite  = outfit.shoes;
        hairSlot.sprite   = outfit.hair;
        socksSlot.sprite  = outfit.socks;
        fullbodySlot.sprite = outfit.fullbody;
        outerwearSlot.sprite = outfit.outerwear;

        finalScore = CalculateScore(outfit);
        ContestDataCarrier.instance.lastScore = finalScore;
        
        StartCoroutine(ScoreRevealRoutine());
    }
    
    private IEnumerator ScoreRevealRoutine()
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Scoring...";
        yield return new WaitForSeconds(suspenseDelay);

        //fake counting animation
        int currentScore = 0;
        while (currentScore < finalScore)
        {
            currentScore++;
            scoreText.text = "Score: " + currentScore;
            yield return new WaitForSeconds(0.1f);
        }

        
        var contest = ContestDataCarrier.instance.selectedContest;
        if (finalScore >= contest.scoreToWin)
        {
            resultText.text = " You Win! ";
            cheerAudioSource.PlayDelayed(1.0f);
            shutterAudioSource.PlayDelayed(1.0f);
        }
        else
        {
            resultText.text = " You Lose ";
        }
        resultText.gameObject.SetActive(true);
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
    
    private int ScoreSlot(Sprite sprite, string label, ClothingGenre required)
    {
        if (sprite == null || ClothingDatabase.instance == null) return 0;
        var genre = ClothingDatabase.instance.GetGenreForSprite(sprite);
        Debug.Log(label + " genre: " + genre);
        return genre == required ? 5 : 0;
    }
    
    
    public void OnContinueButton()
    {
        SceneManager.LoadScene("Bedroom");
    }
    
}
