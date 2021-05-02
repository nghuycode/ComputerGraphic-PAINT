using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static EnumConst;
public class Demo : MonoBehaviour
{
    List<Polygon> list = new List<Polygon>();
    public Material mat;
    public static Demo instance;
    public GameObject currentMenu = null;
    public Color currentColor;
    public GameObject mainMenu;
    int currentShapeId = -1;

    private void Awake()
    {
        instance = this;
 
    }


    private void OnPostRender()
    {

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadPixelMatrix();
        GL.Color(Color.white);

        foreach (Polygon shape in list)
        {
            shape.Draw();
        }
        
        GL.PopMatrix();
    }


    public void CreateAShape(DrawType type, Vector3 startPoint, Vector3 endPoint)
    {
        switch (type)
        {
            case DrawType.Transformation:
            
                break;
            case DrawType.Equilateral:
                EquilTriangles equilTriangle = new EquilTriangles(startPoint, endPoint);
                list.Add(equilTriangle);
                break;
            case DrawType.RightTriangle:
                RightTriangle rightTriangle = new RightTriangle(startPoint, endPoint);
                list.Add(rightTriangle);
                break;
            case DrawType.Rectangle:
                Rectangle rectangle = new Rectangle(startPoint, endPoint);
                list.Add(rectangle);
                break;
            case DrawType.Square:
                Square square = new Square(startPoint, endPoint);
                list.Add(square);
                break;
            case DrawType.Pentagon:
                Pentagon pentagon = new Pentagon(startPoint, endPoint);
                list.Add(pentagon);
                break;
            case DrawType.Hexagon:
                Hexagon hexagon = new Hexagon(startPoint, endPoint);
                list.Add(hexagon);
                break;
            case DrawType.Plus:
                Plus plus = new Plus(startPoint, endPoint);
                list.Add(plus);
                break;
            case DrawType.Multiply:
                Multiply multiply = new Multiply(startPoint, endPoint);
                list.Add(multiply);
                break;
        }
    }

    public void UpdateAShape(Vector3 startPoint, Vector3 endPoint)
    {
        if (list.Count == 0) return;
        list[list.Count - 1].Update(startPoint, endPoint);
    }

    public void TranslateCurrentShape(Vector3 vector)
    {
        if(currentShapeId >= 0)
            list[currentShapeId].Translate(vector);
       
    }

    public void ScaleCurrentShape(Vector3 vector)
    {
        if (currentShapeId >= 0)
            list[currentShapeId].Scale(vector);
    }

    public void RotateCurrentShape(float angle)
    {
        if (currentShapeId >= 0)
            list[currentShapeId].Rotation(angle);
    }

    public void ChangeCurrentShapeId(Vector3 mousePosition)
    {
        float minDis = 5000000;
        if (currentShapeId >= 0)
            list[currentShapeId].UnSelect();
        for (int i = 0;i < list.Count;i++)
            if(list[i].DistanceFromCenter(mousePosition) < minDis)
            {
                minDis = list[i].DistanceFromCenter(mousePosition);
                currentShapeId = i;
            }
        if (currentShapeId >= 0)
            list[currentShapeId].Select();


    }

  
    

   
}
