using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : Polygon
{
    int[] mx = new int[12]{0, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 0};
    int[] my = new int[12]{-1, -1, 0, 0, -1, -1, -2, -2, -3, -3, -2, -2};


    public Plus(Vector3 startPoint, Vector3 endPoint){
        pointsList = new Vector3[12];
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        float dx, dy;
        float deltaX = endPoint.x - startPoint.x;
        float deltaY = endPoint.y - startPoint.y;
        float delta = Mathf.Min(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        Vector3 secondPoint = new Vector3(startPoint.x + deltaX / Mathf.Abs(deltaX) * delta, startPoint.y + deltaY / Mathf.Abs(deltaY) * delta);

        dx = (secondPoint.x - startPoint.x) / 3;
        dy = (startPoint.y - secondPoint.y) / 3;
        center = (startPoint + secondPoint) / 2;

        for (int i = 0; i < 12; i++)
            pointsList[i] = new Vector3(startPoint.x + mx[i] * dx, startPoint.y + my[i] * dy, 1);
    }
}
