using UnityEngine;

[CreateAssetMenu(fileName = "ClothingItem", menuName = "Scriptable Objects/ClothingItem")]
public class ClothingItem : ScriptableObject
{
    public string category; // e.g. "Top", "Shoes", etc.
    public Sprite sprite;
    public ClothingGenre genre;
}


