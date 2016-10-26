using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Tomers.WPF.MVVM.ShapeEditor
{
    public class ShapeEditorViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Geometry> _geometries = new ObservableCollection<Geometry>();

        public ObservableCollection<Geometry> Geometries
        {
            get { return _geometries; }
        }

        public bool IsDrawing
        {
            get { return GetValue(() => IsDrawing); }
            set { SetValue(() => IsDrawing, value); }
        }

        public RelayCommand<Geometry> EndDrawingCommand
        {
            get
            {
                return new RelayCommand<Geometry>(geometry => _geometries.Add(geometry));
            }
        }

        public RelayCommand<object> ClearShapesCommand
        {
            get
            {
                return new RelayCommand<object>(geometry => _geometries.Clear());
            }
        }
    }
}
