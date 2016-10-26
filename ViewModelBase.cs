using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tomers.WPF.MVVM
{
    /// <summary>
    /// Base class for all ViewModel classes in the application.
    /// It provides support for property change notifications 
    /// and has a DisplayName property.  This class is abstract.
    /// </summary>
    public abstract class ViewModelBase : NotifyingObject
    {
        #region Constructor

        protected ViewModelBase()
        {
        }

        #endregion // Constructor        
    }
}