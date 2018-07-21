﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frixel.Core.Geometry;

namespace Frixel.Core
{
    public class Pixel
    {
        public readonly PixelState State;
        public readonly int TopLeft;
        public readonly int TopRight;
        public readonly int BottomRight;
        public readonly int BottomLeft;

        public Pixel(int topLeft, int topRight, int botLeft, int botRight, PixelState state)
        {
            this.TopLeft = topLeft;
            this.TopRight = topRight;
            this.BottomLeft = botLeft;
            this.BottomRight = botRight;
            this.State = state;
        }

        public List<Edge> GetBracing()
        {
            switch (State)
            {
                case PixelState.Moment:
                    var x1 = new Edge(this.TopLeft, this.BottomRight);
                    var x2 = new Edge(this.TopRight, this.BottomLeft);
                    return new List<Edge>() { x1, x2 };
                case PixelState.None:
                    return new List<Edge>();
            };
            return new List<Edge>();
        }
    }

    public class Edge
    {
        public int Start;
        public int End;

        public Edge(int s, int e)
        {
            this.Start = s;
            this.End = e;
        }

    }

    public class PixelStructure
    {
        public List<Point2d> Nodes;
        public List<Edge> Edges;
        public List<Pixel> Pixels;

        public PixelStructure() { }

        public List<Line2d> GetLines()
        {
            return Edges.Select(e =>
            {
                return new Line2d(Nodes[e.Start], Nodes[e.End]);
            }).ToList();
        }
    }

    public enum PixelState
    {
        None,
        Moment
    }
}