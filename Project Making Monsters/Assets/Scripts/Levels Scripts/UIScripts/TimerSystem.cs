using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    double remainingTime;
    int maxTime = 61;

    TextMeshProUGUI timerText;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Changes time time remaining in game
    /// </summary>
    private void FixedUpdate()
    {
        if (remainingTime <= 0)
        {
            timerText.text = "GAME OVER!";
        }
        else
        {
            remainingTime -= Time.deltaTime;
            timerText.text = ((int)remainingTime).ToString();
            Debug.Log(remainingTime);
            Debug.Log((float)remainingTime);
            Debug.Log((int)remainingTime);
        }
    }
}
