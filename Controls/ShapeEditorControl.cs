using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tomers.WPF.MVVM.Controls
{
    /// <summary>
    ///
    /// </summary>
    public class ShapeEditorControl : Control
    {
        static ShapeEditorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ShapeEditorControl),
                new FrameworkPropertyMetadata(typeof(ShapeEditorControl)));
        }

        private Point _startPoint;
        private Point _lastPoint;        

        #region Properties

        #region CurrentGeometry Property

        internal GeometryGroup CurrentGeometry
        {
            get { return (GeometryGroup)GetValue(CurrentGeometryProperty); }
            set { SetValue(CurrentGeometryProperty, value); }
        }

        /// <value>Identifies the CurrentGeometry dependency property</value>
        internal static readonly DependencyProperty CurrentGeometryProperty =
            DependencyProperty.Register(
            "CurrentGeometry",
            typeof(GeometryGroup),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(GeometryGroup), CurrentGeometryChanged));

        /// <summary>
        /// Invoked on CurrentGeometry change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void CurrentGeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region IsDrawingEnabled Property

        public bool IsDrawingEnabled
        {
            get { return (bool)GetValue(IsDrawingEnabledProperty); }
            set { SetValue(IsDrawingEnabledProperty, value); }
        }

        /// <value>Identifies the IsDrawingEnabled dependency property</value>
        public static readonly DependencyProperty IsDrawingEnabledProperty =
            DependencyProperty.Register(
            "IsDrawingEnabled",
            typeof(bool),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(bool), IsDrawingEnabledChanged));

        /// <summary>
        /// Invoked on IsDrawingEnabled change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void IsDrawingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Should end drawing here if already begun.
        }

        #endregion

        #region GeometriesSource Property

        public ICollection<Geometry> GeometriesSource
        {
            get { return (ICollection<Geometry>)GetValue(GeometriesSourceProperty); }
            set { SetValue(GeometriesSourceProperty, value); }
        }

        /// <value>Identifies the GeometriesSource dependency property</value>
        public static readonly DependencyProperty GeometriesSourceProperty =
            DependencyProperty.Register(
            "GeometriesSource",
            typeof(ICollection<Geometry>),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(ICollection<Geometry>), GeometriesSourceChanged));

        /// <summary>
        /// Invoked on GeometriesSource change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void GeometriesSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region GeometryTemplate Property

        public DataTemplate GeometryTemplate
        {
            get { return (DataTemplate)GetValue(GeometryTemplateProperty); }
            set { SetValue(GeometryTemplateProperty, value); }
        }

        /// <value>Identifies the GeometryTemplate dependency property</value>
        public static readonly DependencyProperty GeometryTemplateProperty =
            DependencyProperty.Register(
            "GeometryTemplate",
            typeof(DataTemplate),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(DataTemplate), GeometryTemplateChanged));

        /// <summary>
        /// Invoked on GeometryTemplate change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void GeometryTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region BeginDrawing Property

        public RelayCommand<Geometry> BeginDrawing
        {
            get { return (RelayCommand<Geometry>)GetValue(BeginDrawingProperty); }
            set { SetValue(BeginDrawingProperty, value); }
        }

        /// <value>Identifies the BeginDrawing dependency property</value>
        public static readonly DependencyProperty BeginDrawingProperty =
            DependencyProperty.Register(
            "BeginDrawing",
            typeof(RelayCommand<Geometry>),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(RelayCommand<Geometry>), BeginDrawingChanged));

        /// <summary>
        /// Invoked on BeginDrawing change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void BeginDrawingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region DrawingProgress Property

        public RelayCommand<Geometry> DrawingProgress
        {
            get { return (RelayCommand<Geometry>)GetValue(DrawingProgressProperty); }
            set { SetValue(DrawingProgressProperty, value); }
        }

        /// <value>Identifies the DrawingProgress dependency property</value>
        public static readonly DependencyProperty DrawingProgressProperty =
            DependencyProperty.Register(
            "DrawingProgress",
            typeof(RelayCommand<Geometry>),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(RelayCommand<Geometry>), DrawingProgressChanged));

        /// <summary>
        /// Invoked on DrawingProgress change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void DrawingProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #region EndDrawing Property

        public RelayCommand<Geometry> EndDrawing
        {
            get { return (RelayCommand<Geometry>)GetValue(EndDrawingProperty); }
            set { SetValue(EndDrawingProperty, value); }
        }

        /// <value>Identifies the EndDrawing dependency property</value>
        public static readonly DependencyProperty EndDrawingProperty =
            DependencyProperty.Register(
            "EndDrawing",
            typeof(RelayCommand<Geometry>),
            typeof(ShapeEditorControl),
              new FrameworkPropertyMetadata(default(RelayCommand<Geometry>), EndDrawingChanged));

        /// <summary>
        /// Invoked on EndDrawing change.
        /// </summary>
        /// <param name="d">The object that was changed</param>
        /// <param name="e">Dependency property changed event arguments</param>
        private static void EndDrawingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion

        #endregion

        #region Event Handlers

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (IsDrawingEnabled == false)
            {
                return;
            }

            Point currentPoint = e.GetPosition(this);
            if (CurrentGeometry == null)
            {
                _startPoint = currentPoint;
                _lastPoint = currentPoint;
                CurrentGeometry = new GeometryGroup();

                CurrentGeometry.Children.Add(new EllipseGeometry(currentPoint, 3, 3));

                if (BeginDrawing != null)
                {
                    BeginDrawing.Execute(CurrentGeometry);
                }
            }
            else
            {
                if (AreClose(_startPoint, currentPoint))
                {
                    CurrentGeometry.Children.Add(new LineGeometry(_lastPoint, _startPoint));
                    CurrentGeometry.Freeze();                    
                    if (EndDrawing != null)
                    {
                        EndDrawing.Execute(CurrentGeometry);
                    }

                    CurrentGeometry = null;
                }
                else
                {
                    CurrentGeometry.Children.Add(new LineGeometry(_lastPoint, currentPoint));
                    CurrentGeometry.Children.Add(new EllipseGeometry(currentPoint, 3, 3));
                    _lastPoint = currentPoint;
                    if (DrawingProgress != null)
                    {
                        DrawingProgress.Execute(CurrentGeometry);
                    }
                }
            }                       

            base.OnMouseLeftButtonDown(e);
        }       

        #endregion

        #region Utilities

        private static bool AreClose(Point a, Point b)
        {
            double distance = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            return distance <= 5.0;
        }

        #endregion
    }
}
