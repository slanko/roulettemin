using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] InputField playerNumInput;
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

}
