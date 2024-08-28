using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform[] playerTransforms;
    //public PlayerController player1;
    //public PlayerController player2;
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

    void MultiplayersCameraMovement()
    {
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
    public void Init()
    {
        PlayerController[] allPlayers = GameObject.FindObjectsOfType<PlayerController>();
        playerTransforms = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            playerTransforms[i] = allPlayers[i].transform;
        }
    }
}
