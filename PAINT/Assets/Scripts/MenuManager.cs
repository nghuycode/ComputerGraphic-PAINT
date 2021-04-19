using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public EnumConst.ColorType CurrentColor;
    public EnumConst.DrawType CurrentDrawType;
    public EnumConst.MenuType CurrentMenu;
    public static MenuManager Instance;
    
    private void Awake() {
        Instance = this;
        foreach (PieMenu menu in MenuList) 
        {
            MenuDict.Add(menu.gameObject.name, menu);
        }
    }
    public List<PieMenu> MenuList = new List<PieMenu>();
    public List<int> MenuStartIndex;
    public Dictionary<string, PieMenu> MenuDict = new Dictionary<string, PieMenu>();
    public void ReceiveCommand(int id, string cmd) 
    {
        Debug.Log(cmd);
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
            CurrentColor = (EnumConst.ColorType)id;
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

}
