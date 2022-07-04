using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mainManager : MonoBehaviour
{
    public static mainManager Instance;

    public float previousTime = 0;
    public float bestTime = 0;
    


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateBestTime()
    {
        if (previousTime < bestTime)
        {
            bestTime = previousTime;
        }
        if (bestTime == 0)
        {
            bestTime = previousTime;
        }

    }

}
