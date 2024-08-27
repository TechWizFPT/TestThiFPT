using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;

public class TestScript : MonoBehaviour
{
    private static ProfilerMarker testFlameMaker = new ProfilerMarker("TestFlame");
    private static ProfilerMarker testFlameMaker2 = new ProfilerMarker("TestFlame2");

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 5;

        GameManager.Instance.CallGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        //TestFlame();
        //TestFlame2();
    }
    
    void TestFlame()
    {
        using (testFlameMaker.Auto())
        {
            Debug.Log("Hello world");
            //Debug.Log("Flame count: " + Time.frameCount + "Real time :" + Time.time);

        }

        
    }

    void TestFlame2()
    {
        using (testFlameMaker2.Auto())
        {
            int num = 0;
            for (int i = 0; i < 100; i++)
            {
                num += 2;
            }
            Debug.Log("Hello world");

        }

    }
}
