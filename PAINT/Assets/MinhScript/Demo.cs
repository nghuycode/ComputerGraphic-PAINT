using UnityEngine;
using System.Collections.Generic;
using static Enums;
public class Demo : MonoBehaviour
{
    List<Shape> list = new List<Shape>();
    public Material mat;
    public static Demo instance;

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
        foreach (Shape shape in list)
        {
            shape.Draw();
        }
        GL.PopMatrix();
    }

    public void CreateAShape(ShapeTypes type, Vector3 startPoint, Vector3 endPoint)
    {
        switch (type)
        {
            case ShapeTypes.Line:
                Line line = new Line(startPoint, endPoint);
                list.Add(line);
                break;
            case ShapeTypes.EquilTriangle:
                EquilTriangles equilTriangle = new EquilTriangles(startPoint, endPoint);
                list.Add(equilTriangle);
                break;
            case ShapeTypes.RightTriangle:
                RightTriangle rightTriangle = new RightTriangle(startPoint, endPoint);
                list.Add(rightTriangle);
                break;
            case ShapeTypes.Rectangle:
                Rectangle rectangle = new Rectangle(startPoint, endPoint);
                list.Add(rectangle);
                break;
            case ShapeTypes.Square:
                Square square = new Square(startPoint, endPoint);
                list.Add(square);
                break;
            case ShapeTypes.Circle:
                Circle circle = new Circle(startPoint, endPoint);
                list.Add(circle);
                break;
        }
        
    }

    public void UpdateAShape(Vector3 startPoint, Vector3 endPoint)
    {
        if (list.Count == 0) return;
        list[list.Count - 1].Update(startPoint, endPoint);
    }

    public void FinishAShape()
    {
        //Not implement yet
    }
}
