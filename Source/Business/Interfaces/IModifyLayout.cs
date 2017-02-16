using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;

namespace Brightfind.EktronToEpiserverLab.Business.Interfaces
{
    interface IModifyLayout
    {
        void ModifyLayout(LayoutModel layoutModel);
    }
}
