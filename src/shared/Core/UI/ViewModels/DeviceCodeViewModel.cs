using System.Windows.Input;

namespace GitCredentialManager.UI.ViewModels
{
    public class DeviceCodeViewModel : WindowViewModel
    {
        private readonly IEnvironment _environment;

        private ICommand _verificationUrlCommand;
        private string _verificationUrl;
        private string _userCode;
        private bool _showProductHeader = true;

        public DeviceCodeViewModel()
        {
            // Constructor the XAML designer
        }

        public DeviceCodeViewModel(IEnvironment environment)
        {
            EnsureArgument.NotNull(environment, nameof(environment));

            _environment = environment;

            Title = "Device code authentication";
            VerificationUrlCommand = new RelayCommand(OpenVerificationUrl);
        }

        private void OpenVerificationUrl()
        {
            BrowserUtils.OpenDefaultBrowser(_environment, VerificationUrl);
        }

        public string UserCode
        {
            get => _userCode;
            set => SetAndRaisePropertyChanged(ref _userCode, value);
        }

        public string VerificationUrl
        {
            get => _verificationUrl;
            set => SetAndRaisePropertyChanged(ref _verificationUrl, value);
        }

        public ICommand VerificationUrlCommand
        {
            get => _verificationUrlCommand;
            set => SetAndRaisePropertyChanged(ref _verificationUrlCommand, value);
        }

        public bool ShowProductHeader
        {
            get => _showProductHeader;
            set => SetAndRaisePropertyChanged(ref _showProductHeader, value);
        }
    }
}
