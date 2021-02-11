using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScriptHelper : MonoBehaviour
{
    [SerializeField] playerLogicScript  playerLogic;

    public void killPlayerHelper()
    {
        playerLogic.killPlayer();
    }
}
