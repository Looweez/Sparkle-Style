using UnityEngine;

public class ClothingButton : MonoBehaviour
{
    public DressUpManager manager;
    public string category; 
    public Sprite spriteToApply;

    public void OnClick()
    {
       manager.changeClothing(category, spriteToApply);
       Debug.Log("Clothing Button Clicked");
    }
}
