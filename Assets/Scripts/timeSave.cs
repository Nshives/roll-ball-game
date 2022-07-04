using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timeSave : MonoBehaviour
{
    public TextMeshProUGUI previousTimeText;
    public TextMeshProUGUI bestTimeText;


    //Update is called once per frame
    void Update()
    {
        if (mainManager.Instance != null)
        {
            //Debug.Log(timer.startTime);
            DisplayTime(previousTimeText, mainManager.Instance.previousTime);
            DisplayTime(bestTimeText, mainManager.Instance.bestTime);
        }
    }


    void DisplayTime(TextMeshProUGUI textboxToModify, float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textboxToModify.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
