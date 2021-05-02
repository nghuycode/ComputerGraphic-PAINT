using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : Shape
{
    float radius;
    Vector3 center;
    Vector3[] points = new Vector3[6];
    public Hexagon(Vector3 startPoint, Vector3 endPoint) 
    {
        Init(startPoint, endPoint);
        Update(startPoint, endPoint);
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        for (int i = 0; i < 5; ++i) 
        {
            GL.Vertex(points[i]);
            GL.Vertex(points[i + 1]);
        }
        GL.Vertex(points[5]);
        GL.Vertex(points[0]);
        GL.End();
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        center = (startPoint + endPoint) / 2;
        radius = Vector3.Distance(startPoint, endPoint);
        for(int i = 0; i < 6; ++i)
        {
                points[i] = new Vector3(center.x + radius * (float)Mathf.Cos(i * 60 * Mathf.PI / 180f), 
                                        center.y + radius * (float)Mathf.Sin(i * 60 * Mathf.PI / 180f), 0);
        }

    }
}
