using UnityEngine;

public class Rectangle : Quad
{
    public Rectangle(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        point[0] = startPoint;
        point[1] = new Vector3(startPoint.x, endPoint.y);
        point[2] = endPoint;
        point[3] = new Vector3(endPoint.x, startPoint.y);
    }
}
