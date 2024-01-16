using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZXing.QrCode.Internal;

namespace QRCodeScanCreate.ViewModels
{
    public class CreatePageViewModel : BindableObject
    {
        private string _inputText;
        private string _qrCode;
        private bool _isQrCodeVisible;
        private bool _isFormVisible = true;


        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string QrCode
        {
            get => _qrCode;
            set
            {
                _qrCode = value;
                OnPropertyChanged(nameof(QrCode));
            }
        }

        public bool IsQrCodeVisible
        {
            get => _isQrCodeVisible;
            set
            {
                _isQrCodeVisible = value;
                OnPropertyChanged(nameof(IsQrCodeVisible));
            }
        }

        public bool IsFormVisible
        {
            get => _isFormVisible;
            set
            {
                _isFormVisible = value;
                OnPropertyChanged(nameof(IsFormVisible));
            }
        }

        public ICommand CreateQrCommand { get; }
        public ICommand BackCommand { get; }

        public CreatePageViewModel()
        {
            CreateQrCommand = new Command(OnCreateQrClicked);
            BackCommand = new Command(OnBackClicked);
        }

        private void OnCreateQrClicked()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
            {
                QrCode = InputText;

                IsQrCodeVisible = true;
                IsFormVisible = false;
            }
        }

        private void OnBackClicked()
        {
            InputText = string.Empty;
            QrCode = null;
            IsQrCodeVisible = false;
            IsFormVisible = true;
        }
    }
}
