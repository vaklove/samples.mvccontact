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
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace maxtoroq.samples.mvccontact {
   
   public static class HtmlUtil {

      public static HtmlHelper<TModel> HtmlHelperFor<TModel>(this HtmlHelper htmlHelper) {
         return HtmlHelperFor(htmlHelper, default(TModel));
      }

      public static HtmlHelper<TModel> HtmlHelperFor<TModel>(this HtmlHelper htmlHelper, TModel model) {
         return HtmlHelperFor(htmlHelper, model, null);
      }

      public static HtmlHelper<TModel> HtmlHelperFor<TModel>(this HtmlHelper htmlHelper, TModel model, string htmlFieldPrefix) {

         var viewDataContainer = CreateViewDataContainer(htmlHelper.ViewData, model);

         TemplateInfo templateInfo = viewDataContainer.ViewData.TemplateInfo;

         if (!String.IsNullOrEmpty(htmlFieldPrefix))
            templateInfo.HtmlFieldPrefix = templateInfo.GetFullHtmlFieldName(htmlFieldPrefix);

         ViewContext viewContext = htmlHelper.ViewContext;
         ViewContext newViewContext = new ViewContext(viewContext.Controller.ControllerContext, viewContext.View, viewDataContainer.ViewData, viewContext.TempData, viewContext.Writer);

         return new HtmlHelper<TModel>(newViewContext, viewDataContainer, htmlHelper.RouteCollection);
      }

      static IViewDataContainer CreateViewDataContainer(ViewDataDictionary viewData, object model) {

         var newViewData = new ViewDataDictionary(viewData) {
            Model = model
         };

         newViewData.TemplateInfo = new TemplateInfo {
            HtmlFieldPrefix = newViewData.TemplateInfo.HtmlFieldPrefix
         };

         return new ViewDataContainer {
            ViewData = newViewData
         };
      }

      class ViewDataContainer : IViewDataContainer {

         public ViewDataDictionary ViewData { get; set; }
      }
   }
}
