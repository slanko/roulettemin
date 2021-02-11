using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScriptHelper : MonoBehaviour
{
    [SerializeField] playerLogicScript  playerLogic;
    [SerializeField] rouletteLogicScript rouletteLogic;

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
    }
}
