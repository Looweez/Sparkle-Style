using UnityEngine;

public class ContestDataCarrier : MonoBehaviour
{
    public static ContestDataCarrier instance;

    public ClothingContest selectedContest;
    public int lastScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // survives scene loading
        }
        else
        {
            Destroy(gameObject); // only one allowed
        }
    }
}
