using QRCodeScanCreate.ViewModels;
using ZXing.Net.Maui;

namespace QRCodeScanCreate;

public partial class ScanPage : ContentPage
{
    ScanPageViewModel viewModel;

    public ScanPage()
    {
        InitializeComponent();
        viewModel = (ScanPageViewModel)BindingContext;
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        viewModel.HandleBarcodeDetected(args.Result[0].Text);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}