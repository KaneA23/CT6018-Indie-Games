using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject shopPanel;

    // Start is called before the first frame update
    void Start()
    {
        shopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// When the player clicks, the game begins
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    /// <summary>
    /// When player clicks, shop will either open or shut
    /// </summary>
    /// <param name="a_isOpening">Whether the shop is opening or closing</param>
    public void ToggleShop(bool a_isOpening)
    {
        shopPanel.SetActive(a_isOpening);
    }
}
