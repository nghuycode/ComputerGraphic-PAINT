using UnityEngine;

public class Rectangle : Quad
{
    public Rectangle(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        pointsList[0] = startPoint;
        pointsList[1] = new Vector3(startPoint.x, endPoint.y,1);
        pointsList[2] = endPoint;
        pointsList[3] = new Vector3(endPoint.x, startPoint.y,1);
        center = (startPoint + endPoint) / 2;
    }

}
