using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class playerLogicScript : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] int playerCount;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> players;
    [SerializeField] GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        initializeSpawnPoints();
        initializePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        rouletteminScript currentPlayerScript = players[0].GetComponent<rouletteminScript>();
        currentPlayerScript.dead = true;
    }

    void moveLine()
    {

    }
}
