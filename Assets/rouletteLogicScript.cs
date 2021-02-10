using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class rouletteLogicScript : MonoBehaviour
{
    //i forget how this works. thank you anteater please do not shoot me
    [SerializeField] int[] chamber = { 0, 0, 0, 0, 0, 6 };
    [SerializeField] int[] spunChamber = { 0, 0, 0, 0, 0, 6 };
    [SerializeField] int currentRound = 0;

    public void fire()
    {
        currentRound++;

        if(currentRound >= 6)
        {
            currentRound = 0;
        }

        if(spunChamber[currentRound] == 6)
        {
            Debug.Log("BLAM!!");
            spin(Random.Range(1, 7));
        }
        else
        {
            Debug.Log("click...");
        }
    }

    //kill this once you have the spin minigame
    public void spinHelper()
    {
        spin(Random.Range(0, 100));
    }

    public void spin(int num)
    {
        var randomNum = new Random();
        spunChamber = chamber.OrderBy(x => num).ToArray();
        Debug.Log("chamber spun!");
    }

    public void takeAPeek()
    {
        string stringOutput = "";
        foreach (int chamber in spunChamber)
        {
            if(chamber == 0)
            {
                stringOutput = stringOutput + "◯";
            }
            if (chamber == 6)
            {
                stringOutput = stringOutput + "X";
            }
        }
        Debug.Log(stringOutput);
    }

}
