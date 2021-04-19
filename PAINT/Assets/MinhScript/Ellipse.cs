using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : Shape{
    Vector3 center;
    Vector3 size;
    public Ellipse(Vector3 startPoint, Vector3 endPoint){
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint){
        center = (startPoint + endPoint) / 2; 
        size.x = Mathf.Abs(startPoint.x - endPoint.x) / 2;
        size.y = Mathf.Abs(startPoint.y - endPoint.y) / 2;
    }
    public override void Draw(){
        GL.Begin(GL.LINES);
        float radX = size.x;
        float radY = size.y;

        // Vertices
        for (float theta = 0.0f; theta < (2 * Mathf.PI); theta += 0.01f)
        {
            Vector2 ci = new Vector2(center.x + (Mathf.Cos(theta) * radX), center.y + (Mathf.Sin(theta) * radY));
            GL.Vertex(ci);

            if (theta != 0)
                GL.Vertex(ci);
        }
        GL.End();
    }
}
