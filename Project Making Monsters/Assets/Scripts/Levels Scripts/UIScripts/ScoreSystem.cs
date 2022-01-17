using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
	public float score;
	public int multiplier;
	public int multiplierLvl;

	public Slider multiplierSlider;

	TextMeshProUGUI scoreText;

	[SerializeField]
	TextMeshProUGUI multiplierText;

	private void Awake()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	// Start is called before the first frame update
	void Start()
	{
		score = 0;
		scoreText.text = score.ToString();

		multiplierLvl = 1;
		IncreaseMultiplier();
	}

	/// <summary>
	/// Decreases the multiplier bar over time
	/// </summary>
	private void FixedUpdate()
	{
		multiplierSlider.value -= multiplier * Time.deltaTime;
	}

	/// <summary>
	/// Increases player's score as they destroy more buildings
	/// </summary>
	/// <param name="a_scoreIncrease">Damage taken becomes score (+ bonus)</param>
	public void ChangeScore(float a_scoreIncrease)
	{
		a_scoreIncrease *= multiplier;
		score += a_scoreIncrease;
		scoreText.text = ((int)score).ToString();

		multiplierSlider.value += a_scoreIncrease / 100;

		if (multiplierSlider.value >= multiplierSlider.maxValue && multiplierLvl < 7)
		{
			multiplierLvl++;
			multiplierSlider.value = 0;

			IncreaseMultiplier();
		}
	}

	/// <summary>
	/// Amount of damage and score is doubled when the bar is filled
	/// </summary>
	public void IncreaseMultiplier()
	{
		switch (multiplierLvl)
		{
			case 1:
				multiplier = 1;
				break;

			case 2:
				multiplier = 2;
				break;

			case 3:
				multiplier = 4;
				break;

			case 4:
				multiplier = 8;
				break;

			case 5:
				multiplier = 16;
				break;

			case 6:
				multiplier = 32;
				break;

			case 7:
				multiplier = 64;
				break;
		}

		multiplierSlider.maxValue *= multiplierLvl;
		multiplierText.text = "x" + multiplier.ToString();
	}
}
