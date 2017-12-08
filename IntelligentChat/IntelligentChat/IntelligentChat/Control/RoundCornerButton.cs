using Xamarin.Forms;

namespace IntelligentChat.Control
{
    public static class BindableObjectExtensions
    {
        public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property)
        {
            return (T)bindableObject.GetValue(property);
        }
    }

    public class RoundCornerButton : Button
    {
        public static readonly BindableProperty BackColorProperty =
            BindableProperty.Create<RoundCornerButton, Color>(
                p => p.BackColor, Color.Transparent);

        public Color BackColor
        {
            get
            {
                return this.GetValue<Color>(BackColorProperty);
            }
            set
            {
                this.SetValue(BackColorProperty, value);
            }
        }

        public static readonly BindableProperty FNameProperty =
            BindableProperty.Create<RoundCornerButton, string>(
                p => p.FName, "None");

        public string FName
        {
            get
            {
                return this.GetValue<string>(FNameProperty);
            }
            set
            {
                this.SetValue(FNameProperty, value);
            }
        }

        public static readonly BindableProperty ImagePathProperty =
           BindableProperty.Create<RoundCornerButton, string>(
                p => p.ImagePath, "None");

        public string ImagePath
        {
            get
            {
                return this.GetValue<string>(ImagePathProperty);
            }
            set
            {
                this.SetValue(ImagePathProperty, value);
            }
        }

        public static readonly BindableProperty TestOrderProperty =
            BindableProperty.Create<RoundCornerButton, int>(
                p => p.TestOrder, -1);

        public int TestOrder
        {
            get
            {
                return this.GetValue<int>(TestOrderProperty);
            }
            set
            {
                this.SetValue(TestOrderProperty, value);
            }
        }

        public static readonly BindableProperty DisableProperty =
           BindableProperty.Create<RoundCornerButton, bool>(
               p => p.Disable, false);

        public bool Disable
        {
            get
            {
                return this.GetValue<bool>(DisableProperty);
            }
            set
            {
                this.SetValue(DisableProperty, value);
            }
        }
    }
}
