using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Shape
{
    Vector3 startPoint, endPoint;
    public Line(){
        this.startPoint = InputHandler.Instance.startTouchPos;
        this.endPoint = InputHandler.Instance.currentTouchPos;
        this.color = MenuManager.Instance.CurrentColor;
    }
    override public void drawShape(Vector3 startPoint, Vector3 endPoint){
        GL.Begin(GL.LINES);
        GL.Color(MenuManager.Instance.CurrentColor);
        GL.Vertex(startPoint);
        GL.Vertex(endPoint);
        GL.End();
    }
    override public void drawShape(){
        GL.Begin(GL.LINES);
        GL.Color(this.color);
        GL.Vertex(this.startPoint);
        GL.Vertex(this.endPoint);
        GL.End();
    }
}
