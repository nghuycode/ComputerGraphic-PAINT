using UnityEngine;

public class Square : Quad
{
    public Square(Vector3 startPoint, Vector3 endPoint)
    {
        Init(startPoint, endPoint);
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 midPoint = (startPoint + endPoint) / 2;
        Vector3 diagonal = endPoint - startPoint;
        Vector3 diagonalNormal = new Vector3(diagonal.y, -diagonal.x, diagonal.z);
        point[0] = startPoint;
        point[1] = midPoint + diagonalNormal / 2;
        point[2] = endPoint;
        point[3] = midPoint + (-diagonalNormal / 2);
    }
}
