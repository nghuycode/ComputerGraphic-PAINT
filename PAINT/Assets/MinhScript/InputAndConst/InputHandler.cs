using UnityEngine;
using UnityEngine.EventSystems;
public class InputHandler : MonoBehaviour
{
    public enum TouchState 
    {
        Drag, Drop, Start, ChooseMenu
    }

    public TouchState state = TouchState.Drop;
    Vector3 startTouchPos, currentTouchPos;
    public static InputHandler Instance;
    public EnumConst.DrawType currentShape;
    public Vector3 neededPosition;
    EventSystem eventSys;

    private void Awake() 
    {
        Instance = this;
        currentShape = EnumConst.DrawType.Transformation;
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>(); ;
    }

    public void Start()
    {
        neededPosition =  Demo.instance.mainMenu.transform.position - new Vector3(0, Screen.height, 0);
    }


    private void MouseCheck()
    {
        currentTouchPos = Input.mousePosition + new Vector3(0,0,1);

        if (Input.GetMouseButtonDown(1))
        {
            state = TouchState.ChooseMenu;
            ShowMenu();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            switch (state)
            {
                case TouchState.ChooseMenu:

                    if (!eventSys.IsPointerOverGameObject())
                        {
                            state = TouchState.Drop;
                            UnShowMenu();
                        }
                    break;
                case TouchState.Drop:
                    if(currentShape == EnumConst.DrawType.Transformation)
                    {
                        Demo.instance.ChangeCurrentShapeId(currentTouchPos);
                    }
                    else
                    {
                        state = TouchState.Start;
                        startTouchPos = currentTouchPos;
                    }
                    break;

            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(state != TouchState.ChooseMenu)
                state = TouchState.Drop;
        }
        else
        {
            if(currentShape == EnumConst.DrawType.Transformation)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    Demo.instance.TranslateCurrentShape(new Vector3(-1 * 10, 0, 0));

                if (Input.GetKeyDown(KeyCode.RightArrow))
                    Demo.instance.TranslateCurrentShape(new Vector3(1 * 10, 0, 0));

                if (Input.GetKeyDown(KeyCode.UpArrow))
                    Demo.instance.TranslateCurrentShape(new Vector3(0, 1 * 10, 0));

                if (Input.GetKeyDown(KeyCode.DownArrow))
                    Demo.instance.TranslateCurrentShape(new Vector3(0, -1 * 10, 0));

                if (Input.GetKeyDown(KeyCode.L))
                {
                    Demo.instance.RotateCurrentShape(0.0174532925f);
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    Demo.instance.RotateCurrentShape(-0.0174532925f);
                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Demo.instance.ScaleCurrentShape(new Vector3(0.9f, 0.9f, 1f));
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Demo.instance.ScaleCurrentShape(new Vector3(1.1f, 1.1f, 1f));
                }
            }
        }


        if(state == TouchState.Start)
        if (currentTouchPos != startTouchPos)
        {
            Demo.instance.CreateAShape(currentShape, startTouchPos, currentTouchPos);
            state = TouchState.Drag;
        }

        if (state == TouchState.Drag)
        {
            if (currentShape != EnumConst.DrawType.Transformation)
                Demo.instance.UpdateAShape(startTouchPos, currentTouchPos);
        }
    }
    private void Update()
    {
        
        MouseCheck();
    }


    void ShowMenu()
    {
        Demo.instance.mainMenu.SetActive(true);
        Demo.instance.mainMenu.transform.position = Input.mousePosition + neededPosition;
    }

    void UnShowMenu()
    {
        if (Demo.instance.currentMenu != null)
            Demo.instance.currentMenu.SetActive(false);
        Demo.instance.currentMenu = null;
        Demo.instance.mainMenu.SetActive(false);
    }

}
