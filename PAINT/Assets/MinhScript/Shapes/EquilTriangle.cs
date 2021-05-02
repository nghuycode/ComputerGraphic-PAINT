
using UnityEngine;

public class EquilTriangles: Triangle
{
    public EquilTriangles(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);

    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        pointsList[0] = startPoint;
        Vector3 heightVector = endPoint - startPoint;
        Vector3 toRightPointVector = new Vector3(heightVector.y, -heightVector.x, heightVector.z) / Mathf.Sqrt(3);
        pointsList[1] = pointsList[0] + heightVector + toRightPointVector;

        Vector3 toLeftPointVector = -toRightPointVector;
        pointsList[2] = pointsList[0] + heightVector + toLeftPointVector;

        center = startPoint + heightVector * 2 / 3;
    }
}
