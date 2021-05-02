using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public enum TouchState 
    {
        Drag, Drop, Start
    }

    private TouchState _state = TouchState.Drop;
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
            if(MenuManager.Instance.CurrentDrawType == EnumConst.DrawType.Paint && !MenuManager.Instance.IsShowingMenu())
                Demo.instance.Coloring((int)Input.mousePosition.x, (int)Input.mousePosition.y, MenuManager.Instance.CurrentColor);
        }
        
        if (Input.GetMouseButton(0) && _state == TouchState.Start)
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
            Demo.instance.FinishAShape();
        }
    }

    #region Move Command Definition

    void Drag()
    {
        if (MenuManager.Instance.CurrentDrawType != EnumConst.DrawType.Paint)
        Demo.instance.UpdateAShape(startTouchPos, currentTouchPos);
    }
    #endregion
    private void Update()
    {
        MouseCheck();
        Debug.Log(Demo.list.Count);
        if (Input.GetKey(KeyCode.L)) 
        {
            Demo.list[Demo.list.Count - 1].Rotate(-1);
        }
        if (Input.GetKey(KeyCode.R)) 
        {
            Demo.list[Demo.list.Count - 1].Rotate(1);
        }
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            Demo.list[Demo.list.Count - 1].Translate(0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            Demo.list[Demo.list.Count - 1].Translate(0, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            Demo.list[Demo.list.Count - 1].Translate(-1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {   
            Demo.list[Demo.list.Count - 1].Translate(1, 0);
        }
        if (Input.GetKey(KeyCode.Plus)) 
        {
            Demo.list[Demo.list.Count - 1].Scale(10);
        }
        if (Input.GetKey(KeyCode.Minus)) 
        {
            Demo.list[Demo.list.Count - 1].Scale(-10);
        }
    }
}
