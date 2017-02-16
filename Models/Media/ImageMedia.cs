using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Media
{
    [ContentType(DisplayName = "ImageMedia", GUID = "bacdb9db-52d9-485c-9c68-64c6af364aa1", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,bmp,gif,png,jpe,ico")]
    public class ImageMedia : ImageData
    {
        [Display(Name = "Alternate Text", Order = 200)]
        public virtual string AlternateText { get; set; }

        [Display(Order = 100)]
        public virtual string Copyright { get; set; }
    }
}