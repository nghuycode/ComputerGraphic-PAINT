using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public readonly int[] dx = { 1, 0, -1, 0 };
    public readonly int[] dy = { 0, 1, 0, -1 };
    public static ColorManager instance;
    public Texture2D texture = null;
    List<List<int>> mark;
    int value;
    private void Awake()
    {
        instance = this;
        mark = new List<List<int>>();
        for (int i = 0;i < Screen.width;i++)
        {
            List<int> list = new List<int>();
            mark.Add(list);
            for (int j = 0;j < Screen.height;j++)
            {
                mark[i].Add(0);
            }
        }


    }
    struct Point
    {
        public int x, y;
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }   

    public void TakeScreenShot()
    {
        texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();
    }
    public void Coloring(int x, int y, Color color)
    {
        ++value;
        Point startPoint = new Point(x, y);

        int cnt = 0;
        Queue<Point> queue = new Queue<Point>();
        Color startColor = texture.GetPixel(x, y);        

        if (startColor != color)
        {
            queue.Enqueue(startPoint);
            Putpixel(x, y, color);
            mark[x][y] = value;
        }
        while (queue.Count > 0)
        {
            ++cnt;
            Point curPoint = queue.Peek();
            queue.Dequeue();
            x = curPoint.x;
            y = curPoint.y;
            for (int i = 0;i < 4;i++)
            {
                int nx, ny;
                nx = x + dx[i];
                ny = y + dy[i];
                if(Check(nx,ny) && (mark[nx][ny] != value) && (texture.GetPixel(nx,ny) == startColor))
                {
                    mark[nx][ny] = value;
                    Putpixel(nx, ny, color);
                    Point newPoint = new Point(nx, ny);
                    queue.Enqueue(newPoint);
                }
            }
        }
        Debug.Log(cnt);

    }

    bool Check(int x,int y)
    {
        return ((x >= 0) && (y >= 0) && (x < Screen.width) && (y < Screen.height));
    }

    public void Putpixel(int x,int y, Color color)
    {
        texture.SetPixel(x, y, color);
    }


}
