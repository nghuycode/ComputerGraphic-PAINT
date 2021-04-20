using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Shape
{
    Vector3[] points = new Vector3[4];
    public Arrow(Vector3 startPoint, Vector3 endPoint) 
    {
        Update(startPoint, endPoint);
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        GL.Vertex(points[0]);
        GL.Vertex(points[1]);
        GL.End();
        GL.Begin(GL.LINES);
        GL.Vertex(points[1]);
        GL.Vertex(points[2]);
        GL.End();
        GL.Begin(GL.LINES);
        GL.Vertex(points[1]);
        GL.Vertex(points[3]);
        GL.End();
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        points[0] = startPoint;
        points[1] = endPoint;
        points[2] = (startPoint + endPoint) / 2 + new Vector3(0, 100f, 0);
        points[3] = (startPoint + endPoint) / 2 + new Vector3(0, -100f, 0);
    }
}
