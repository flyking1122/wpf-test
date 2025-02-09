// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;
using Avalon.Test.CoreUI;
using System.Windows;
using System.Windows.Controls;
using Avalon.Test.CoreUI.Common;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Collections;
using Avalon.Test.CoreUI.Parser;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

using Microsoft.Test.Serialization.CustomElements;

namespace Avalon.Test.CoreUI.Serialization
{
    /// <summary>
    /// Verify xaml files for Graphics
    /// Author: Microsoft
    /// </summary>
    public class GraphicsVerifiers
    {

        /// <summary>
        /// Verify ImageBrushesGraphics.xaml
        /// </summary>
        public static void ImageBrushesVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;
            CoreLogger.LogStatus("Verifying image Brush ...");
            FrameworkElement fe = uie as FrameworkElement;
            Rectangle Rectangle1 = fe.FindName("Rectangle1") as Rectangle;
            ImageBrush iBrush = Rectangle1.Fill as ImageBrush;
            VerifyElement.VerifyBool(null == iBrush, false);
            ImageSource iSource = iBrush.ImageSource;
            VerifyElement.VerifyString(iSource.ToString(), "pack://siteoforigin:,,,/puppies.jpg");
        }
        
        /// <summary>
        /// Verification routine for DrawingBrushesGraphics.xaml.
        /// </summary>
        public static void DrawingBrushesVerify(UIElement uie)
        {
          CoreLogger.LogStatus("Verifying drawing Brush: Ellipse2 ...");
          Path ellipse2 = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Ellipse2");
          VerifyElement.VerifyBool(null == ellipse2, false);

          DrawingBrush myDrawingBrush = ellipse2.Fill as DrawingBrush;
          VerifyElement.VerifyBool(null == myDrawingBrush, false);
          VerifyElement.VerifyInt(((DrawingGroup)myDrawingBrush.Drawing).Children.Count, 2);
          GeometryDrawing drawing1 = ((DrawingGroup)myDrawingBrush.Drawing).Children[0] as GeometryDrawing;
          VerifyElement.VerifyBool(null == drawing1, false);
          GeometryDrawing drawing2 = ((DrawingGroup)myDrawingBrush.Drawing).Children[1] as GeometryDrawing;
          VerifyElement.VerifyBool(null == drawing2, false);

          DrawingBrush innerBrush = drawing2.Brush as DrawingBrush;
          VerifyElement.VerifyInt(((DrawingGroup)innerBrush.Drawing).Children.Count, 3);
        }
        

