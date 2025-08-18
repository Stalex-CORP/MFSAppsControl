using Wpf.Ui;
using Wpf.Ui.Controls;

namespace MFSAppsControlTests.Mocks
{
    public class MockSnackbarService : ISnackbarService
    {
        TimeSpan ISnackbarService.DefaultTimeOut { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Show(string title, string message, ControlAppearance appearance, SymbolIcon icon, TimeSpan duration) { }

        SnackbarPresenter? ISnackbarService.GetSnackbarPresenter()
        {
            throw new NotImplementedException();
        }

        void ISnackbarService.SetSnackbarPresenter(SnackbarPresenter contentPresenter)
        {
            throw new NotImplementedException();
        }

        void ISnackbarService.Show(string title, string message, ControlAppearance appearance, IconElement? icon, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
    }
}
