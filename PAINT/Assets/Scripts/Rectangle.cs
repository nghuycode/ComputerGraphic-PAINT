using UnityEngine;

public class Rectangle : Shape
{
    Vector3 startPoint, endPoint;
    public Rectangle(Vector3 startPoint, Vector3 endPoint){
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    override public void Draw(){
        GL.Begin(GL.LINES);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.Vertex3(startPoint.x, startPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(startPoint.x, endPoint.y, startPoint.z);

        GL.Vertex3(endPoint.x, endPoint.y, startPoint.z);
        GL.Vertex3(endPoint.x, startPoint.y, startPoint.z);

        GL.End();
    }
}