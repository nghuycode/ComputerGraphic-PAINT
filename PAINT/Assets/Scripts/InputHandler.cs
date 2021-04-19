using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public enum TouchState 
    {
        Drag, Drop, Start
    }

    [SerializeField]
    private TouchState _state = TouchState.Drop;
    public Vector3 startTouchPos, currentTouchPos;
    private float diffX, diffY;
    private float startFrame;
    public static InputHandler Instance;
    private void Awake() {
        Instance = this;
    }
    private void MouseCheck()
    {
        if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
        {
            startTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,1);
            _state = TouchState.Start;
            Drawer.Instance.StartDrawing(MenuManager.Instance.CurrentDrawType);
        }

        if (_state == TouchState.Start)
        {
            if (Input.mousePosition != startTouchPos)
            {
                _state = TouchState.Drag;
                Drag();
            }
        }
        if (_state == TouchState.Drag)
            Drag();
        if (Input.GetMouseButtonUp(0))
        {
            _state = TouchState.Drop;
            Drawer.Instance.StopDrawing();
        }
    }

    #region Move Command Definition
    void Drag()
    {
        float disX = Mathf.Abs(Input.mousePosition.x - startTouchPos.x);
        float disY = Mathf.Abs(Input.mousePosition.y - startTouchPos.y);
        currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,1);
    }
    #endregion
    private void Update()
    {
        MouseCheck();
    }
}
