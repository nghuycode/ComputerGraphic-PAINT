using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumConst 
{
    public enum DrawType 
    {
       Line, Isosceles, Equilateral, Rectangle, Square, Circle, Eclipse, Pentagon, Hexagon, Arrow, Star, Plus, Minus, Multiply, Divide    
    }
    public enum ColorType 
    {
        Green, Red, Yellow, Blue, Purple
    }
    public static Color[] ColorsMap = new Color[5]{Color.green, Color.red, Color.yellow, Color.blue, Color.magenta};
    public enum MenuType 
    {
        Line, Triangle,  Quadrangle, Oval, Polygon, Other, Math, Color
    }
}
