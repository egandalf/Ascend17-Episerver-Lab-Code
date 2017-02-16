using Brightfind.EktronToEpiserverLab.Models.Blocks;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class LayoutModel
    {
        public LinkedImageBlock Logo { get; set; }
        public string Copyright { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsInReadOnlyMode { get; set; }

        public bool HideHeader { get; set; }
        public bool HideFooter { get; set; }
    }
}