using UnityEngine;
using System.Collections;
using System;

public class GPS : MonoBehaviour
{
    public GUIText latitude;
    public GUIText longitude;
    public GUIText altitude;
    public GUIText horizontalAcccuracy;
    public GUIText verticalAcccuracy;
    public GUIText lastUpdated;
    public GUIText status;
    public GUIText isEnabled;

    private string desiredAccuracy = "1";
    private string updateDistance = "1";

    private float screenWidth = 0;
    private float screenHeight = 0;

    private float screenHalfWidth
    {
        get
        {
            return screenWidth / 2;
        }
    }

    private float screenHalfHeight
    {
        get
        {
            return screenHeight / 2;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (longitude == null)
            Debug.Log("longitude is null");

        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnGUI()
    {
        desiredAccuracy = GUI.TextField(new Rect(0.2f * screenWidth,
                                                    0.8f * screenHeight,
                                                    0.3f * screenHalfWidth,
                                                    0.1f * screenHeight),
                                            desiredAccuracy);

        updateDistance = GUI.TextField(new Rect(0.2f * screenWidth,
                                                    0.9f * screenHeight,
                                                    0.3f * screenHalfWidth,
                                                    0.1f * screenHeight),
                                            updateDistance);

        if (GUI.Button(new Rect(screenHalfWidth,
                             0,
                             screenHalfWidth,
                             screenHalfHeight),
                     "Start"))
        {
            
            Input.location.Start(float.Parse(desiredAccuracy),
                                float.Parse(updateDistance));
        }

        if (GUI.Button(new Rect(screenHalfWidth,
                                screenHalfHeight,
                                screenHalfWidth,
                                screenHalfHeight),
                        "Stop"))
        {
            Input.location.Stop();
        }

        LocationInfo location = Input.location.lastData;
        longitude.text = location.longitude.ToString();
        latitude.text = location.latitude.ToString();
        altitude.text = location.altitude.ToString();
        horizontalAcccuracy.text = location.horizontalAccuracy.ToString();
        verticalAcccuracy.text = location.verticalAccuracy.ToString();
        lastUpdated.text = new DateTime(1970, 1, 1).AddSeconds(location.timestamp).ToString();
        status.text = Input.location.status.ToString();
        isEnabled.text = Input.location.isEnabledByUser.ToString();
    }
}
