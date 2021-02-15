using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunScriptHelper : MonoBehaviour
{
    [SerializeField] playerLogicScript  playerLogic;
    [SerializeField] rouletteLogicScript rouletteLogic;
    [SerializeField] AudioSource aud;
    [SerializeField] Text roundText;
    int currentGameRound = 1;

    public void killPlayerHelper()
    {
        playerLogic.killPlayer();
    }
    public void movePlayers()
    {
        playerLogic.moveLine();
    }

    public void buttonToggleOff()
    {
        rouletteLogic.toggleButtonUsability(false);
    }
    public void buttonToggleOn()
    {
        rouletteLogic.toggleButtonUsability(true);
        playerLogic.checkButtons();
    }

    public void playSound(AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

    public void advanceRound()
    {
        currentGameRound++;
        roundText.text = "ROUND\n" + currentGameRound;
    }
}
