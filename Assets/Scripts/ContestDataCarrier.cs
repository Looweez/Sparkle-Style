using UnityEngine;

public class ContestDataCarrier : MonoBehaviour
{
    public int lastScore;

    public static ContestDataCarrier instance;

    public ClothingContest selectedContest;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // keeps it alive between scenes
    }
}
