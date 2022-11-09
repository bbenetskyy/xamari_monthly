using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sharpnado.Shades;
using xamarin_monthly_01.Core.ViewModels.Home;

namespace xamarin_monthly_01.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ShadowsPage : MvxContentPage<ShadowsPageModel>
    {
        public ShadowsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ShadowsContainer.Children.Clear();
            ShadowsContainer.Children.Add(new Shadows()
            {
                Content = new Label()
                {
                    Text = "asdf",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                },
                Shades = new[]
                {
                    new Shade()
                    {
                        Offset = new Point(4, 7),
                        BlurRadius = 1,
                        Opacity = 0.5,
                        Color = Color.Blue
                    }
                }
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
