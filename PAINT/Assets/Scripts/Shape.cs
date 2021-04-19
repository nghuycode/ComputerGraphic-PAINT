using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    public virtual void drawShape(Vector3 startPoint, Vector3 endPoint){}
    public virtual void drawShape(){}
}

public class Line : Shape
{
    Vector3 startPoint;
    Vector3 endPoint;
    public Line(){}
    public Line(Vector3 startPoint, Vector3 endPoint){
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
    override public void drawShape(Vector3 start, Vector3 end){
        Debug.Log("Start: " + start);

        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(start);
        GL.Vertex(end);
        GL.End();
    }
    override public void drawShape(){
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(this.startPoint);
        GL.Vertex(this.endPoint);
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
    private static Line line;
    public static Line Line{
        get {
            if (line == null){
                line = new Line();
            }
            return line;
        }
    }
}