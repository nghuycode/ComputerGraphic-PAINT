using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Shape
{
    Vector3 startPoint, endPoint;
    public Line(){}
    public Line(Vector3 startPoint, Vector3 endPoint){
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
    override public void drawShape(Vector3 startPoint, Vector3 endPoint){
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Vertex(startPoint);
        GL.Vertex(endPoint);
        GL.End();
    }
    override public void drawShape(){
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Vertex(this.startPoint);
        GL.Vertex(this.endPoint);
        GL.End();
    }
}
