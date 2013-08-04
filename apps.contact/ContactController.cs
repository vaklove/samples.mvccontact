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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace maxtoroq.apps.contact {
   
   [OutputCache(Location = OutputCacheLocation.None)]
   public class ContactController : Controller {

      ContactConfiguration config;
      ContactSender service;

      public ContactController() { }

      public ContactController(ContactSender service) {
         this.service = service;
      }

      protected override void Initialize(RequestContext requestContext) {
         
         base.Initialize(requestContext);

         this.config = requestContext.RouteData.DataTokens["Configuration"] as ContactConfiguration
            ?? new ContactConfiguration();

         if (this.config.ContactSenderResolver != null)
            this.service = this.config.ContactSenderResolver();

         if (this.service == null)
            this.service = new ContactSender();

         this.service.Configuration = this.config;
      }

      [HttpGet]
      public ActionResult Index() {

         this.ViewData.Model = new IndexViewModel(this.service.Send());
         
         return View();
      }

      [HttpPost]
      public ActionResult Index(string foo) {

         ContactInput input = this.service.CreateContactInput();

         this.ViewData.Model = new IndexViewModel(input);
         
         if (!ModelBinderUtil.TryUpdateModel(input, this)) {
            
            this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View();
         }

         if (!this.service.Send(input, RenderViewAsString)) {
            
            this.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
         }

         return RedirectToAction("Success");
      }

      [HttpGet]
      public ActionResult Success() {
         return View();
      }

      string RenderViewAsString(string viewName, object model) {

         ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);

         if (viewResult.View == null)
            throw new InvalidOperationException();

         using (var output = new StringWriter()) {

            var viewContext = new ViewContext(
               this.ControllerContext,
               viewResult.View,
               new ViewDataDictionary(model),
               new TempDataDictionary(),
               output
            );

            viewResult.View.Render(viewContext, output);

            return output.ToString();
         }
      }
   }
}
