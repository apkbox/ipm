// --------------------------------------------------------------------------------
// <copyright file="RoutedCommandBehavior.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoutedCommandBehavior type.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// This is a routed command behavior.
    /// http://siderite.blogspot.com/2010/12/collection-attached-properties-with.html
    /// </summary>
    public class RoutedCommandBehavior
    {
        #region Static Fields

        public static readonly DependencyProperty CommandBindingsProperty =
            DependencyProperty.RegisterAttached(
                "CommandBindingsInternal", 
                typeof(ViewModelCommandBindingCollection), 
                typeof(RoutedCommandBehavior), 
                new PropertyMetadata(default(ViewModelCommandBindingCollection), PropertyChangedCallback));

        #endregion

        #region Public Methods and Operators

        public static ViewModelCommandBindingCollection GetCommandBindings(DependencyObject element)
        {
            var c = (ViewModelCommandBindingCollection)element.GetValue(CommandBindingsProperty);
            if (c == null)
            {
                c = new ViewModelCommandBindingCollection();
                element.SetValue(CommandBindingsProperty, c);
            }

            return c;
        }

        public static void SetCommandBindings(DependencyObject element, ViewModelCommandBindingCollection value)
        {
            element.SetValue(CommandBindingsProperty, value);
        }

        #endregion

        #region Methods

        private static void CanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private static void ExecutedHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Handled)
            {
                Debug.WriteLine("Already handled.");
                return;
            }
            Debug.WriteLine(
                "Executing {0}, sender: {1}, original: {2}", 
                e.Command, 
                e.Source, 
                e.OriginalSource);
            var src = e.Source as DependencyObject;
            if (src != null)
            {
                foreach (var cb in GetCommandBindings(src))
                {
                    var vmcb = cb as ViewModelCommandBinding;
                    if (vmcb.RoutedCommand == e.Command && vmcb.ViewModelCommand != null)
                    {
                        vmcb.ViewModelCommand.Execute(e.Parameter);
                        e.Handled = true;
                    }
                }
            }
        }

        private static void PropertyChangedCallback(
            DependencyObject dependencyObject, 
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var ui = dependencyObject as UIElement;
            CommandManager.AddCanExecuteHandler(ui, CanExecuteHandler);
            CommandManager.AddExecutedHandler(ui, ExecutedHandler);
        }

        #endregion
    }
}