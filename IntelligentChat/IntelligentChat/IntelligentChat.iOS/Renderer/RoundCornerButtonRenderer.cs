using CoreAnimation;
using CoreGraphics;
using IntelligentChat.Control;
using IntelligentChat.iOS.Renderer;
using System;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundCornerButton), typeof(RoundCornerButtonRenderer))]
namespace IntelligentChat.iOS.Renderer
{
    class RoundCornerButtonRenderer : ButtonRenderer
    {
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
            set
            {
                if (value.Width > 0 && value.Height > 0)
                {
                    foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                        layer.Frame = new CGRect(0, 0, value.Width, value.Height);
                }
                base.Frame = value;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (e.OldElement != null)
                {
                    e.OldElement.PropertyChanged -= OnElementPropertyChanged;
                }
                if (e.NewElement != null)
                {
                    e.NewElement.PropertyChanged += OnElementPropertyChanged;
                }
                if (Control == null && e.OldElement == null && e.NewElement != null)
                {
                    bool isColorSet = false;
                    var gradient = new CAGradientLayer();
                    gradient.CornerRadius = Control.Layer.CornerRadius = 20;
                    if (e.NewElement != null && e.NewElement is RoundCornerButton)
                    {
                        Xamarin.Forms.Color color = ((RoundCornerButton)e.NewElement).BackColor;
                        if (color != Xamarin.Forms.Color.Transparent)
                        {
                            isColorSet = true;
                        }
                    }
                    if (!isColorSet)
                    {
                        gradient.Colors = new CGColor[]
                        {
                            UIColor.FromRGB(108,150,225).CGColor,
                            UIColor.FromRGB(45, 106, 213).CGColor
                        };
                        Control.Layer.InsertSublayer(gradient, 0);
                    }
                    Control.LineBreakMode = UILineBreakMode.CharacterWrap;
                    Control.TitleLabel.TextAlignment = UITextAlignment.Center;
                    Control.SetTitleColor(UIColor.White, UIControlState.Disabled);
                }
            }
            catch (Exception) {}
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == "Renderer" || e.PropertyName == "IsEnabled")
                {
                    Color color = ((RoundCornerButton)sender).BackColor;
                    var gradient = new CAGradientLayer();
                    gradient.CornerRadius = Control.Layer.CornerRadius = 20;
                    if (color == Xamarin.Forms.Color.Transparent)
                    {
                        gradient.Colors = new CGColor[]
                            {
                            UIColor.FromRGB(108,150,225).CGColor,
                            UIColor.FromRGB(45, 106, 213).CGColor
                            };
                        Control.Layer.InsertSublayer(gradient, 0);
                    }
                    Control.LineBreakMode = UILineBreakMode.CharacterWrap;
                    Control.TitleLabel.TextAlignment = UITextAlignment.Center;
                    Control.SetTitleColor(UIColor.White, UIControlState.Disabled);
                    Control.ContentEdgeInsets = new UIEdgeInsets(15, 15, 15, 15);
                }
            }
            catch (Exception) {}
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && Control != null)
            {
                Control.RemoveFromSuperview();
                Control.Dispose();
            }
        }
    }
}