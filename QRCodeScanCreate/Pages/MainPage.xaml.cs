
using QRCodeScanCreate;

namespace QRCodeScanCreate
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnScanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScanPage());
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePage());
        }
    }
}
