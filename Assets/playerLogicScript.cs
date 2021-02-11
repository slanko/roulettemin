using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class playerLogicScript : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] int playerCount;
    [SerializeField] GameObject spawnPoint;
    //currentplayers exists because players was getting desynced so i shuffled a seperate identical list to make that not happen
    [SerializeField] List<GameObject> players, currentPlayers;
    [SerializeField] GameObject playerObject;
    [SerializeField] List<GameObject> placesInLineForShuffle;
    [SerializeField] Text playerText, roundText; 
    GameObject[] tempArray;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("playerCount") != 0)
        {
            playerCount = PlayerPrefs.GetInt("playerCount");
        }

        initializeSpawnPoints();
        initializePlayers();
        setCurrentPlayer();
    }

    void initializePlayers()
    {
        int currentPlayer = 1;
        //do bottom half
        for(int i = Mathf.CeilToInt(spawnPoints.Count / 2); i <= Mathf.CeilToInt(spawnPoints.Count / 2) && i >= 0; i--)
        {
            GameObject playuh = Instantiate(playerObject);
            players.Add(playuh);
            rouletteminScript playerScript = playuh.GetComponent<rouletteminScript>();
            playerScript.placeInLine = spawnPoints[i];
            playerScript.myNum = currentPlayer;
            currentPlayer++;
        }

        //do top half
        for(int i = spawnPoints.Count - 1; i > Mathf.CeilToInt(spawnPoints.Count / 2); i--)
        {
            GameObject playuh = Instantiate(playerObject);
            players.Add(playuh);
            rouletteminScript playerScript = playuh.GetComponent<rouletteminScript>();
            playerScript.placeInLine = spawnPoints[i];
            playerScript.myNum = currentPlayer;
            currentPlayer++;
        }
        currentPlayers = players;
    }

    void initializeSpawnPoints()
    {
        float offsetX = 2.5f;
        float offsetZ = 1.25f;
        for (int i = 1; i < playerCount; i++)
        {
            if (i % 2 == 0)
            {
                spawnPoints.Add(Instantiate(spawnPoint, new Vector3(spawnPoints[0].transform.position.x + offsetX, 2, spawnPoints[0].transform.position.z + offsetZ), new Quaternion(0, 0, 0, 0)));
                offsetX = offsetX + 2.5f;
                offsetZ = offsetZ + 1.25f;
            }
            else
            {
                spawnPoints.Add(Instantiate(spawnPoint, new Vector3(spawnPoints[0].transform.position.x - offsetX, 2, spawnPoints[0].transform.position.z + offsetZ), new Quaternion(0, 0, 0, 0)));
            }
        }
        spawnPoints = spawnPoints.OrderBy(x => x.transform.position.x).ToList();
    }

    public void killPlayer()
    {
        rouletteminScript currentPlayerScript = currentPlayers[0].GetComponent<rouletteminScript>();
        currentPlayerScript.dead = true;
    }
    public void setCurrentPlayer()
    {
        rouletteminScript currentPlayer = currentPlayers[0].GetComponent<rouletteminScript>();
        if(currentPlayer.dead == true)
        {
            moveLine();
        }
        else
        {
            playerText.text = "PLAYER\n" + currentPlayer.myNum;
        }
    }

    public void moveLine()
    {
        if(placesInLineForShuffle.Count > 0)
        {
            placesInLineForShuffle.Clear();
        }
        //take current positions
        foreach(GameObject player in players)
        {
            rouletteminScript currentPlayer = player.GetComponent<rouletteminScript>();
            placesInLineForShuffle.Add(currentPlayer.placeInLine);
        }
        //shuffle positions
        tempArray = placesInLineForShuffle.ToArray();
        GameObject tempPlace = tempArray[tempArray.Length - 1];
        for(int i = tempArray.Length - 2; i >= 0; i--)
        {
            tempArray[i + 1] = tempArray[i];
        }
        tempArray[0] = tempPlace;
        //set positions back
        int index = 0;
        foreach(GameObject player in players)
        {
            rouletteminScript currentPlayer = player.GetComponent<rouletteminScript>();
            currentPlayer.placeInLine = tempArray[index];
            index++;
        }
        //shuffle player list to keep sync
        tempArray = new GameObject[players.Count];
        tempArray = currentPlayers.ToArray();
        //DO THIS BACKWARDS
        /*
        GameObject tempPlayer = tempArray[tempArray.Length - 1];
        for (int i = tempArray.Length - 2; i >= 0; i--)
        {
            tempArray[i + 1] = tempArray[i];
        }
        tempArray[0] = tempPlayer;
        */
        GameObject tempPlayer = tempArray[0];
        for(int i = 1; i < tempArray.Length; i++)
        {
            tempArray[i - 1] = tempArray[i];
        }
        tempArray[tempArray.Length - 1] = tempPlayer;
        currentPlayers = tempArray.ToList();
        setCurrentPlayer();
    }
}
