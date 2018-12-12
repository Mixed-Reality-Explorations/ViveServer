using UnityEngine;

public class ControllerTracker : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;

    private int _updateCount = 0;

    private int _id;
    public MyNetworkManager _networkManager;
    private bool _trigger = false;
    private Vector3 _position;
    private Vector2 _touchPad;
    private bool _grip = false;
    private bool _padClicked = false;
    private bool _padTouched = false;

    private ushort pulsePower = 700;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
        _id = (int)trackedObject.index;
        controller = GetComponent<SteamVR_TrackedController>();
        controller.Gripped += HandleGrip;
        controller.TriggerClicked += HandleTrigger;
        controller.PadClicked += HandlePadClick;
        controller.PadUnclicked += HandlePadUnclick;
        controller.PadTouched += HandlePadTouched;
        controller.PadUntouched += HandlePadUntouched;
    }

    void HandlePadUntouched(object sender, ClickedEventArgs e)
    {
        Debug.Log("pad NOT touched, id: " + _id);
        _padTouched = false;
    }

    void HandlePadTouched(object sender, ClickedEventArgs e)
    {
        Debug.Log("pad touched, id: " + _id);
        _padTouched = true;
    }

    void HandlePadClick(object sender, ClickedEventArgs e)
    {
        Debug.Log("Pad clicked, id: " + _id);
        _padClicked = true;

    }

    void HandlePadUnclick(object sender, ClickedEventArgs e)
    {
        Debug.Log("Pad NOT clicked, id: " + _id);
        _padClicked = false;
    }

    void HandleGrip(object sender, ClickedEventArgs e)
    {
        Debug.Log("grip has been pressed, id: " + _id);
        _grip = true;
    }

    void HandleTrigger(object sender, ClickedEventArgs e)
    {
        Debug.Log("trigger press event, id: " + _id);
        _trigger = true;
    }

    void Update()
    {
        if (_updateCount % 5 == 0)
        {
            _position = transform.position;
            //Debug.Log("_updateCount: " + _updateCount + ", _position: " + _position + ", id: " + (int)trackedObject.index);
            TrackingMessage msg = new TrackingMessage
            {
                id = _id,
                trigger = _trigger,
                position = _position,
                touchPad = _touchPad = device.GetAxis(),
                grip = _grip,
                padClicked = _padClicked,
                padTouched = _padTouched

            };
            _networkManager.sendMessage(MyNetworkManager.Tracking, msg);
            resetAll();
            _updateCount = 0;
        }
        _updateCount++;
    }

    private void resetAll()
    {
        _grip = false;
        _trigger = false;
    }
}
