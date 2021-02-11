using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rouletteLogicScript : MonoBehaviour
{
    //i forget how this works. thank you anteater please do not shoot me
    [SerializeField] int[] chamber = { 0, 0, 0, 0, 0, 6 };
    [SerializeField] int[] spunChamber;
    [SerializeField] int currentRound = 0;
    int[] tempArray;
    [SerializeField] Animator gunAnim, UIAnim;
    public Button[] menuButtons;
    [SerializeField] GameObject[] UIBullets;

    private void Start()
    {
        spunChamber = chamber;
        spin(Random.Range(1, 7));
    }

    public void fire()
    {
        currentRound++;

        if(currentRound >= 6)
        {
            currentRound = 0;
        }

        if(spunChamber[currentRound] == 6)
        {
            gunAnim.SetTrigger("fire");
            Debug.Log("BLAM!!");
            spin(Random.Range(1, 7));
            currentRound = 0;
        }
        else
        {
            gunAnim.SetTrigger("nofire");
            Debug.Log("click...");
        }
    }

    //kill this once you have the spin minigame
    public void spinHelper()
    {
        spin(Random.Range(1, 7));
    }

    public void spin(int num)
    {
        for(int times2Do = 0; times2Do < num; times2Do++)
        {
            tempArray = spunChamber;
            int tempChamber = tempArray[5];
            for (int i = 4; i >= 0; i--)
            {
                tempArray[i + 1] = tempArray[i];
            }
            tempArray[0] = tempChamber;
            spunChamber = tempArray;
        }
        gunAnim.SetTrigger("spin");
    }

    public void takeAPeek()
    {
        string stringOutput = "";
        foreach (int chamber in spunChamber)
        {
            if (chamber == 0)
            {
                stringOutput = stringOutput + "◯";
            }
            if (chamber == 6)
            {
                stringOutput = stringOutput + "X";
            }
        }
        Debug.Log(stringOutput);
        SyncUIBullets();
        UIAnim.SetBool("Peek Up", true);
        Invoke("UIBackDown", 3);
    }
void UIBackDown()
    {
        UIAnim.SetBool("Peek Up", false);
    }

    public void toggleButtonUsability(bool togg)
    {
        foreach(Button currentButton in menuButtons)
        {
            currentButton.interactable = togg;
        }
    }

    void SyncUIBullets()
    {
        int i = 0;
        foreach(GameObject bullet in UIBullets)
        {
            if(spunChamber[i] == 0)
            {
                bullet.SetActive(false);
            }
            if(spunChamber[i] == 6)
            {
                bullet.SetActive(true);
            }
            i++;
        }
    }

    public void quitGame()
    {
        SceneManager.LoadScene("menu");
    }
}
