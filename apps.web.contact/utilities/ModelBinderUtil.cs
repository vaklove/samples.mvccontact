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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace apps.web.contact {
   
   static class ModelBinderUtil {

      public static bool TryUpdateModel(object model, Controller controller) {

         if (model == null) throw new ArgumentNullException("model");
         if (controller == null) throw new ArgumentNullException("controller");

         Type modelType = model.GetType();

         ModelBinders.Binders
            .GetBinder(modelType)
            .BindModel(controller.ControllerContext, new ModelBindingContext {
               ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, modelType),
               ModelState = controller.ModelState,
               ValueProvider = controller.ValueProvider
            });

         return controller.ModelState.IsValid;
      }
   }
}
