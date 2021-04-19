using UnityEngine;

public class Square : Quad
{
    
    public Square(Vector3 startPoint, Vector3 endPoint)
    {

        Vector3 midPoint = (startPoint + endPoint)/2;
        
        point[0] = startPoint;
        
        point[2] = endPoint;

    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        float deltaX, deltaY, delta;
        deltaX = endPoint.x - startPoint.x;
        deltaY = endPoint.y - startPoint.y;
        delta = Mathf.Min(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        float signX = deltaX / Mathf.Abs(deltaX);
        float signY = deltaY / Mathf.Abs(deltaY);


        point[0] = startPoint;
        point[1] = new Vector3(startPoint.x + signX * delta, startPoint.y);
        point[2] = new Vector3(startPoint.x + signX * delta, startPoint.y + signY * delta);
        point[3] = new Vector3(startPoint.x, startPoint.y + signY * delta);
    }
}
