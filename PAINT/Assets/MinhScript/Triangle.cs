using UnityEngine;

public class Triangle : Shape
{
    protected Vector3 firstPoint, secondPoint, lastPoint;
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        GL.Vertex(firstPoint);  
        GL.Vertex(secondPoint);
        GL.Vertex(secondPoint);
        GL.Vertex(lastPoint); 
        GL.Vertex(lastPoint);
        GL.Vertex(firstPoint);
        GL.End();
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        Init(startPoint, endPoint);
    }
}
