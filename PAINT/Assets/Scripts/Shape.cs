using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    protected Color color;
    public virtual void drawShape(Vector3 startPoint, Vector3 endPoint){}
    public virtual void drawShape(){}
}

public static class ShapeRepository
{
    private static Line line;
    private static Rectangle rectangle;
    public static Line Line{
        get {
            if (line == null){
                line = new Line();
            }
            return line;
        }
    }
    public static Rectangle Rectangle{
        get {
            if (rectangle == null){
                rectangle = new Rectangle();
            }
            return rectangle;
        }
    }
}