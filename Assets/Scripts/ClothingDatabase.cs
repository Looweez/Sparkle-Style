using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ClothingData
{
    public Sprite sprite;
    public ClothingGenre genre;
    public string category; // "Top", etc.
}

public class ClothingDatabase : MonoBehaviour
{
    public static ClothingDatabase instance;
    public List<ClothingData> allClothes;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public ClothingGenre? GetGenreForSprite(Sprite sprite)
    {
        return allClothes.Find(c => c.sprite == sprite)?.genre;
    }
}
