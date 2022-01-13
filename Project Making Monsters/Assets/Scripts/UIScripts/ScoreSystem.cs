using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int score;

    TextMeshProUGUI scoreText;

    public Slider multiplierSlider;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScore(int a_scoreIncrease)
    {
        score += a_scoreIncrease;
        scoreText.text = score.ToString();

        multiplierSlider.value = score / 100;
    }
}
