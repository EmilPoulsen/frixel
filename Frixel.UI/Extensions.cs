﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frixel.Core.Geometry;
using M = System.Windows.Media;

namespace Frixel.UI
{
    public static class Extensions
    {
        public static System.Windows.Shapes.Line ToCanvasLine(this Line2d line, M.Brush color, double thickness = 2){
            var windowsLine = new System.Windows.Shapes.Line();
            windowsLine.X1 = line.Start.X;
            windowsLine.X2 = line.End.X;
            windowsLine.Y1 = line.Start.Y;
            windowsLine.Y2 = line.End.Y;
            windowsLine.Stroke = color;
            windowsLine.StrokeThickness = thickness;
            return windowsLine;
        }

        public static System.Windows.Shapes.Rectangle ToCanvasRect(this Point2d point, double size, M.Brush color, double thickness = 2)
        {
            var windowsRect = new System.Windows.Shapes.Rectangle();
            windowsRect.Width = size;
            windowsRect.Height = size;
            windowsRect.Stroke = color;
            windowsRect.Fill = new M.SolidColorBrush(M.Color.FromArgb(0, 0, 0, 0));
            windowsRect.Margin = new System.Windows.Thickness(
                point.X - size / 2,
                point.Y - size / 2,
                0, 0);
            windowsRect.StrokeThickness = thickness;
            return windowsRect;
        }
    }
}
