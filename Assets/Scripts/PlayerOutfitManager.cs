using UnityEngine;

public class PlayerOutfitManager : MonoBehaviour
{
    public static PlayerOutfitManager instance;

    private OutfitData currentOutfit = new OutfitData();
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("PlayerOutfitManager created: " + gameObject.name);
    }

    public void SaveOutfit(Sprite top, Sprite bottom, Sprite shoes, Sprite hair, Sprite socks, Sprite outerwear, Sprite fullbody)
    {
        currentOutfit.top = top;
        currentOutfit.bottom = bottom;
        currentOutfit.shoes = shoes;
        currentOutfit.hair = hair;
        currentOutfit.socks = socks;
        currentOutfit.outerwear = outerwear;
        currentOutfit.fullbody = fullbody;
        
        Debug.Log("Outfit saved! Top sprite: " + (top ? top.name : "None"));
    }

    public OutfitData GetOutfit()
    {
        return currentOutfit;
    }
}
