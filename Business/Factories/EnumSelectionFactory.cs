using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Shell.ObjectEditing;

namespace Brightfind.EktronToEpiserverLab.Business.Factories
{
    public class EnumSelectionFactory<TEnum> : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var values = Enum.GetValues(typeof(TEnum));
            foreach(var value in values)
            {
                yield return new SelectItem
                {
                    Text = GetValueName(value),
                    Value = value
                };
            }
        }

        private static string GetValueName(object value) => Enum.GetName(typeof(TEnum), value);
    }
}