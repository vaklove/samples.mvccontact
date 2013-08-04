// Copyright 2012 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace maxtoroq.apps.contact {
   
   public class ContactInput {

      [Required(ErrorMessageResourceName = ContactResources.Keys.Validation_Required, ErrorMessageResourceType = typeof(ContactResources))]
      [StringLength(100, ErrorMessageResourceName = ContactResources.Keys.Validation_StringLength, ErrorMessageResourceType = typeof(ContactResources))]
      [Display(Order = 1)]
      public virtual string Name { get; set; }

      [Required(ErrorMessageResourceName = ContactResources.Keys.Validation_Required, ErrorMessageResourceType = typeof(ContactResources))]
      [DataType(DataType.EmailAddress)]
      [StringLength(254, ErrorMessageResourceName = ContactResources.Keys.Validation_StringLength, ErrorMessageResourceType = typeof(ContactResources))]
      [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceName = ContactResources.Keys.Validation_EmailPattern, ErrorMessageResourceType = typeof(ContactResources))]
      [Display(Order = 2)]
      public virtual string Email { get; set; }

      [Required(ErrorMessageResourceName = ContactResources.Keys.Validation_Required, ErrorMessageResourceType = typeof(ContactResources))]
      [StringLength(254, ErrorMessageResourceName = ContactResources.Keys.Validation_StringLength, ErrorMessageResourceType = typeof(ContactResources))]
      [Display(Order = 3)]
      public virtual string Subject { get; set; }

      [Required(ErrorMessageResourceName = ContactResources.Keys.Validation_Required, ErrorMessageResourceType = typeof(ContactResources))]
      [StringLength(2000, ErrorMessageResourceName = ContactResources.Keys.Validation_StringLength, ErrorMessageResourceType = typeof(ContactResources))]
      [DataType(DataType.MultilineText)]
      [Display(Order = 4)]
      public virtual string Message { get; set; }
   }
}
