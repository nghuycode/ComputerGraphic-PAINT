using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagon : Shape
{
    float radius;
    Vector3 center;
    Vector3[] points = new Vector3[5];
    public Pentagon(Vector3 startPoint, Vector3 endPoint) 
    {
        Update(startPoint, endPoint);
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        for (int i = 0; i < 4; ++i) 
        {
            GL.Vertex(points[i]);
            GL.Vertex(points[i + 1]);
        }
        GL.Vertex(points[4]);
        GL.Vertex(points[0]);
        GL.End();
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        center = (startPoint + endPoint) / 2;
        radius = Vector3.Distance(startPoint, endPoint);
        double theta = -Mathf.PI / 2.0;
        double dtheta = 2.0 * Mathf.PI / 5.0;
        for (int i = 0; i < 5; i++)
        {
            points[i] = new Vector3(center.x + (float)(radius * Mathf.Cos((float)theta)),
                                    center.y + (float)(radius * Mathf.Sin((float)theta)), 0);
            theta += dtheta;
        }
    }
}
