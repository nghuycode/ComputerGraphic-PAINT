using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private void Awake() {
        Instance = this;

    }
    public List<GameObject> MenuList = new List<GameObject>();
    private void Update() {
        Debug.Log(MenuList.Count);
    }
    public void ReceiveCommand(int id) 
    {
        MenuList[id].GetComponent<PieMenu>().ShowMenu();
    }

}
