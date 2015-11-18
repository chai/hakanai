using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

using hakanai.DataValidation;
using System.Collections.Generic;

namespace hakanai.ViewModels
{
    public class PhotoViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public DateTime Taken { get; set; }


        [Required]
        public string UrlLocation { get; set; }

        [FileAttribute(1024)]
        public HttpPostedFileBase File { get; set; }

        [Required]
        public Guid PhotographId { get; set; }

        public List<Guid> Projects { get; set; }
        
    }
}
