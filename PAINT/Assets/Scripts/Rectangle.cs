using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Shape
{
    Vector3 startPoint, endPoint;
    public Rectangle(){}
    public Rectangle(Vector3 startPoint, Vector3 endPoint){
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
    override public void drawShape(){
        GL.Begin(GL.LINES);
        GL.Color(Color.black);

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
        GL.Color(Color.black);

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
