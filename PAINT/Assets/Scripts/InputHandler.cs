using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public enum TouchState 
    {
        Drag, Drop, Start
    }

    private TouchState _state = TouchState.Drop;
    [SerializeField]
    Vector3 startTouchPos, currentTouchPos;
    private float diffX, diffY;
    private float startFrame;
    public static InputHandler Instance;
    private void Awake() {
        Instance = this;
    }
    private void MouseCheck()
    {
       
        currentTouchPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
        {
            _state = TouchState.Start;
            startTouchPos = currentTouchPos;
        }
        
        if (_state == TouchState.Start)
        {   
            if (currentTouchPos != startTouchPos)
            {
                _state = TouchState.Drag;
                //Code To Create A Shape
                if (!MenuManager.Instance.IsShowingMenu())
                    Demo.instance.CreateAShape(MenuManager.Instance.CurrentDrawType, startTouchPos, currentTouchPos);
                Drag();
            }
        }
        if (_state == TouchState.Drag)
            Drag();
        if (Input.GetMouseButtonUp(0))
        {
            _state = TouchState.Drop;
        }
    }

    #region Move Command Definition

    void Drag()
    {
        if(MenuManager.Instance.CurrentDrawType != EnumConst.DrawType.Paint)
        Demo.instance.UpdateAShape(startTouchPos, currentTouchPos);
    }
    #endregion
    private void Update()
    {
        MouseCheck();
    }
}
