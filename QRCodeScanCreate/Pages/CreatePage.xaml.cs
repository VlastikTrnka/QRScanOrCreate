namespace QRCodeScanCreate;

public partial class CreatePage : ContentPage
{
	public CreatePage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}