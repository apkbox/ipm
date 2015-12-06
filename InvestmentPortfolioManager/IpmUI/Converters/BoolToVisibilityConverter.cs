// --------------------------------------------------------------------------------
// <copyright file="BoolToVisibilityConverter.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   The bool to visibility converter.
// </summary>
// --------------------------------------------------------------------------------
namespace IpmUI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The bool to visibility converter.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolToVisibilityConverter"/> class.
        /// </summary>
        public BoolToVisibilityConverter()
        {
            // set defaults
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the false value.
        /// </summary>
        public Visibility FalseValue { get; set; }

        /// <summary>
        /// Gets or sets the true value.
        /// </summary>
        public Visibility TrueValue { get; set; }

        #endregion

        #region Public Methods and Operators

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return null;
            }

            return (bool)value ? this.TrueValue : this.FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (object.Equals(value, this.TrueValue))
            {
                return true;
            }

            if (object.Equals(value, this.FalseValue))
            {
                return false;
            }

            return null;
        }

        #endregion
    }
}
