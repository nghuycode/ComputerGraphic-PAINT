using UnityEngine;
using UnityEngine.UI;
public class SelectButton : MonoBehaviour
{
    public EnumConst.DrawType type;
    public void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(SetType);
    }

    public void SetType()
    {
        InputHandler.Instance.currentShape = type;
        InputHandler.Instance.state = InputHandler.TouchState.Drop;
        if(Demo.instance.currentMenu != null)
            Demo.instance.currentMenu.SetActive(false);
        Demo.instance.currentMenu = null;
        Demo.instance.mainMenu.SetActive(false);
    }
}
