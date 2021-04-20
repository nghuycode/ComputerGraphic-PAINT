using UnityEngine;
using System.Collections.Generic;
using static EnumConst;
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

    public void CreateAShape(DrawType type, Vector3 startPoint, Vector3 endPoint)
    {
        switch (type)
        {
            case DrawType.Line:
                Line line = new Line(startPoint, endPoint);
                list.Add(line);
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
            case DrawType.Circle:
                Circle circle = new Circle(startPoint, endPoint);
                list.Add(circle);
                break;
            case DrawType.Ellipse:
                Ellipse eclipse = new Ellipse(startPoint, endPoint);
                list.Add(eclipse);
                break;
            case DrawType.Plus:
                Plus plus = new Plus(startPoint, endPoint);
                list.Add(plus);
                break;
            case DrawType.Minus:
                Minus minus = new Minus(startPoint, endPoint);
                list.Add(minus);
                break;
            case DrawType.Multiply:
                Multiply multiply = new Multiply(startPoint, endPoint);
                list.Add(multiply);
                break;
            case DrawType.Divide:
                Divide divide = new Divide(startPoint, endPoint);
                list.Add(divide);
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
