using System.Collections.ObjectModel;

namespace MFSAppsControl.Models
{
    public partial class ConfigurationModel : ObservableObject
    {
        public ObservableCollection<ApplicationModel>? Apps { get; set; }
        public string? Language { get; set; }
    }
}
