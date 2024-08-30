using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameSceneController gameSceneController;
    [SerializeField] Transform[] playerTransforms;


    public Camera camera;
    public float yOffset = 1.5f;
    public float minDistance = 3.0f;

    private float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
        
     
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MultiplayersCameraMovement();
    }

    public void Init()
    {
        //MyCharacterController[] allPlayers = GameObject.FindObjectsOfType<MyCharacterController>();
        playerTransforms = new Transform[gameSceneController.playerControllers.Count];
        for (int i = 0; i < gameSceneController.playerControllers.Count; i++)
        {
            playerTransforms[i] = gameSceneController.playerControllers[i].transform;
        }
    }
    void MultiplayersCameraMovement()
    {
        if(camera ==null) { camera = Camera.main;  }
        if (!gameSceneController.startGame) { return; }
        if (playerTransforms.Length == 0)
        {
            Debug.Log("Cant find player for camera movement");
            return;
        }

        xMin = xMax = playerTransforms[0].position.x;
        yMin = yMax = playerTransforms[0].position.y;

        for (int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.x < xMin)
                xMin = playerTransforms[i].position.x;

            if (playerTransforms[i].position.x > xMax)
                xMax = playerTransforms[i].position.x;

            if (playerTransforms[i].position.y < yMin)
                yMin = playerTransforms[i].position.y;

            if (playerTransforms[i].position.y > yMax)
                yMax = playerTransforms[i].position.y;
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;
        float distance = xMax - xMin;

        if (distance < minDistance)
            distance = minDistance;

        camera.transform.position = new Vector3(xMiddle, yMiddle + yOffset, -distance);

    }
}
