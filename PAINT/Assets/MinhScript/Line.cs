using UnityEngine;

public class Line : Shape
{
    Vector3 firstPoint, lastPoint;
    public Line(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        GL.Vertex(firstPoint);
        GL.Vertex(lastPoint);
        GL.End();
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        Init(startPoint, endPoint);
        firstPoint = startPoint;
        lastPoint = endPoint;
    }
}
