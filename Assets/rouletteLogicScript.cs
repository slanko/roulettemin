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
    [SerializeField] int[] spunChamber = { 0, 0, 0, 0, 0, 6 };
    [SerializeField] int currentRound = 0;
    int[] tempArray;
    [SerializeField] Animator gunAnim, UIAnim;
    public Button[] menuButtons;
    [SerializeField] GameObject[] UIBullets;
    [SerializeField] RectTransform UIChamber;
    playerLogicScript playerLogic;

    private void Start()
    {
        playerLogic = GetComponent<playerLogicScript>();
        syncSpunChamberAndChamber();
        spin(Random.Range(1, 7), false);
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
            spin(Random.Range(1, 7), false);
            currentRound = 0;
        }
        else
        {
            gunAnim.SetTrigger("nofire");
            Debug.Log("click...");
        }
        SyncUIBullets();
    }

    //kill this once you have the spin minigame
    //LOL THERE IS NO SPIN MINIGAME. DIE!!!
    public void spinHelper()
    {
        spin(Random.Range(1, 7), true);
    }

    public void spin(int num, bool minusFromPlayer)
    {
        if(minusFromPlayer == true)
        {
            rouletteminScript currentPlayerScript = playerLogic.currentPlayers[0].GetComponent<rouletteminScript>();
            currentPlayerScript.spinLeft--;
        }
        for (int times2Do = 0; times2Do < num; times2Do++)
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
        SyncUIBullets();
        giveReadout();
        playerLogic.checkButtons();
    }

    public void takeAPeek()
    {
        rouletteminScript currentPlayerScript = playerLogic.currentPlayers[0].GetComponent<rouletteminScript>();
        currentPlayerScript.peekLeft--;
        SyncUIBullets();
        UIAnim.SetBool("Peek Up", true);
        Invoke("UIBackDown", 3);
        giveReadout();
        playerLogic.checkButtons();
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
        Quaternion chamberRotation = new Quaternion();
        chamberRotation.eulerAngles = new Vector3(0, 0, 60 * currentRound);
        UIChamber.rotation = chamberRotation;
        //FUCK YES that was so much easier than before
    }

    public void quitGame()
    {
        SceneManager.LoadScene("menu");
    }
    void syncSpunChamberAndChamber()
    {
        int[] tempChamberArray = chamber;
        spunChamber = tempChamberArray;
        Debug.Log("spun chamber synced to regular");
    }

    //i can't not read it as spunch amber anymore i am going insane

    void giveReadout()
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
    }
}
