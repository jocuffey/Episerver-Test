using System.ComponentModel.DataAnnotations;
using EpiserverTest.Business.Rendering;
using EPiServer.Web;
using EPiServer.Core;

namespace EpiserverTest.Models.Pages
{
    /// <summary>
    /// Represents contact details for a contact person
    /// </summary>
    [SiteContentType(
        GUID = "F8D47655-7B50-4319-8646-3369BA9AF05B",
        GroupName = Global.GroupNames.Specialized)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-contact.png")]
    public class ContactPage : SitePageData, IContainerPage
    {
        [Display(GroupName = Global.GroupNames.Contact)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = Global.GroupNames.Contact)]
        [UIHint(UIHint.PreviewableText)]
        public virtual string Phone { get; set; }

        [Display(GroupName = Global.GroupNames.Contact)]
        [EmailAddress]
        [UIHint(UIHint.PreviewableText)]
        public virtual string Email { get; set; }
    }
}
