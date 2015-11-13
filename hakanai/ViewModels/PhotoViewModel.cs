using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

using hakanai.DataValidation;

namespace hakanai.ViewModels
{
    class PhotoViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public DateTime taken { get; set; }


        [Required]
        public string UrlLocation { get; set; }

        [FileAttribute(1024)]
        public HttpPostedFileBase File { get; set; }

    }
}
