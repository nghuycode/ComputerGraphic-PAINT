using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : Polygon
{
    float radius;
    public Hexagon(Vector3 startPoint, Vector3 endPoint) 
    {
        pointsList = new Vector3[6];
        Update(startPoint, endPoint);
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        float deltaX = endPoint.x - startPoint.x;
        float deltaY = endPoint.y - startPoint.y;
        float delta = Mathf.Min(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        Vector3 secondPoint = new Vector3(startPoint.x + deltaX / Mathf.Abs(deltaX) * delta, startPoint.y + deltaY / Mathf.Abs(deltaY) * delta);
        center = (startPoint + secondPoint) / 2;
        radius = Vector3.Distance(startPoint, center);
        for(int i = 0; i < 6; ++i)
        {
                pointsList[i] = new Vector3(center.x + radius * (float)Mathf.Cos(i * 60 * Mathf.PI / 180f), 
                                        center.y + radius * (float)Mathf.Sin(i * 60 * Mathf.PI / 180f), 1);
        }

    }
}
