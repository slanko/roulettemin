using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] InputField playerNumInput;
    [SerializeField] Button beginGameButton;
    void Start()
    {
        playerNumInput.text = PlayerPrefs.GetInt("playerCount", 5).ToString();
    }
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void setPlayerNum()
    {
        PlayerPrefs.SetInt("playerCount", int.Parse(playerNumInput.text));
    }

    public void checkPlayerCount()
    {
        if(PlayerPrefs.GetInt("playerCount") >= 1)
        {
            beginGameButton.interactable = true;
        }
        else
        {
            beginGameButton.interactable = false;
        }
    }

}
