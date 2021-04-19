using UnityEngine;

public class Quad : Shape
{
    protected Vector3[] point = new Vector3[4];
    public override void Draw()
    {
        GL.Begin(GL.LINES);
        for (int i = 0;i < 4;i++)
        {
            GL.Vertex(point[i]);
            GL.Vertex(point[(i + 1) % 4]);
        }
        GL.End();
    }

    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {

    }
}
