using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QRCodeScanCreate.ViewModels
{
    public class ScanPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Uri _scannedUri;
        private string _scannedText;
        public ICommand GoToUrlCommand { get; }
        public ICommand SearchTextCommand { get; }
        public bool IsGoToUrlVisible { get; private set; }
        public bool IsSearchTextVisible { get; private set; }
        public string ScannedText
        {
            get => _scannedText;
            set
            {
                _scannedText = value;
                OnPropertyChanged(nameof(ScannedText));
            }
        }

        public ScanPageViewModel()
        {
            GoToUrlCommand = new Command(async () => await GoToUrl());
            SearchTextCommand = new Command(async () => await SearchText());
        }

        public void HandleBarcodeDetected(string text)
        {
            ScannedText = text;
            if (Uri.TryCreate(ScannedText, UriKind.Absolute, out _scannedUri) &&
                (_scannedUri.Scheme == Uri.UriSchemeHttp || _scannedUri.Scheme == Uri.UriSchemeHttps))
            {
                IsGoToUrlVisible = true;
                IsSearchTextVisible = false;
            }
            else
            {
                IsGoToUrlVisible = false;
                IsSearchTextVisible = true;
            }
            OnPropertyChanged
            (nameof(IsGoToUrlVisible));
            OnPropertyChanged(nameof(IsSearchTextVisible));
        }
        private async Task GoToUrl()
        {
            if (_scannedUri != null)
            {
                await Launcher.OpenAsync(_scannedUri);
            }
        }

        private async Task SearchText()
        {
            var searchQuery = Uri.EscapeDataString(_scannedText);
            var searchUrl = $"https://www.google.com/search?q={searchQuery}";
            await Launcher.OpenAsync(new Uri(searchUrl));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
