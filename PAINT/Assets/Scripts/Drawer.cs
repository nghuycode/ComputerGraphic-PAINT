using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{   
    public static Drawer Instance;
    public void Awake(){
        Instance = this;
    }
    static EnumConst.DrawType drawingType;
    bool isDrawing = false;
    List<Shape> shapes = new List<Shape>();
    public Material mat;
    private void OnPostRender(){
        GL.Clear(true, true, Color.white);
        GL.PushMatrix();
        mat.SetPass(0);
        foreach (Shape shape in shapes){
            shape.drawShape();
        }
        if (isDrawing){
            if (drawingType == EnumConst.DrawType.Line)
                ShapeRepository.Line.drawShape(InputHandler.Instance.startTouchPos, InputHandler.Instance.currentTouchPos);
            if (drawingType == EnumConst.DrawType.Rectangle)
                ShapeRepository.Rectangle.drawShape(InputHandler.Instance.startTouchPos, InputHandler.Instance.currentTouchPos);
        }
        GL.PopMatrix();
    }

    public void StartDrawing(EnumConst.DrawType drawing){
        drawingType = drawing;
        isDrawing = true;
    }

    public void StopDrawing(){
        isDrawing = false;
        if (drawingType == EnumConst.DrawType.Line){
            Line line = new Line();
            shapes.Add(line);
        }
        if (drawingType == EnumConst.DrawType.Rectangle){
            Rectangle rectangle = new Rectangle();
            shapes.Add(rectangle);
        }
    }
}
