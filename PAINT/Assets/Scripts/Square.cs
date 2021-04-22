using UnityEngine;

public class Square : Shape
{
    Rectangle rectangle;
    public Square(Vector3 startPoint, Vector3 endPoint)
    {
        rectangle = new Rectangle(startPoint, endPoint);
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint)
    {   
        if ((endPoint.x - startPoint.x) * (endPoint.y - startPoint.y) > 0)
            rectangle.Update(startPoint, new Vector3(endPoint.x, startPoint.y + endPoint.x - startPoint.x, 0));
        else
            rectangle.Update(startPoint, new Vector3(startPoint.x - endPoint.y + startPoint.y, endPoint.y, 0));
    }

    override public void Draw(){
        rectangle.Draw();
    }
}
