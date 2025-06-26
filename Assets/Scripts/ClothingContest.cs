using UnityEngine;


[CreateAssetMenu(menuName = "Contest/ClothingContest")]
public class ClothingContest : ScriptableObject
{
    public string contestName;
    public ClothingGenre requiredGenre;
    public int scoreToWin = 20;
}
