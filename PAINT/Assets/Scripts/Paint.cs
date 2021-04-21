using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : Shape
{
    public static Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    static Color[,] colors = new Color[Screen.width, Screen.height];
    List<Line> lines = new List<Line>();
    struct Point{
        public int x,y;
        public Point(float x, float y){
            this.x = (int)x;
            this.y = (int)y;
        }
    }
    struct Node{
        public Point point;
        public bool type;
        public Node(Point point, bool type){
            this.point = point;
            this.type = type;
        }
    }
    public Paint(Vector3 startPoint, Vector3 endPoint, Color paintColor){
        Point start = new Point(startPoint.x, startPoint.y);
        Color color = texture.GetPixel(start.x, start.y);

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(){point = start, type = true});

        void addNode(int x, int y, bool type){
            Node node = new Node(){point =new Point(x, y), type = type};
            colors[x, y] = paintColor;
            queue.Enqueue(node);
        }

        bool check(int x, int y){
            return (x >= 0) && (y >= 0) && (x < Screen.width) && (y < Screen.height) && (texture.GetPixel(x, y) == color) && (colors[x, y] != paintColor);
        }

        while (queue.Count > 0){
            Node x = queue.Dequeue();
            Point dau = x.point;
            Point cuoi = x.point;
            if (x.type){
                while (check(dau.x -1, dau.y)) addNode(--dau.x, dau.y, !x.type);
                while (check(cuoi.x + 1, cuoi.y)) addNode(++cuoi.x, cuoi.y, !x.type);
            }
            else{
                while (check(dau.x, dau.y - 1)) addNode(dau.x, --dau.y, !x.type);
                while (check(cuoi.x, cuoi.y + 1)) addNode(cuoi.x, ++cuoi.y, !x.type);
            }   
            if ((dau.x != x.point.x) || (dau.y != x.point.y) || (cuoi.x != x.point.x) || (cuoi.y != x.point.y))
                lines.Add(new Line(new Vector3(dau.x, dau.y, 0), new Vector3(cuoi.x, cuoi.y, 0), paintColor));
        }
    }
    public override void Update(Vector3 startPoint, Vector3 endPoint)
    {
        

    }
    override public void Draw(){
        foreach(Line line in lines){
            line.Draw();
        }
    }
}
