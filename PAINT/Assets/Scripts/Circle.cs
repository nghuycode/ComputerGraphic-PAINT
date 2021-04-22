using UnityEngine;

public class Circle : Shape
{
    float r;
    Vector3 center;
    public Circle(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        for (float theta = 0.0f; theta < (2 * Mathf.PI); theta += 0.01f)
        {
            Vector3 ci = (new Vector3(Mathf.Cos(theta) * r + center.x, Mathf.Sin(theta) * r + center.y, center.z));
            GL.Vertex3(ci.x, ci.y, ci.z);
            ci = (new Vector3(Mathf.Cos(theta + 0.01f) * r + center.x, Mathf.Sin(theta + 0.01f) * r + center.y, center.z));
            GL.Vertex3(ci.x, ci.y, ci.z);
        }
        GL.End();
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        float deltaX = endPoint.x - startPoint.x;
        float deltaY = endPoint.y - startPoint.y;
        float delta = Mathf.Min(Mathf.Abs(deltaX), Mathf.Abs(deltaY));
        Vector3 secondPoint = new Vector3(startPoint.x + deltaX / Mathf.Abs(deltaX) * delta, startPoint.y + deltaY / Mathf.Abs(deltaY) * delta);
        center = (startPoint + secondPoint) / 2;
        r = Vector3.Distance(center, startPoint)/ Mathf.Sqrt(2);
    }
}
