using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Shape
{
    Vector3 startPoint, endPoint;
    public Rectangle(){
        this.startPoint = InputHandler.Instance.startTouchPos;
        this.endPoint = InputHandler.Instance.currentTouchPos;
        this.color = MenuManager.Instance.CurrentColor;
    }
    override public void drawShape(){
        GL.Begin(GL.LINES);
        GL.Color(this.color);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.End();
    }
    override public void drawShape(Vector3 startPoint, Vector3 endPoint){
        GL.Begin(GL.LINES);
        GL.Color(MenuManager.Instance.CurrentColor);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.End();
    }
}
