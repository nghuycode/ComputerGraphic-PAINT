using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private void Awake() {
        Instance = this;
        foreach (PieMenu menu in MenuList) 
        {
            MenuDict.Add(menu.gameObject.name, menu);
        }
    }
    public List<PieMenu> MenuList = new List<PieMenu>();
    public Dictionary<string, PieMenu> MenuDict = new Dictionary<string, PieMenu>();
    public void ReceiveCommand(string cmd) 
    {
        if (cmd.Contains("Menu")) 
        {
            Debug.Log("Menu: " + cmd);
            MenuDict[cmd].ShowMenu();
        }
        else 
        {   
            Debug.Log("Action: " + cmd);    
        }   
    }

}