        /// <summary>
        /// Verification routine for SolidColorBrushesGraphics.xaml.
        /// </summary>
        public static void SolidColorBrushesVerify(UIElement uie)
        {
            //Verifying SolidColorBrush
            CoreLogger.LogStatus("Verifying SolidColorBrush ...");

            Polygon polygon1 = (Polygon)LogicalTreeHelper.FindLogicalNode(uie, "Polygon1");

            VerifyElement.VerifyBool(null == polygon1, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)polygon1).Stroke)).Color, Colors.Black);
            VerifyElement.VerifyDouble(((Shape)polygon1).StrokeThickness, 2);
            VerifyElement.VerifyInt(polygon1.Points.Count, 6);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(400, 10)), true);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(450, 35)), true);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(450, 65)), true);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(400, 90)), true);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(350, 65)), true);
            VerifyElement.VerifyBool(polygon1.Points.Contains(new Point(350, 35)), true);
            
            SolidColorBrush solidColorBrush = ((Shape)polygon1).Fill as SolidColorBrush;

            VerifyElement.VerifyBool(null == solidColorBrush, false);
            VerifyElement.VerifyColor(solidColorBrush.Color, Colors.Green);
            VerifyElement.VerifyDouble(((Brush)solidColorBrush).Opacity, 0.7);
        }
        /// <summary>
        /// Verification routine for GradientBrushesGraphics.xaml.
        /// </summary>
        public static void GradientBrushesVerify(UIElement uie)
        {
            //Verifying image RadialGradienBrush
            CoreLogger.LogStatus("Verifying image RadialGradienBrush ...");
            FrameworkElement fe = uie as FrameworkElement;

            Path Ellipse1 = fe.FindName("Ellipse1") as Path;
            RadialGradientBrush rgBrush = ((Shape)Ellipse1).Fill as RadialGradientBrush;
            VerifyElement.VerifyBool(null == rgBrush, false);
            VerifyElement.VerifyDouble(rgBrush.Opacity, 0.5);
            GradientStopCollection stops = rgBrush.GradientStops;

            VerifyElement.VerifyInt(stops.Count, 3);
            GradientStop stop1 = stops[0];
            VerifyElement.VerifyBool(null == stop1, false);
            VerifyElement.VerifyColor(stop1.Color, Colors.Red);
            VerifyElement.VerifyDouble(stop1.Offset, 0);

            GradientStop stop2 = stops[1];
            VerifyElement.VerifyBool(null == stop2, false);
            VerifyElement.VerifyColor(stop2.Color, Colors.Yellow);
            VerifyElement.VerifyDouble(stop2.Offset, 1);

            GradientStop stop3 = stops[2];
            VerifyElement.VerifyBool(null == stop3, false);
            VerifyElement.VerifyColor(stop3.Color, Colors.Blue);
            VerifyElement.VerifyDouble(stop3.Offset, 0.5);

            CoreLogger.LogStatus("Verifying image LinearGradienBrush ...");

            Line Line1 = fe.FindName("Line1") as Line;
            LinearGradientBrush lgBrush = ((Shape)Line1).Stroke as LinearGradientBrush;
            VerifyElement.VerifyBool(null == lgBrush, false);
            VerifyElement.VerifyDouble(lgBrush.Opacity, 0.5);
            
            stops = lgBrush.GradientStops;
            VerifyElement.VerifyBool(null == stops, false);

            VerifyElement.VerifyInt(stops.Count, 4);

            stop1 = stops[0];
            VerifyElement.VerifyBool(null == stop1, false);
            VerifyElement.VerifyColor(stop1.Color, Colors.Green);
            VerifyElement.VerifyDouble(stop1.Offset, 0);

            stop2 = stops[1];
            VerifyElement.VerifyBool(null == stop2, false);
            VerifyElement.VerifyColor(stop2.Color, Colors.Yellow);
            VerifyElement.VerifyDouble(stop2.Offset, 1);

            stop3 = stops[2];
            VerifyElement.VerifyBool(null == stop3, false);
            VerifyElement.VerifyColor(stop3.Color, Colors.Purple);
            VerifyElement.VerifyDouble(stop3.Offset, 0.5);

            GradientStop stop4 = stops[3];
            VerifyElement.VerifyBool(null == stop4, false);
            VerifyElement.VerifyColor(stop4.Color, Colors.White);
            VerifyElement.VerifyDouble(stop4.Offset, 0.2);
        }

        //Geometry:

        /// <summary>
        /// Verification method for CombinedGeometry in graphics
        /// Author: Microsoft
        /// </summary>
        public static void CombinedGeometryVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            Path path1 = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path1");

            VerifyElement.VerifyBool(null == path1, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Fill)).Color, Colors.Red);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Stroke)).Color, Colors.White);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeThickness, 3);

            CombinedGeometry myGeometries = path1.Data as CombinedGeometry;
            VerifyElement.VerifyBool(null == myGeometries, false);
            VerifyElement.VerifyInt((int)myGeometries.GeometryCombineMode, (int)GeometryCombineMode.Xor);

            RectangleGeometry rectangleGeometry1 = myGeometries.Geometry1 as RectangleGeometry;
            RectangleGeometry rectangleGeometry2 = myGeometries.Geometry2 as RectangleGeometry;

            VerifyElement.VerifyRect(rectangleGeometry1.Rect, new Rect(0, 0, 100, 100));
            VerifyElement.VerifyRect(rectangleGeometry2.Rect, new Rect(50, 50, 100, 100));

        }
        /// <summary>
        /// Verification method for PathGeometry in graphics
        /// Author: Microsoft
        /// </summary>
        public static void PathGeometryVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;
            CoreLogger.LogStatus("PathGeometry ...");

            Path path1 = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path1");

            VerifyElement.VerifyBool(null == path1, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Fill)).Color, Color.FromArgb(0x40, 0x00, 0xff, 0x00));
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Stroke)).Color, Colors.Yellow);

            PathGeometry myGeometry = path1.Data as PathGeometry;
            VerifyElement.VerifyBool(null == myGeometry, false);
            VerifyElement.VerifyInt((int)myGeometry.FillRule, (int)FillRule.EvenOdd);

            TranslateTransform myTranslateTransform = myGeometry.Transform as TranslateTransform;
            VerifyElement.VerifyBool(null == myTranslateTransform, false);
            VerifyElement.VerifyDouble(myTranslateTransform.X, 225);
            VerifyElement.VerifyDouble(myTranslateTransform.Y, 25);

            PathFigureCollection myPathFigureCollection = myGeometry.Figures;
            VerifyElement.VerifyBool(null == myPathFigureCollection, false);

            VerifyElement.VerifyInt(myPathFigureCollection.Count, 1);
            PathFigure myPathFigure = myPathFigureCollection[0];
            VerifyElement.VerifyBool(null == myPathFigure, false);
            VerifyElement.VerifyBool(myPathFigure.IsFilled, true);

            PathSegmentCollection myPathSegmentCollection = myPathFigure.Segments;
            VerifyElement.VerifyBool(null == myPathSegmentCollection, false);
            VerifyElement.VerifyInt(myPathSegmentCollection.Count, 7);

            LineSegment myLineSegment = myPathSegmentCollection[0] as LineSegment;
            VerifyElement.VerifyBool(null == myLineSegment, false);
            VerifyElement.VerifyPoint(myLineSegment.Point, new Point(100, 0));

            BezierSegment myBezierSegment = myPathSegmentCollection[1] as BezierSegment;
            VerifyElement.VerifyBool(null == myBezierSegment, false);
            VerifyElement.VerifyPoint(myBezierSegment.Point1, new Point(125, 25));
            VerifyElement.VerifyPoint(myBezierSegment.Point2, new Point(125, 75));
            VerifyElement.VerifyPoint(myBezierSegment.Point3, new Point(100, 100));

            QuadraticBezierSegment myQuadraticBezierSegment = myPathSegmentCollection[2] as QuadraticBezierSegment;
            VerifyElement.VerifyBool(null == myQuadraticBezierSegment, false);
            VerifyElement.VerifyPoint(myQuadraticBezierSegment.Point1, new Point(50, 50));
            VerifyElement.VerifyPoint(myQuadraticBezierSegment.Point2, new Point(0, 100));
            ArcSegment myArcSegment = myPathSegmentCollection[3] as ArcSegment;
            VerifyElement.VerifyBool(null == myArcSegment, false);
            VerifyElement.VerifyPoint(myArcSegment.Point, new Point(100, 150));
            VerifyElement.VerifySize(myArcSegment.Size, new Size(100, 100));
            VerifyElement.VerifyDouble(myArcSegment.RotationAngle, 45);
            VerifyElement.VerifyBool(myArcSegment.IsLargeArc, false);
            PolyLineSegment myPolyLineSegment = myPathSegmentCollection[4] as PolyLineSegment;
            VerifyElement.VerifyBool(null == myPolyLineSegment, false);
            PointCollection myPoints = myPolyLineSegment.Points;
            VerifyElement.VerifyBool(null == myPoints, false);
            VerifyElement.VerifyInt(myPoints.Count, 2);
            VerifyElement.VerifyPoint(myPoints[0], new Point(100, 175));
            VerifyElement.VerifyPoint(myPoints[1], new Point(0, 175));

        }
        /// <summary>
        /// Verification method for RectangleGeometry in graphics
        /// Author: Microsoft
        /// </summary>
        public static void RectangleGeometryVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;
            CoreLogger.LogStatus("RectangleGeometry ...");

            Path path = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path");

            VerifyElement.VerifyBool(null == path, false);

            RectangleGeometry myGeometry = path.Data as RectangleGeometry;

            VerifyElement.VerifyBool(null == myGeometry, false);
            VerifyElement.VerifyRect(myGeometry.Rect, new Rect(325, 225, 175, 75));
            VerifyElement.VerifyDouble(myGeometry.RadiusX, 10);
            VerifyElement.VerifyDouble(myGeometry.RadiusY, 5);
        }
        /// <summary>
        /// Verification method for EllipseGeometry in graphics
        /// Author: Microsoft
        /// </summary>
        public static void EllipseGeometryVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("RectangleGeometry ...");

            Path path = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path");

            VerifyElement.VerifyBool(null == path, false);

            EllipseGeometry myGeometry = path.Data as EllipseGeometry;

            VerifyElement.VerifyBool(null == myGeometry, false);
            VerifyElement.VerifyPoint(myGeometry.Center, new Point(60, 300));
            VerifyElement.VerifyDouble(myGeometry.RadiusX, 50);
            VerifyElement.VerifyDouble(myGeometry.RadiusY, 75);

        }
        /// <summary>
        /// Verification method for LineGeometry in graphics
        /// Author: Microsoft
        /// </summary>
        public static void LineGeometryVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("RectangleGeometry ...");
            
            Path path = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path");

            VerifyElement.VerifyBool(null == path, false);

            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path).Stroke)).Color, Colors.Orange);
            VerifyElement.VerifyDouble(((Shape)path).StrokeThickness, 20);
            VerifyElement.VerifyInt((int)((Shape)path).StrokeStartLineCap, (int)PenLineCap.Flat);
            VerifyElement.VerifyInt((int)((Shape)path).StrokeEndLineCap, (int)PenLineCap.Triangle);

            LineGeometry myGeometry = path.Data as LineGeometry;

            VerifyElement.VerifyBool(null == myGeometry, false);
            VerifyElement.VerifyPoint(myGeometry.StartPoint, new Point(350, 25));
            VerifyElement.VerifyPoint(myGeometry.EndPoint, new Point(500, 75));
        }

        /// <summary>
        /// Verification routine for ShapesGraphics.xaml.
        /// </summary>
        public static void ShapesVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Shapes Verify ...");

            CoreLogger.LogStatus("Verify Path ...");

            Path path = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path");

            VerifyElement.VerifyBool(null == path, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path).Stroke)).Color, Colors.Yellow);
            VerifyElement.VerifyDouble(((Shape)path).StrokeThickness, 6);
            StreamGeometry myStream = path.Data as StreamGeometry;
            PathGeometry myGeometry = PathGeometry.CreateFromGeometry(myStream);
            VerifyElement.VerifyBool(null == myGeometry, false);
            PathFigureCollection myFigures = myGeometry.Figures;
            VerifyElement.VerifyBool(null == myFigures, false);
            VerifyElement.VerifyInt(myFigures.Count, 1);
            PathFigure myFigure = myFigures[0];
            VerifyElement.VerifyBool(null == myFigure, false);
            PathSegmentCollection mySegments = myFigure.Segments;
            VerifyElement.VerifyBool(null == mySegments, false);
            VerifyElement.VerifyInt(mySegments.Count, 1);

            CoreLogger.LogStatus("Verify Ellipse ...");
            Path myEllipse = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Ellipse");
            VerifyElement.VerifyBool(null == myEllipse, false);
        }
        
        /// <summary>
        /// Verification routine for PathStrokeGraphics.xaml.
        /// </summary>
        public static void PathStrokeVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Path Stroke Verify ...");
            
            Path path1 = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path1");
            VerifyElement.VerifyBool(null == path1, false);

            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Stroke)).Color, Colors.Blue);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Fill)).Color, Color.FromRgb(0xff, 0x22, 0x0));

            VerifyElement.VerifyDouble(((Shape)path1).StrokeThickness, 10);
            VerifyElement.VerifyInt((int)((Shape)path1).StrokeStartLineCap, (int)PenLineCap.Round);
            VerifyElement.VerifyInt((int)((Shape)path1).StrokeEndLineCap, (int)PenLineCap.Flat);
            VerifyElement.VerifyInt((int)((Shape)path1).StrokeDashCap, (int)PenLineCap.Triangle);
            VerifyElement.VerifyInt((int)((Shape)path1).StrokeLineJoin, (int)PenLineJoin.Round);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashOffset, 1);
            VerifyElement.VerifyInt(((Shape)path1).StrokeDashArray.Count, 6);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[0], 1.5);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[1], 2.0);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[2], 3.0);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[3], 2.0);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[4], 1.0);
            VerifyElement.VerifyDouble(((Shape)path1).StrokeDashArray[5], 2.0);

            StreamGeometry myStream = path1.Data as StreamGeometry;
	    PathGeometry myGeometry = PathGeometry.CreateFromGeometry(myStream);
            VerifyElement.VerifyBool(null == myGeometry, false);
            PathFigureCollection myFigures = myGeometry.Figures;
            VerifyElement.VerifyBool(null == myFigures, false);
            VerifyElement.VerifyInt(myFigures.Count, 1);
            PathFigure myFigure = myFigures[0];
            VerifyElement.VerifyBool(null == myFigure, false);
            PathSegmentCollection mySegments = myFigure.Segments;
            VerifyElement.VerifyBool(null == mySegments, false);
            VerifyElement.VerifyInt(mySegments.Count, 1);

            myStream = path1.Clip as StreamGeometry;
	    myGeometry = PathGeometry.CreateFromGeometry(myStream);
            VerifyElement.VerifyBool(null == myGeometry, false);
            myFigures = myGeometry.Figures;
            VerifyElement.VerifyBool(null == myFigures, false);
            VerifyElement.VerifyInt(myFigures.Count, 1);
            myFigure = myFigures[0];
            VerifyElement.VerifyBool(null == myFigure, false);
            mySegments = myFigure.Segments;
            VerifyElement.VerifyBool(null == mySegments, false);
            VerifyElement.VerifyInt(mySegments.Count, 1);

            CoreLogger.LogStatus("Path Stroke Verify: path2 ...");
            Path path2 = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Path2");

            VerifyElement.VerifyBool(null == path1, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Stroke)).Color, Colors.Blue);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)path1).Fill)).Color, Color.FromRgb(0xff, 0x22, 0x0));

            CoreLogger.LogStatus("Path Stroke Verify: path2 - shape ...");    
            VerifyElement.VerifyDouble(((Shape)path2).StrokeThickness, 20);
            VerifyElement.VerifyInt((int)((Shape)path2).StrokeStartLineCap, (int)PenLineCap.Flat);
            VerifyElement.VerifyInt((int)((Shape)path2).StrokeEndLineCap, (int)PenLineCap.Triangle);
            VerifyElement.VerifyInt((int)((Shape)path2).StrokeDashCap, (int)PenLineCap.Round);
            VerifyElement.VerifyInt((int)((Shape)path2).StrokeLineJoin, (int)PenLineJoin.Bevel);
            VerifyElement.VerifyDouble(((Shape)path2).StrokeDashOffset, 0);
            VerifyElement.VerifyInt(((Shape)path2).StrokeDashArray.Count, 2);
            VerifyElement.VerifyDouble(((Shape)path2).StrokeDashArray[0], 1.0);
            VerifyElement.VerifyDouble(((Shape)path2).StrokeMiterLimit, 100);
            VerifyElement.VerifyDouble(((Shape)path2).StrokeDashArray[1], 2.0);

            CoreLogger.LogStatus("Path Stroke Verify: path2 - data ...");
            myStream = path2.Data as StreamGeometry;
	    myGeometry = PathGeometry.CreateFromGeometry(myStream);
            VerifyElement.VerifyBool(null == myGeometry, false);
            myFigures = myGeometry.Figures;
            VerifyElement.VerifyBool(null == myFigures, false);
            VerifyElement.VerifyInt(myFigures.Count, 1);
            myFigure = myFigures[0];
            VerifyElement.VerifyBool(null == myFigure, false);
            mySegments = myFigure.Segments;
            VerifyElement.VerifyBool(null == mySegments, false);
            VerifyElement.VerifyInt(mySegments.Count, 1);
        }
        /// <summary>
        /// Verification routine for LineStrokeGraphics.xaml.
        /// </summary>
        public static void LineStrokeVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Path Stroke Verify ...");
            
            Line line1 = (Line)LogicalTreeHelper.FindLogicalNode(uie, "Line1");
            VerifyElement.VerifyBool(null == line1, false);
            VerifyElement.VerifyDouble(line1.X1, 40);
            VerifyElement.VerifyDouble(line1.Y1, 250);
            VerifyElement.VerifyDouble(line1.X2, 250);
            VerifyElement.VerifyDouble(line1.Y2, 250);

            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)line1).Stroke)).Color, Colors.Red);
            VerifyElement.VerifyInt((int)((Shape)line1).StrokeStartLineCap, (int)PenLineCap.Flat);
            VerifyElement.VerifyInt((int)((Shape)line1).StrokeEndLineCap, (int)PenLineCap.Flat);
            VerifyElement.VerifyDouble(((Shape)line1).StrokeThickness, 45);
            
            Line line2 = (Line)LogicalTreeHelper.FindLogicalNode(uie, "Line2");

            VerifyElement.VerifyBool(null == line2, false);
            VerifyElement.VerifyDouble(line2.X1, 40);
            VerifyElement.VerifyDouble(line2.Y1, 350);
            VerifyElement.VerifyDouble(line2.X2, 250);
            VerifyElement.VerifyDouble(line2.Y2, 350);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)line2).Stroke)).Color, Colors.Purple);
            VerifyElement.VerifyInt((int)((Shape)line2).StrokeStartLineCap, (int)PenLineCap.Round);
            VerifyElement.VerifyInt((int)((Shape)line2).StrokeEndLineCap, (int)PenLineCap.Round);
            VerifyElement.VerifyDouble(((Shape)line2).StrokeThickness, 45);

            Line line3 = (Line)LogicalTreeHelper.FindLogicalNode(uie, "Line3");

            VerifyElement.VerifyBool(null == line3, false);
            VerifyElement.VerifyDouble(line3.X1, 40);
            VerifyElement.VerifyDouble(line3.Y1, 400);
            VerifyElement.VerifyDouble(line3.X2, 250);
            VerifyElement.VerifyDouble(line3.Y2, 400);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)line3).Stroke)).Color, Colors.Yellow);
            VerifyElement.VerifyInt((int)((Shape)line3).StrokeStartLineCap, (int)PenLineCap.Square);
            VerifyElement.VerifyInt((int)((Shape)line3).StrokeEndLineCap, (int)PenLineCap.Square);
            VerifyElement.VerifyDouble(((Shape)line3).StrokeThickness, 45);
        }

        
        /// <summary>
        /// Verification routine for PolygonStrokeGraphics.xaml.
        /// </summary>
        public static void PolygonStrokeVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Polygon Stroke Verify ...");
            
            Polygon myPolygon = (Polygon)LogicalTreeHelper.FindLogicalNode(uie, "Polygon");
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myPolygon).Stroke)).Color, Colors.Blue);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myPolygon).Fill)).Color, Colors.Red);
            VerifyElement.VerifyDouble(((Shape)myPolygon).StrokeThickness, 1);
            VerifyElement.VerifyInt((int)((Shape)myPolygon).StrokeLineJoin, (int)PenLineJoin.Miter);
            VerifyElement.VerifyDouble(((Shape)myPolygon).StrokeMiterLimit, 3);

            CoreLogger.LogStatus("Polygon Stroke Verify: Points ...");
            PointCollection myPoints = myPolygon.Points;

            VerifyElement.VerifyInt(myPoints.Count, 23);

            VerifyElement.VerifyPoint(myPoints[0], new Point(15, 10));
            VerifyElement.VerifyPoint(myPoints[1], new Point(50, 30));
            VerifyElement.VerifyPoint(myPoints[2], new Point(50, 25));
            VerifyElement.VerifyPoint(myPoints[3], new Point(45, 20));

            VerifyElement.VerifyPoint(myPoints[4], new Point(45, 15));
            VerifyElement.VerifyPoint(myPoints[5], new Point(50, 10));
            VerifyElement.VerifyPoint(myPoints[6], new Point(55, 10));
            VerifyElement.VerifyPoint(myPoints[7], new Point(60, 15));

            VerifyElement.VerifyPoint(myPoints[22], new Point(15, 10));
        }
        /// <summary>
        /// Verification routine for TransformDecoratorStrokeGraphics.xaml.
        /// </summary>
        public static void TransformDecoratorStrokeVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("TransformDecorator Stroke Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");
            VerifyElement.VerifyBool(null == myTransformDecorator, false);
            //VerifyElement.VerifyBool(myTransformDecorator.AffectsLayout, false);

            CoreLogger.LogStatus("TransformDecorator Stroke Verify : transform ...");
            TransformGroup myTransforms = myTransformDecorator.RenderTransform as TransformGroup;
            VerifyElement.VerifyBool(null == myTransforms, false);
            VerifyElement.VerifyInt(myTransforms.Children.Count, 2);

            TranslateTransform myTranslateTransform = myTransforms.Children[0] as TranslateTransform;
            VerifyElement.VerifyDouble(myTranslateTransform.X, 200);
            VerifyElement.VerifyDouble(myTranslateTransform.Y, 0);

            ScaleTransform myScaleTransform = myTransforms.Children[1] as ScaleTransform;
            VerifyElement.VerifyDouble(myScaleTransform.ScaleX, 2);
            VerifyElement.VerifyDouble(myScaleTransform.ScaleY, 2);
            CoreLogger.LogStatus("TransformDecorator Stroke Verify : polyline ...");

            Polyline myPolyline = (Polyline)LogicalTreeHelper.FindLogicalNode(uie, "Polyline");
            VerifyElement.VerifyBool(null == myPolyline, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myPolyline).Stroke)).Color, Colors.Blue);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myPolyline).Fill)).Color, Colors.Yellow);
            VerifyElement.VerifyDouble(((Shape)myPolyline).StrokeThickness, 3);
            VerifyElement.VerifyInt((int)((Shape)myPolyline).StrokeLineJoin, (int)PenLineJoin.Miter);
            VerifyElement.VerifyDouble(((Shape)myPolyline).StrokeMiterLimit, 1);

            CoreLogger.LogStatus("TransformDecorator Stroke Verify : points in Polyline ...");

            PointCollection myPoints = myPolyline.Points;

            VerifyElement.VerifyInt(myPoints.Count, 6);

            VerifyElement.VerifyPoint(myPoints[0], new Point(10, 10));
            VerifyElement.VerifyPoint(myPoints[1], new Point(60, 30));
            VerifyElement.VerifyPoint(myPoints[2], new Point(10, 50));
            VerifyElement.VerifyPoint(myPoints[3], new Point(60, 70));

            VerifyElement.VerifyPoint(myPoints[4], new Point(10, 90));
            VerifyElement.VerifyPoint(myPoints[5], new Point(30, 25));
        }
        
        /// <summary>
        /// Verification routine for SkewTransformGraphics.xaml.
        /// </summary>
        public static void SkewTransformVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Transform Skew Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");

            VerifyElement.VerifyBool(null == myTransformDecorator, false);
            CoreLogger.LogStatus("TransformDecorator Stroke Verify : transform ... " + myTransformDecorator.LayoutTransform.GetType().Name);

            TransformGroup myTransforms = myTransformDecorator.LayoutTransform as TransformGroup;
            VerifyElement.VerifyBool(null == myTransforms.Children, false);
            VerifyElement.VerifyInt(myTransforms.Children.Count, 2);

            CoreLogger.LogStatus("Transform type:  " + myTransforms.Children[0].GetType().Name);

            SkewTransform myTransform = myTransforms.Children[0] as SkewTransform;
            CoreLogger.LogStatus("Anglex:  " + myTransform.AngleX + "Angley:  " + myTransform.AngleY + "Centerx: " + myTransform.CenterX + "Centery: " + myTransform.CenterY);

            VerifyElement.VerifyBool(null == myTransform, false);

            VerifyElement.VerifyDouble(myTransform.AngleY, -20);

            CoreLogger.LogStatus("Second trandform:  " + myTransforms.Children[1].GetType().Name);
            SkewTransform myTransform2 = myTransforms.Children[1] as SkewTransform;

            CoreLogger.LogStatus("Anglex:  " + myTransform2.AngleX + "Angley:  " + myTransform2.AngleY + "Centerx: " + myTransform2.CenterX + "Centery: " + myTransform2.CenterY);

            VerifyElement.VerifyBool(null == myTransform2, false);
            VerifyElement.VerifyDouble(myTransform2.AngleX, -20);
            CoreLogger.LogStatus("Verify Rectangle ...");
            Rectangle myRectangle = (Rectangle)LogicalTreeHelper.FindLogicalNode(uie, "Rectangle");
            VerifyElement.VerifyBool(null == myRectangle, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myRectangle).Stroke)).Color, Colors.Red);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myRectangle).Fill)).Color, Colors.Pink);
            VerifyElement.VerifyDouble(((Shape)myRectangle).StrokeThickness, 3);
            VerifyElement.VerifyDouble(myRectangle.Width, 150);
            VerifyElement.VerifyDouble(myRectangle.Height, 50);
            VerifyElement.VerifyDouble(Canvas.GetTop(myRectangle), 10);
            VerifyElement.VerifyDouble(Canvas.GetLeft(myRectangle), 5);
        }
        /// <summary>
        /// Verification routine for ScalingTransformGraphics.xaml.
        /// </summary>
        public static void ScalingTransformVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Transform Scale Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");

            VerifyElement.VerifyBool(null == myTransformDecorator, false);
            CoreLogger.LogStatus("Transform Scale Verify : transform ...");

            ScaleTransform myTransform = myTransformDecorator.LayoutTransform as ScaleTransform;

            VerifyElement.VerifyDouble(myTransform.ScaleX, 2);
            VerifyElement.VerifyDouble(myTransform.ScaleY, 2);
            CoreLogger.LogStatus("Verify Rectangle ...");

            Path myEllipse = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Ellipse");

            VerifyElement.VerifyBool(null == myEllipse, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myEllipse).Stroke)).Color,
                Color.FromArgb(0xaa, 0x33, 0xff, 0x33));
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myEllipse).Fill)).Color, Colors.Yellow);
            VerifyElement.VerifyDouble(((Shape)myEllipse).StrokeThickness, 3);
        }

        /// <summary>
        /// Verification routine for RotateTransformGraphics.xaml.
        /// </summary>
        public static void RotateTransformVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Transform Scale Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");
            VerifyElement.VerifyBool(null == myTransformDecorator, false);
           
            CoreLogger.LogStatus("Transform Scale Verify : transform ...");

            RotateTransform myTransform = myTransformDecorator.RenderTransform as RotateTransform;

            VerifyElement.VerifyDouble(myTransform.Angle, 25);
            Line line1 = (Line)LogicalTreeHelper.FindLogicalNode(uie, "Line");

            VerifyElement.VerifyBool(null == line1, false);
            VerifyElement.VerifyDouble(line1.X1, 450);
            VerifyElement.VerifyDouble(line1.Y1, 50);
            VerifyElement.VerifyDouble(line1.X2, 55);
            VerifyElement.VerifyDouble(line1.Y2, 340);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)line1).Stroke)).Color, Colors.Yellow);
            VerifyElement.VerifyDouble(((Shape)line1).StrokeThickness, 20);
        }
        /// <summary>
        /// Verification routine for TranslatingTransformGraphics.xaml.
        /// </summary>
        public static void TranslatingTransformVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("TransformDecorator Stroke Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");

            VerifyElement.VerifyBool(null == myTransformDecorator, false);
            //VerifyElement.VerifyBool(myTransformDecorator.AffectsLayout, false);
            CoreLogger.LogStatus("TransformDecorator Stroke Verify : transform ...");

            TranslateTransform myTransform = myTransformDecorator.RenderTransform as TranslateTransform;

            VerifyElement.VerifyBool(null == myTransform, false);

            VerifyElement.VerifyDouble(myTransform.X, 250);
            VerifyElement.VerifyDouble(myTransform.Y, 50);

            Path myEllipse = (Path)LogicalTreeHelper.FindLogicalNode(uie, "Ellipse");
            VerifyElement.VerifyBool(null == myEllipse, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myEllipse).Stroke)).Color, Colors.Yellow);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myEllipse).Fill)).Color, Colors.Purple);
            VerifyElement.VerifyDouble(((Shape)myEllipse).StrokeThickness, 3);
            EllipseGeometry pathData = myEllipse.Data as EllipseGeometry;
            VerifyElement.VerifyBool(null == pathData, false);
            VerifyElement.VerifyDouble(pathData.Bounds.Left, 125);
            VerifyElement.VerifyDouble(pathData.Bounds.Right, 175);
            VerifyElement.VerifyDouble(pathData.Bounds.Top, 25);
            VerifyElement.VerifyDouble(pathData.Bounds.Bottom, 75);
            
        }
        /// <summary>
        /// Verification routine for TransformGroupTransformsGraphics.xaml.
        /// </summary>
        public static void TransformGroupTransformVerify(UIElement uie)
        {
            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("TransformDecorator Stroke Verify ...");
            
            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");

            VerifyElement.VerifyBool(null == myTransformDecorator, false);
            //VerifyElement.VerifyBool(myTransformDecorator.AffectsLayout, false);
            CoreLogger.LogStatus("Transform Collection Verify : transform ...");

            TransformGroup myTransforms = myTransformDecorator.RenderTransform as TransformGroup;

            VerifyElement.VerifyBool(null == myTransforms.Children, false);
            VerifyElement.VerifyInt(myTransforms.Children.Count, 6);

            CoreLogger.LogStatus("Transform 1:  " + myTransforms.Children[0].GetType().Name);

            TranslateTransform myTransform1 = myTransforms.Children[0] as TranslateTransform;
            VerifyElement.VerifyBool(null == myTransform1, false);
            VerifyElement.VerifyDouble(myTransform1.X, 10);
            VerifyElement.VerifyDouble(myTransform1.Y, 10);

            CoreLogger.LogStatus("Transform 2:  " + myTransforms.Children[1].GetType().Name);

            ScaleTransform myTransform2 = myTransforms.Children[1] as ScaleTransform;
            VerifyElement.VerifyBool(null == myTransform2, false);
            VerifyElement.VerifyDouble(myTransform2.ScaleX, 1.5);
            VerifyElement.VerifyDouble(myTransform2.ScaleY, 0.75);

            CoreLogger.LogStatus("Transform 3:  " + myTransforms.Children[2].GetType().Name);
            SkewTransform myTransform3 = myTransforms.Children[2] as SkewTransform;
            VerifyElement.VerifyBool(null == myTransform3, false);
            VerifyElement.VerifyDouble(((SkewTransform)myTransform3).AngleX, 1.5);
            VerifyElement.VerifyDouble(((SkewTransform)myTransform3).AngleY, 0.9);

            CoreLogger.LogStatus("Transform 4:  " + myTransforms.Children[3].GetType().Name);
            RotateTransform myTransform4 = myTransforms.Children[3] as RotateTransform;
            VerifyElement.VerifyBool(null == myTransform4, false);
            VerifyElement.VerifyDouble(myTransform4.Angle, 25);

            CoreLogger.LogStatus("Transform 5:  " + myTransforms.Children[4].GetType().Name);

            ScaleTransform myTransform5 = myTransforms.Children[4] as ScaleTransform;
            VerifyElement.VerifyBool(null == myTransform5, false);
            VerifyElement.VerifyDouble(myTransform5.ScaleX, 1.2);
            VerifyElement.VerifyDouble(myTransform5.ScaleY, 1.3);

            CoreLogger.LogStatus("Transform 6:  " + myTransforms.Children[5].GetType().Name);
            RotateTransform myTransform6 = myTransforms.Children[5] as RotateTransform;
            VerifyElement.VerifyBool(null == myTransform6, false);
            VerifyElement.VerifyDouble(myTransform6.Angle, 2);
            VerifyElement.VerifyDouble(myTransform6.CenterX, 45);
            VerifyElement.VerifyDouble(myTransform6.CenterY, 45);

            CoreLogger.LogStatus("Rectangle: ");
            Rectangle myRectangle = (Rectangle)LogicalTreeHelper.FindLogicalNode(uie, "Rectangle");

            VerifyElement.VerifyBool(null == myRectangle, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myRectangle).Stroke)).Color, Colors.Blue);
            VerifyElement.VerifyDouble(((Shape)myRectangle).StrokeThickness, 2);
            VerifyElement.VerifyDouble(myRectangle.Width, 100);
            VerifyElement.VerifyDouble(myRectangle.Height, 100);
            VerifyElement.VerifyDouble(Canvas.GetTop(myRectangle), 100);
            VerifyElement.VerifyDouble(Canvas.GetLeft(myRectangle), 125);
        }
        /// <summary>
        /// Verification routine for MatrixTransformsGraphics.xaml.
        /// </summary>
        public static void MatrixTransformVerify(UIElement uie)
        {

            CustomCanvas myPanel = uie as CustomCanvas;

            CoreLogger.LogStatus("Matrix Transform Verify ...");

            Decorator myTransformDecorator = (Decorator)LogicalTreeHelper.FindLogicalNode(uie, "TransformDecorator");

            VerifyElement.VerifyBool(null == myTransformDecorator, false);

            CoreLogger.LogStatus("Transform Collection Verify : transform ...");
            //blocked on bug 
            //TransformGroup myGroup = myTransformDecorator.LayoutTransform as TransformGroup;

            //VerifyElement.VerifyBool(null == myGroup.Children, false);
            //VerifyElement.VerifyInt(myGroup.Children.Count, 1);

            //MatrixTransform myTransform = myGroup.Children[0] as MatrixTransform;

            //VerifyElement.VerifyBool(Matrix.Equals(myTransform.Matrix, new Matrix(1, 0, 1, 1, 50, 90)), true);

            CoreLogger.LogStatus("Rectangle: ");
            Rectangle myRectangle = (Rectangle)LogicalTreeHelper.FindLogicalNode(uie, "Rectangle");

            VerifyElement.VerifyBool(null == myRectangle, false);
            VerifyElement.VerifyColor(((SolidColorBrush)(((Shape)myRectangle).Stroke)).Color, Colors.Red);
            VerifyElement.VerifyDouble(((Shape)myRectangle).StrokeThickness, 3);
            VerifyElement.VerifyDouble(myRectangle.Width, 100);
            VerifyElement.VerifyDouble(myRectangle.Height, 50);
            VerifyElement.VerifyDouble(Canvas.GetTop(myRectangle), 50);
            VerifyElement.VerifyDouble(Canvas.GetLeft(myRectangle), 450);
        }

    }
}
