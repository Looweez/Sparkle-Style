using UnityEngine;

public class PlayerOutfitManager : MonoBehaviour
{
    public static PlayerOutfitManager instance;

    public OutfitData currentOutfit = new OutfitData();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveOutfit(Sprite top, Sprite bottom, Sprite shoes, Sprite fullbody, Sprite outerwear, Sprite socks, Sprite hair)
    {
        currentOutfit.top = top;
        currentOutfit.bottom = bottom;
        currentOutfit.shoes = shoes;
        currentOutfit.fullbody = fullbody;
        currentOutfit.outerwear = outerwear;
        currentOutfit.socks = socks;
        currentOutfit.hair = hair;
    }

    public OutfitData GetOutfit()
    {
        return currentOutfit;
    }
}
