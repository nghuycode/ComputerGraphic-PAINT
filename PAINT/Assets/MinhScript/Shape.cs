using UnityEngine;

public abstract class Shape 
{   
    public abstract void Draw();
    public abstract void Update(Vector3 startPoint, Vector3 endPoint);

    public Vector3 sPoint;
    public Vector3 ePoint;
    public void Init(Vector3 startPoint, Vector3 endPoint){
        sPoint = startPoint;
        ePoint = endPoint;
    }
    public void Rotate(int dir) {
        Vector3 mid = (sPoint + ePoint) / 2;
        Update(sPoint, ePoint);
    }
    public void Translate(int x, int y){
        this.sPoint = new Vector3(sPoint.x + x, sPoint.y + y, sPoint.z);
        this.ePoint = new Vector3(ePoint.x + x, ePoint.y + y, ePoint.z);
        Update(sPoint, ePoint);
    }
    public void Scale(int Scale){
        Vector3 distance = ePoint - sPoint;
        this.sPoint = sPoint - distance * Scale / 100; 
        this.ePoint = sPoint + distance * Scale / 100; 
        Update(sPoint, ePoint);
    }

}
