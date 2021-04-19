﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GLDemo : MonoBehaviour
{
    public Material lineMaterial;
    private void OnPostRender() {
        GL.PushMatrix();
        lineMaterial.SetPass(0);
        // GL.LoadOrtho();

        // Draw lines
        GL.Begin(GL.TRIANGLES);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(0, 100, 0);
        GL.Vertex3(100, 0, 0);
        GL.End();
        GL.PopMatrix();
    }
}
