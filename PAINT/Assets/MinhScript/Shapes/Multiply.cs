using UnityEngine;

public class Multiply : Polygon
{
    int[] mx = new int[12]{0, 1, 2, 3, 4, 3, 4, 3, 2, 1, 0, 1};
    int[] my = new int[12]{1, 0, 1, 0, 1, 2, 3, 4, 3, 4, 3, 2};
    public Multiply(Vector3 startPoint, Vector3 endPoint)
    {
        pointsList = new Vector3[12];
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint)
    {
        float dx, dy;
        float deltaX = endPoint.x - startPoint.x;
        float deltaY = endPoint.y - startPoint.y;
        float delta = Mathf.Min(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        Vector3 secondPoint = new Vector3(startPoint.x + deltaX / Mathf.Abs(deltaX) * delta, startPoint.y + deltaY / Mathf.Abs(deltaY) * delta);

        dx = (secondPoint.x - startPoint.x) / 4;
        dy = -(startPoint.y - secondPoint.y) / 4;
        center = (startPoint + secondPoint) / 2;

        for (int i = 0; i < 12; i++)
            pointsList[i] = new Vector3(startPoint.x + mx[i] * dx, startPoint.y + my[i] * dy, 1);
    }

}
