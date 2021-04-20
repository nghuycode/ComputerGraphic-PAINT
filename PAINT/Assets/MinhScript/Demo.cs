using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static EnumConst;
public class Demo : MonoBehaviour
{
    List<Shape> list = new List<Shape>();
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
        if (ColorManager.instance.texture != null)
        {
            GL.PushMatrix();
            mat.SetPass(0);
            GL.LoadPixelMatrix();
            DrawSceneBackground();
            GL.Color(Color.white);
            foreach (Shape shape in list)
            {
                shape.Draw();

            }
            GL.PopMatrix();
        }
        if ((wasColor == true) || (isBegin == true) || (wasDraw == true))
        {
            isBegin = false;
            ColorManager.instance.TakeScreenShot();
            wasColor = false;
            wasDraw = false;
        }

    }

    public void CreateAShape(DrawType type, Vector3 startPoint, Vector3 endPoint)
    {
        Debug.Log(type);
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
        Texture2D texture = ColorManager.instance.texture;
        GL.Begin(GL.LINES);        
        for (int i = 0;i < Screen.width;i++)
            for (int j = 0;j < Screen.height;j++)
            {
                GL.Color(texture.GetPixel(i, j));
                GL.Vertex3(i, j, 0);
                GL.Vertex3(i + 1, j, 0);
            }
        GL.End();
    }

   
}
