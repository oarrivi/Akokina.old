using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Akokina.Renderers
{
    public class EllipseView : Xamarin.Forms.View
    {
        // Bindable property
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create<EllipseView, Color>(p => p.Color, Color.Default);

        // Gets or sets value of this BindableProperty
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(40, 40));
        }
    }
}
