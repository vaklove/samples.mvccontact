using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using maxtoroq.apps.contact;

namespace Samples.Models {
   
   public class CustomContactSender : ContactSender {

      public override ContactInput CreateContactInput() {
         return new CustomContactInput();
      }
   }
}