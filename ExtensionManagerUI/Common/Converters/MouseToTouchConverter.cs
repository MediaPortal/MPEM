using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ExtensionManagerUI.Common
{
    public class MouseToTouchConverter : TouchDevice
    {
        #region Static Fields

        private static MouseToTouchConverter device;

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Registers the events.
        /// </summary>
        /// <param name="root">The root.</param>
        public static void RegisterEvents(FrameworkElement root)
        {
            root.PreviewMouseDown += MouseDown;
            root.PreviewMouseMove += MouseMove;
            root.PreviewMouseUp += MouseUp;
            root.LostMouseCapture += LostMouseCapture;
            root.MouseLeave += MouseLeave;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// On Mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.ReportUp();
                device.Deactivate();
                device = null;
            }
            device = new MouseToTouchConverter(e.MouseDevice.GetHashCode());
            device.SetActiveSource(e.MouseDevice.ActiveSource);
            device.Position = e.GetPosition(null);
            device.Activate();
            device.ReportDown();
        }

        /// <summary>
        /// On Mouse move.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private static void MouseMove(object sender, MouseEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportMove();
            }
        }

        /// <summary>
        /// On Mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void MouseUp(object sender, MouseButtonEventArgs e)
        {
            LostMouseCapture(sender, e);
        }

        /// <summary>
        /// On Lost mouse capture.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private static void LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportUp();
                device.Deactivate();
                device = null;
            }
        }

        /// <summary>
        /// On Mouse leave.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private static void MouseLeave(object sender, MouseEventArgs e)
        {
            LostMouseCapture(sender, e);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseToTouchConverter"/> class.
        /// </summary>
        /// <param name="deviceId">A unique identifier for the touch device.</param>
        public MouseToTouchConverter(int deviceId) :
            base(deviceId)
        {
            Position = new Point();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the mouse position.
        /// </summary>
        public Point Position { get; set; }

        #endregion

        #region Overridden methods

        /// <summary>
        /// When overridden in a derived class, returns all touch points that are collected between the most recent and previous touch events.
        /// </summary>
        /// <param name="relativeTo">The element that defines the coordinate space.</param>
        /// <returns>
        /// All touch points that were collected between the most recent and previous touch events.
        /// </returns>
        public override TouchPointCollection GetIntermediateTouchPoints(IInputElement relativeTo)
        {
            return new TouchPointCollection();
        }

        /// <summary>
        /// Returns the current position of the touch device relative to the specified element.
        /// </summary>
        /// <param name="relativeTo">The element that defines the coordinate space.</param>
        /// <returns>
        /// The current position of the touch device relative to the specified element.
        /// </returns>
        public override TouchPoint GetTouchPoint(IInputElement relativeTo)
        {
            Point point = Position;
            if (relativeTo != null)
            {
                point = this.ActiveSource.RootVisual.TransformToDescendant((Visual)relativeTo).Transform(Position);
            }

            Rect rect = new Rect(point, new Size(1, 1));

            return new TouchPoint(this, point, rect, TouchAction.Move);
        }

        #endregion
    }
}
