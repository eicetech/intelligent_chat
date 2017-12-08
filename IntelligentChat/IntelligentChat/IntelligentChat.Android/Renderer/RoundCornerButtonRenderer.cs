using Android.Graphics.Drawables;
using IntelligentChat.Control;
using IntelligentChat.Droid.Renderer;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundCornerButton), typeof(RoundCornerButtonRenderer))]
namespace IntelligentChat.Droid.Renderer
{
    class RoundCornerButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    if (e.NewElement != null && e.NewElement is RoundCornerButton)
                    {

                        Xamarin.Forms.Color color = ((RoundCornerButton)e.NewElement).BackColor;

                        GradientDrawable gradientDrawable = new GradientDrawable(
                        GradientDrawable.Orientation.TopBottom,
                        new int[] {
                            color.ToAndroid(),
                            color.ToAndroid()   });
                        gradientDrawable.SetShape(ShapeType.Rectangle);
                        gradientDrawable.SetCornerRadius(100);
                        Control.SetBackground(gradientDrawable);
                    }
                    this.Element.PropertyChanged += RoundCornerButtonPropertyChanged;
                }
            }
            catch (Exception) {}
        }

        private void RoundCornerButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (sender != null && sender is RoundCornerButton)
                {

                    Xamarin.Forms.Color color = ((RoundCornerButton)sender).BackColor;

                    GradientDrawable gradientDrawable = new GradientDrawable(
                    GradientDrawable.Orientation.TopBottom,
                    new int[] {
                            color.ToAndroid(),
                            color.ToAndroid()   });
                    gradientDrawable.SetShape(ShapeType.Rectangle);
                    gradientDrawable.SetCornerRadius(100);
                    Control.SetBackground(gradientDrawable);

                }
            }
            catch (Exception) {}
        }
    }
}