using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
    void OnSelect(string command) 
    {
        if (command == this.gameObject.name)
        {
            this.GetComponent<PieMenu>().ShowMenu();
        }
    }
}
