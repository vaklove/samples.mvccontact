using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Samples.Models {

   public class CustomContactInput : maxtoroq.samples.mvccontact.ContactInput {

      [Required]
      [Display(Name = "How did you hear about us?", Order = 3)]
      [UIHint("Source")]
      public virtual string Source { get; set; }
   }
}