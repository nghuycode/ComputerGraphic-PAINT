using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public virtual void drawShape(Vector3 startPoint, Vector3 endPoint){}
}

public class MyLine : Shape
{
    override public void drawShape(Vector3 startPoint, Vector3 endPoint){
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(startPoint);
        GL.Vertex(endPoint);
        GL.End();
    }
}

public class Rectangle : Shape
{
    override public void drawShape(Vector3 startPoint, Vector3 endPoint){

    }
}

public static class ShapeRepository
{
    private static MyLine line;
    public static MyLine MyLine{
        get {
            if (line == null){
                line = new MyLine();
            }
            return line;
        }
    }
}