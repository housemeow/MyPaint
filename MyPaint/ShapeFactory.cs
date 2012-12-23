using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPaint;

namespace MyPaint
{
    public class ShapeFactory
    {
        //a factory method to get a shape
        public static Shape GetShape(PaintModel.ShapeEnum shapeType)
        {
            const String NAMESPACE = "MyPaint.";
            String className = shapeType.ToString();
            Type type = Type.GetType(NAMESPACE + className);
            Shape shape = (Shape)Activator.CreateInstance(type);
            return shape;
        }
    }
}
