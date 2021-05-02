using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Color CurrentColor;
    public EnumConst.DrawType CurrentDrawType;
    public EnumConst.MenuType CurrentMenu;
    public static MenuManager Instance;
    
    private void Awake() {
        Instance = this;
        foreach (PieMenu menu in MenuList) 
        {
            MenuDict.Add(menu.gameObject.name, menu);
        }
        CurrentColor = Color.green;
    }
    public List<PieMenu> MenuList = new List<PieMenu>();
    public List<int> MenuStartIndex;
    public Dictionary<string, PieMenu> MenuDict = new Dictionary<string, PieMenu>();
    public void ReceiveCommand(int id, string cmd) 
    {
        if (cmd.Contains("Line")) 
        {
            CurrentMenu = EnumConst.MenuType.Line;
            CurrentDrawType = EnumConst.DrawType.Line;
        }
        else
        if (cmd.Contains("Menu")) 
        {
            CurrentMenu = (EnumConst.MenuType)id;
            MenuDict[cmd].ShowMenu();
        }
        else if (cmd.Contains("Color")) 
        {
            CurrentDrawType = EnumConst.DrawType.Paint;
            switch (id) 
            {
                case 0:
                    CurrentColor = Color.green;
                    break;
                case 1:
                    CurrentColor = Color.red;
                    break;
                case 2:
                    CurrentColor = Color.yellow;
                    break;
                case 3:
                    CurrentColor = Color.blue;
                    break;
                case 4:
                    CurrentColor = Color.magenta;
                    break;
            }
        }
        else 
        {   
            CurrentDrawType = (EnumConst.DrawType)GetRealID(CurrentMenu, id);   
        }   
    }
    private int GetRealID(EnumConst.MenuType menu, int id) 
    {
        return MenuStartIndex[(int)menu] + id;
    }
    public bool IsShowingMenu()
    {
        return (PieMenuManager.Instance.display.Count > 0);
    }

}
