using UnityEngine;

public class Square : Shape
{
    float length;
    Vector3 startPoint;
    public Square(Vector3 startPoint, Vector3 endPoint)
    {
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint)
    {
        if (Mathf.Abs(startPoint.x-endPoint.x)> Mathf.Abs(startPoint.y-endPoint.y))
            length = endPoint.x - startPoint.x;
        else
            length = endPoint.y - startPoint.y;
        this.startPoint = startPoint;
    }

    override public void Draw(){
        GL.Begin(GL.LINES);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x + length, startPoint.y, startPoint.z);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, startPoint.y + length, startPoint.z);

        GL.Vertex3(startPoint.x + length, startPoint.y + length, startPoint.z);
        GL.Vertex3(startPoint.x +length, startPoint.y, startPoint.z);

        GL.Vertex3(startPoint.x + length, startPoint.y + length, startPoint.z);
        GL.Vertex3(startPoint.x, startPoint.y + length, startPoint.z);

        GL.End();
    }
}
