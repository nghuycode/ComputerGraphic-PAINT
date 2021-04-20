using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : Shape
{
    Circle circle1, circle2;
    Rectangle rectangle;
    public Divide(Vector3 startPoint, Vector3 endPoint){
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint){
        float dx = (endPoint.x - startPoint.x) / 3;
        float dy = (startPoint.y - endPoint.y) / 3;
        float d = Mathf.Max(Mathf.Abs(dx), Mathf.Abs(dy));
        rectangle = new Rectangle(startPoint + new Vector3(0, -d, 0), endPoint + new Vector3(0, d, 0));
        circle1 = new Circle(startPoint + new Vector3(d, 0, 0), new Vector3(endPoint.x - d, startPoint.y - d, 0));
        circle2 = new Circle(new Vector3(startPoint.x + d, endPoint.y + d, 0), endPoint + new Vector3(-d, 0, 0));
    }
    override public void Draw(){
        rectangle.Draw();
        circle1.Draw();
        circle2.Draw();
    }
}   
