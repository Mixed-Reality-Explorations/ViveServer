using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MyNetworkManager : MonoBehaviour
{
    public GameObject connectionIndicator;

    bool noServer = true;

    public const short NotConnected = 1000;
    public const short Tracking = NotConnected + 1;
    public const short Calibrating = Tracking + 1;
    public const short Editing = Calibrating + 1;
    public const short Connecting = Editing + 1;
    public const short Gesture = Connecting + 1;

    private short _clientStatus;

    void LateUpdate()
    {
        if (noServer)
        {
            NetworkServer.Listen(4444);
            noServer = false;
            Debug.Log("Server started.");
            connectionIndicator.transform.rotation = Quaternion.Euler(45f, 45f, 45f);
            _clientStatus = NotConnected;
        }
       
        else
        {
            //Debug.Log("Position: " + _trackerPosition.position + ", rotation: " + _trackerPosition.rotation);
            
            //NetworkServer.SendToAll(Tracking, msg);
        }
    }

    public void sendMessage(short messageType, MessageBase msg)
    {
        //Debug.Log("Sending message...");
        NetworkServer.SendToAll(messageType, msg);
    }

}

public class TrackingMessage : MessageBase
{
    public int id;
    public bool trigger;
    public Vector3 position;
    public Vector2 touchPad;
    public bool grip;
    public bool padClicked;
    public bool padTouched;
}

public class GestureMessage : MessageBase
{
    public int gestureCode;
}