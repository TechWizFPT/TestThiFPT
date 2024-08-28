using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] PlayerController playerControllerPrefab;
    [SerializeField] List<PlayerController> playerControllers = new List<PlayerController>();

    [SerializeField] Transform[] spawnLocation;
    //[SerializeField] Transform spawnLocation2;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < spawnLocation.Length; i++)
        {
            //Quaternion rotation = Quaternion.Euler(0, 90, 0);
            var tmp = Instantiate(playerControllerPrefab, spawnLocation[i].position,Quaternion.identity);
            playerControllers.Add(tmp);
            tmp.playerID = i;
        }

        playerControllers[0].target = playerControllers[1].transform;
        playerControllers[1].target = playerControllers[0].transform;

        FindObjectOfType<CameraController>().Init();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {

    }
}
