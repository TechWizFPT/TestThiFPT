using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MySceneController
{
    [SerializeField] PlayerManager playerManagerPrefab;
    [SerializeField] MyCharacterController playerControllerPrefab;
    [Space]
    public List<MyCharacterController> playerControllers = new List<MyCharacterController>();

    [SerializeField] Transform[] spawnLocation;

    public bool startGame;
    //[SerializeField] Transform spawnLocation2;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();


        SpawnCharacter();

        //Find CameraController
        var tmp = FindObjectOfType<CameraController>();
        tmp.gameSceneController = this;

        tmp.Init();

        startGame= true;
    }

    void SpawnCharacter()
    {

        if(GameManager.Instance.playerManagers.Count <1)
        {
            //Spawn PLayerManager
            for(int i = 0; i < 2; i++)
            {
                var newPlayer = Instantiate(playerManagerPrefab);
                newPlayer.playerID = 0;
                Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
                SceneManager.MoveGameObjectToScene(newPlayer.gameObject, targetScene);

                GameManager.Instance.playerManagers.Add(newPlayer);
            }
           
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(MySceneManager.SceneIndex.GamePlayScene.ToString()));
        Debug.Log("Active scene is aaaaaaa" + SceneManager.GetActiveScene().name);

        for (int i = 0; i < GameManager.Instance.playerManagers.Count; i++)
        {
            //Quaternion rotation = Quaternion.Euler(0, 90, 0);
            //var tmp = Instantiate(playerControllerPrefab, spawnLocation[i].position, Quaternion.identity);
            var tmp = Instantiate(playerControllerPrefab);


            playerControllers.Add(tmp);
            tmp.playerManager = GameManager.Instance.playerManagers[i];
            tmp.playerManager.playerID = i;
            Debug.Log("Spawn Character " + tmp.playerManager.playerID);
        }

        playerControllers[0].target = playerControllers[1].transform;
        playerControllers[1].target = playerControllers[0].transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {

    }
}
