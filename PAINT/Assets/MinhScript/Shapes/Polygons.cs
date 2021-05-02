using UnityEngine;

public class Polygon 
{
    protected Vector3[] pointsList;
    protected Vector3 center;
    Color currentColor = Color.white;

    public void Draw()
    {
        for (int i = 0; i < pointsList.Length; i++)
            pointsList[i].z = 1;

        GL.Begin(GL.LINES);
        GL.Color(currentColor);
        for(int i = 0;i < (int)pointsList.Length;i++)
        {
            GL.Vertex(pointsList[i]);
            GL.Vertex(pointsList[(i + 1) % pointsList.Length]);
        }
        GL.Vertex(center);
        GL.Vertex(center + new Vector3(0, 1, 0));
        GL.End();
    }


    public void Select()
    {
        currentColor = Color.yellow;
    }

    public void UnSelect()
    {
        currentColor = Color.white;
    }

    public void Translate(Vector3 position)
    {
        float[,] unitPositionMatrix = { {1, 0, 0 },
                                        {0, 1, 0 },
                                        {position.x, position.y, 1 } };
        for(int i = 0; i < pointsList.Length; i++)
        {
            pointsList[i] = Multiply(pointsList[i], unitPositionMatrix);
        }
        center = Multiply(center, unitPositionMatrix);
    }

    public void Scale(Vector3 scalation)
    {
        float[,] unitScalationMatrix = { {scalation.x, 0, 0 },
                                        {0, scalation.y, 0 },
                                        {0, 0, 1 } };

        float[,] unitScalationMatrixFixedPoint = { {1 - scalation.x, 0, 0 },
                                                   {0, 1 - scalation.y, 0 },
                                                   {0, 0, 1 } };
        for (int i = 0; i < pointsList.Length; i++)
        {
            pointsList[i] = Multiply(pointsList[i], unitScalationMatrix) + Multiply(center,unitScalationMatrixFixedPoint);
        }
   
    }

    public void Rotation(float a)
    {
        float[,] unitRotationMatrix = { {Mathf.Cos(a), Mathf.Sin(a), 0 },
                                        {-Mathf.Sin(a), Mathf.Cos(a), 0 },
                                        {0, 0, 1 } };
        for (int i = 0; i < pointsList.Length; i++)
        {
            pointsList[i] = center + Multiply(new Vector3(pointsList[i].x - center.x, pointsList[i].y - center.y, 0), unitRotationMatrix);
        }
    }

    Vector3 Multiply(Vector3 vector, float[,] matrix)
    {
        vector.x = vector.x * matrix[0,0] + vector.y * matrix[1,0] + vector.z * matrix[2,0];
        vector.y = vector.x * matrix[0,1] + vector.y * matrix[1,1] + vector.z * matrix[2,1];
        vector.z = 1;
        return vector;
    }

 
    
    public float DistanceFromCenter(Vector3 currentPoint)
    {
        currentPoint.z = center.z = 1;
        return Vector3.Distance(currentPoint, center);
    }
    public virtual void Update(Vector3 startPoint, Vector3 endPoint)
    {
    }
}
