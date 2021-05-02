using UnityEngine;

public class Pentagon : Polygon
{
    float radius;

    public Pentagon(Vector3 startPoint, Vector3 endPoint) 
    {
        pointsList = new Vector3[5];
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
        double theta = -Mathf.PI / 2.0;
        double dtheta = 2.0 * Mathf.PI / 5.0;
        for (int i = 0; i < 5; i++)
        {
            pointsList[i] = new Vector3(center.x + (float)(radius * Mathf.Cos((float)theta)),
                                    center.y + (float)(radius * Mathf.Sin((float)theta)), 1);
            theta += dtheta;
        }
    }
}
