using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ClothingDatabase : MonoBehaviour
{
    public static ClothingDatabase instance;
    public ClothingGenre genre;

    public List<ClothingItem> allClothingItems;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public ClothingGenre GetGenreForSprite(Sprite sprite)
    {
        foreach (var item in allClothingItems)
        {
            if (item == null)
            {
                Debug.LogWarning("Null clothing item in database!");
                continue;
            }

            if (item.sprite == null)
            {
                Debug.LogWarning("Clothing item has no sprite assigned: " + item.name);
                continue;
            }

            if (item.genre == null)
            {
                Debug.LogWarning("Clothing item has no genre assigned: " + item.name);
                continue;
            }

            if (item.sprite == sprite)
                return item.genre;
        }

        Debug.LogWarning("Sprite not found in clothing database!");
        return ClothingGenre.None;
    }
}
