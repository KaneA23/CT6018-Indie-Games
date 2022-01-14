using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public float score;

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

    /// <summary>
    /// Increases player's score as they destroy more buildings
    /// </summary>
    /// <param name="a_scoreIncrease">Damage taken becomes score (+ bonus)</param>
    public void ChangeScore(float a_scoreIncrease)
    {
        score += a_scoreIncrease;
        scoreText.text = ((int)score).ToString();

        multiplierSlider.value = score / 100;
    }
}
