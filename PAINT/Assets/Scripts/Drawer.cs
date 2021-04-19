using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Material mat;
    private void OnPostRender(){
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        // ShapeRepository.MyLine.drawShape(new Vector3(0,0,0), new Vector3(0,5,0));
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(new Vector3(0,0,0));
        GL.Vertex(new Vector3(0,5,0));
        GL.End();
        GL.PopMatrix();
    }
}