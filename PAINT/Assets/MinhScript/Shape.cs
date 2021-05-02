using UnityEngine;

public abstract class Shape 
{
    public Vector3 _startPoint, _endPoint;   
    public abstract void Draw();
    public abstract void Update(Vector3 startPoint, Vector3 endPoint);

    public void Rotate(int rotateDir)
    {
        Debug.Log("rotate:" + rotateDir);
    }
    public virtual void Scale(int scaleFactor)
    {
        Debug.Log("scale:" + scaleFactor);
    }
    public virtual void Translate(int x, int y)
    {
        Debug.Log("Move:" + x + ", " + y);
    }
}
