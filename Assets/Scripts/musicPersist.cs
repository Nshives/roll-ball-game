using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPersist : MonoBehaviour

{
    public static musicPersist Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
