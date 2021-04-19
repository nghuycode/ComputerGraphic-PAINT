
using UnityEngine;

public class RightTriangle: Triangle
{
    public RightTriangle(Vector3 startPoint, Vector3 endPoint)
    {
        firstPoint = startPoint;
        Vector3 heightVector = endPoint - startPoint;
        Vector3 toRightPointVector = new Vector3(heightVector.y, -heightVector.x, heightVector.z);
        secondPoint = endPoint + toRightPointVector;
        
        Vector3 toLeftPointVector = -toRightPointVector;
        lastPoint = endPoint + toLeftPointVector;

    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        firstPoint = startPoint;
        Vector3 heightVector = endPoint - startPoint;
        Vector3 toRightPointVector = new Vector3(heightVector.y, -heightVector.x, heightVector.z);
        secondPoint = firstPoint + heightVector + toRightPointVector;

        Vector3 toLeftPointVector = -toRightPointVector;
        lastPoint = firstPoint + heightVector + toLeftPointVector;
    }
}
