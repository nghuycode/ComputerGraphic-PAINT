using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : Shape{
    float dx, dy;
    Vector3 startPoint;

    int[] mx = new int[12]{0, 1, 1, 2, 2, 3, 3, 2, 2, 1, 1, 0};
    int[] my = new int[12]{-1, -1, 0, 0, -1, -1, -2, -2, -3, -3, -2, -2};
    public Plus(Vector3 startPoint, Vector3 endPoint){
        Init(startPoint, endPoint);
        Update(startPoint, endPoint);
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        dx = (endPoint.x - startPoint.x) / 3;
        dy = (startPoint.y - endPoint.y) / 3;
        this.startPoint = startPoint;
    }
    public override void Draw(){
        GL.Begin(GL.LINES);
        
        for (int i = 0; i < 12; i++){
            GL.Vertex3(startPoint.x + mx[i] * dx, startPoint.y + my[i] * dy, startPoint.z);
            GL.Vertex3(startPoint.x + mx[(i + 1) % 12] * dx, startPoint.y + my[(i + 1) % 12] * dy, startPoint.z);
        }

        GL.End();
    }
}
