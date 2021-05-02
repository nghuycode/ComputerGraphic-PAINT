using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static EnumConst;
public class Demo : MonoBehaviour
{
    public GameObject Shape;
    public static List<Shape> list = new List<Shape>();
    public Material mat;
    public static Demo instance;
    public bool wasColor = false;
    bool isBegin = true;
    bool wasDraw = false;
    private void Awake()
    {
        instance = this;
        
    }




    private void OnPostRender()
    {
        GL.PushMatrix();
            mat.SetPass(0);
            GL.LoadPixelMatrix();
            DrawSceneBackground();
            GL.Color(Color.white);
            Debug.Log(list.Count);
            foreach (Shape shape in list)
            {
                shape.Draw();
            }
        GL.PopMatrix();
        // if (ColorManager.instance.texture != null)
        // {
            
        // }
        // if ((wasColor == true) || (isBegin == true) || (wasDraw == true))
        // {
        //     isBegin = false;
        //     //ColorManager.instance.TakeScreenShot();
        //     wasColor = false;
        //     wasDraw = false;
        // }

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
            case DrawType.Pentagon:
                Pentagon pentagon = new Pentagon(startPoint, endPoint);
                list.Add(pentagon);
                break;
            case DrawType.Hexagon:
                Hexagon hexagon = new Hexagon(startPoint, endPoint);
                list.Add(hexagon);
                break;
            case DrawType.Star:
                Star star = new Star(startPoint, endPoint);
                list.Add(star);
                break;
            case DrawType.Arrow:
                Arrow arrow = new Arrow(startPoint, endPoint);
                list.Add(arrow);
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
        wasDraw = true;
    }

    public void Coloring(int x,int y, Color color)
    {
        ColorManager.instance.Coloring(x, y, color);
        wasColor = true;
    }
    public void DrawSceneBackground()
    {
        // Texture2D texture = ColorManager.instance.texture;
        // GL.Begin(GL.LINES);        
        // for (int i = 0;i < Screen.width;i++)
        //     for (int j = 0;j < Screen.height;j++)
        //     {
        //         GL.Color(texture.GetPixel(i, j));
        //         GL.Vertex3(i, j, 0);
        //         GL.Vertex3(i + 1, j, 0);
        //     }
        // GL.End();
    }

   
}
