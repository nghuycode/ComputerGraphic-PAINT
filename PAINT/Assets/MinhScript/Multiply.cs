using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : Shape
{
    float dx, dy;
    Vector3 startPoint;
    int[] mx = new int[12]{0, 1, 2, 3, 4, 3, 4, 3, 2, 1, 0, 1};
    int[] my = new int[12]{1, 0, 1, 0, 1, 2, 3, 4, 3, 4, 3, 2};
    public Multiply(Vector3 startPoint, Vector3 endPoint){
        Update(startPoint, endPoint);
    }
    override public void Update(Vector3 startPoint, Vector3 endPoint){
        dx = (endPoint.x - startPoint.x) / 4;
        dy = (endPoint.y - startPoint.y) / 4;
        this.startPoint = startPoint;
    }
    override public void Draw(){
        GL.Begin(GL.LINES);
        
        for (int i = 0; i < 12; i++){
            GL.Vertex3(startPoint.x + mx[i] * dx, startPoint.y + my[i] * dy, startPoint.z);
            GL.Vertex3(startPoint.x + mx[(i + 1) % 12] * dx, startPoint.y + my[(i + 1) % 12] * dy, startPoint.z);
        }

        GL.End();
    }
}
