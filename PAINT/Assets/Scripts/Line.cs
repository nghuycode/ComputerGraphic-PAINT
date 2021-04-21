using UnityEngine;

public class Line : Shape
{
    Vector3 firstPoint, lastPoint;
    Color color = Color.white;
    public Line(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    public Line(Vector3 startPoint, Vector3 endPoint, Color color){
        firstPoint = startPoint;
        lastPoint = endPoint;
        this.color = color;
    }
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        GL.Color(color);
        GL.Vertex(firstPoint);
        GL.Vertex(lastPoint);
        GL.End();
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        firstPoint = startPoint;
        lastPoint = endPoint;
    }
}
