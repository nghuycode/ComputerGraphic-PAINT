using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTool : MonoBehaviour
{
    public Shape CurrentShape;
    public Demo Demo;
    private void Update() {
        AssignCurrentShape();
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            CurrentShape.Rotate(-1);
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            CurrentShape.Rotate(1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            CurrentShape.Translate(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            CurrentShape.Translate(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            CurrentShape.Translate(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {   
            CurrentShape.Translate(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Plus)) 
        {
            CurrentShape.Scale(10);
        }
        if (Input.GetKeyDown(KeyCode.Minus)) 
        {
            CurrentShape.Scale(-10);
        }
    }
    private void AssignCurrentShape() 
    {
        if (Demo.list.Count > 0)
            CurrentShape = Demo.list[Demo.list.Count - 1];
        else 
            CurrentShape = null;
    }
}
