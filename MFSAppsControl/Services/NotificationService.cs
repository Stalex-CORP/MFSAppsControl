using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;

namespace MFSAppsControl.Services
{
    public class NotificationService(LanguageService languageService)
    {
        private readonly LanguageService languageService = languageService;

        public void ShowMinimizeToTrayNotification()
        {
            new ToastContentBuilder()
                .AddText(languageService.GetMessage("SystemNotification_MinimizeBackgroundTitle"))
                .AddText(languageService.GetMessage("SystemNotification_MinimizeBackgroundDescription"))
                .Show(toast =>
                {
                    toast.Tag = "minimizeToTray";
                    toast.Group = "MFSAppsControlNotifications";
                    toast.ExpirationTime = DateTimeOffset.Now.AddMinutes(5);
                    toast.ExpiresOnReboot = true;
                });
        }

        public void ShowUpdateAvailableNotification(string notificationTitle, string notificationDescription)
        {
            new ToastContentBuilder()
                .AddText(notificationTitle)
                .AddText(notificationDescription)
                .AddButton(new ToastButton()
                    .SetContent(languageService.GetMessage("SystemNotification_OpenReleaseButton"))
                    .AddArgument("action", "viewRelease")
                    .SetImageUri(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "open.png")))
                )
                .AddButton(new ToastButton()
                    .SetContent(languageService.GetMessage("SystemNotification_UpdateAvailableRemindButton"))
                    .AddArgument("action", "remind")
                    .SetImageUri(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "snooze.png")))
                )
                .Show(toast =>
                {
                    toast.Tag = "updateAvailable";
                    toast.Group = "MFSAppsControlNotifications";
                    toast.ExpiresOnReboot = true;
                });
        }
    }
}
