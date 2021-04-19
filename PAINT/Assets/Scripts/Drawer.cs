using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public enum DrawingType{
        Line, 
        Rectangle
    }
    
    public static Drawer Instance;
    public void Awake(){
        Instance = this;
    }
    bool isDrawing = false;
    DrawingType drawingType;
    List<Shape> shapes = new List<Shape>();
    public Material mat;
    private void OnPostRender(){
        GL.Clear(true, true, Color.black);
        GL.PushMatrix();
        mat.SetPass(0);
        foreach (Shape shape in shapes){
            shape.drawShape();
        }
        if (drawingType == DrawingType.Line && isDrawing)
            ShapeRepository.Line.drawShape(InputHandler.Instance.startTouchPos, InputHandler.Instance.currentTouchPos);
        GL.PopMatrix();
    }

    public void StartDrawing(DrawingType drawing){
        drawingType = drawing;
        isDrawing = true;
    }

    public void StopDrawing(){
        isDrawing = false;
        if (drawingType == DrawingType.Line){
            Line line = new Line(InputHandler.Instance.startTouchPos, InputHandler.Instance.currentTouchPos);
            shapes.Add(line);
        }
    }
}
