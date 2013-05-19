using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ExtensionManagerUI.Common.Controls
{
    /// <summary>
    /// Interaction logic for ScreenshotViewer.xaml
    /// </summary>
    public partial class ScreenshotViewer : UserControl
    {
        #region Fields

        private Queue<string> imageQueue;
        private DispatcherTimer _timer = new DispatcherTimer();

        #endregion

        #region Constructor

        public ScreenshotViewer()
        {
            InitializeComponent();
            _timer.Tick += (s, e) => TimerElapsed();
        }

        #endregion

        #region DependencyProperties

        public static readonly DependencyProperty ImageDelayProperty = DependencyProperty.Register("ImageDelay", typeof(int), typeof(ScreenshotViewer), new PropertyMetadata(5, (d, e) => (d as ScreenshotViewer).ResetTimer()));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(int), typeof(ScreenshotViewer), new PropertyMetadata(0));
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ScreenshotViewer), new PropertyMetadata(Stretch.None));
        public static readonly DependencyProperty ImagesProperty = DependencyProperty.Register("Images", typeof(IList<string>), typeof(ScreenshotViewer), new PropertyMetadata(new List<string>(), (d, e) => (d as ScreenshotViewer).ResetTimer()));
        public static readonly DependencyProperty IsImageSource1Property = DependencyProperty.Register("IsImageSource1", typeof(bool), typeof(ScreenshotViewer), new PropertyMetadata(true));
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(ScreenshotViewer), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty ImageSource2Property = DependencyProperty.Register("ImageSource2", typeof(string), typeof(ScreenshotViewer), new PropertyMetadata(string.Empty));

        #endregion

        #region Properties

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public int ImageDelay
        {
            get { return (int)GetValue(ImageDelayProperty); }
            set { SetValue(ImageDelayProperty, value); }
        }

        public IList<string> Images
        {
            get { return (IList<string>)GetValue(ImagesProperty); }
            set { SetValue(ImagesProperty, value); }
        }

        public bool IsImageSource1
        {
            get { return (bool)GetValue(IsImageSource1Property); }
            set { SetValue(IsImageSource1Property, value); }
        }

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public string ImageSource2
        {
            get { return (string)GetValue(ImageSource2Property); }
            set { SetValue(ImageSource2Property, value); }
        }
        
        #endregion
        
        #region Methods

        private void ResetTimer()
        {
            if (Images != null && Images.Any())
            {
                ResetQueue();
                _timer.Stop();
                _timer.Interval = TimeSpan.FromSeconds(ImageDelay);
                _timer.Start();
                return;
            }
            _timer.Stop();
        }

        private void TimerElapsed()
        {
            if (imageQueue.Count > 0)
            {
                ChangeImage();
            }
            else
            {
                ResetQueue();
            }
        }

        private void ChangeImage()
        {
            if (!IsImageSource1)
            {
                IsImageSource1 = true;
                ImageSource = imageQueue.Dequeue();
            }
            else
            {
                IsImageSource1 = false;
                ImageSource2 = imageQueue.Dequeue();
            }
        }

        private void ResetQueue()
        {
            imageQueue = new Queue<string>(Images);
            if (imageQueue.Count > 0)
            {
                ChangeImage();
            }
        }

        #endregion
    }
}
