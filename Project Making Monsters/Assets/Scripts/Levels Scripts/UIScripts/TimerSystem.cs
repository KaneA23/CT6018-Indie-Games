using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls level countdown and required UI
/// </summary>
public class TimerSystem : MonoBehaviour
{
	double remainingTime;
	readonly int maxTime = 61;

	TextMeshProUGUI timerText;

	private void Awake()
	{
		timerText = GetComponent<TextMeshProUGUI>();
	}

	// Start is called before the first frame update
	void Start()
	{
		remainingTime = maxTime;
		Time.timeScale = 1f;
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
			Time.timeScale = 0f;
		}
		else
		{
			remainingTime -= Time.deltaTime;
			timerText.text = ((int)remainingTime).ToString();
		}
	}
}
