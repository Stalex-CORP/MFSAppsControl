using System.Text;

namespace MFSAppsControl.Models
{
    public partial class ApplicationModel : ObservableObject
    {
        public string? IconPath { get; set; }
        public required string Name { get; set; }
        public required string ExecutablePath { get; set; }

        [ObservableProperty]
        private string? arguments;

        [ObservableProperty]
        private bool autoStart;

        [ObservableProperty]
        private bool autoClose;


        /// <summary>
        /// Method to get a string representation of the ApplicationModel.
        /// </summary>
        /// <returns>string object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Name=").Append(Name)
              .Append(", ExecutablePath=").Append(ExecutablePath)
              .Append(", IconPath=").Append(IconPath)
              .Append(", Arguments=").Append(Arguments)
              .Append(", AutoStart=").Append(AutoStart)
              .Append(", AutoClose=").Append(AutoClose);
            return sb.ToString();
        }
    }
}
