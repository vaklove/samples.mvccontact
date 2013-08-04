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
using System.Net.Mail;
using System.Text;

namespace maxtoroq.apps.contact {
   
   public class ContactSender {

      readonly SmtpClient smtpClient;
      ContactConfiguration config;
      
      public ContactConfiguration Configuration {
         get { return config; }
         set { config = value; }
      }

      public ContactSender() 
         : this(new SmtpClient()) { }

      public ContactSender(SmtpClient smtpClient) {

         if (smtpClient == null) throw new ArgumentNullException("smtpClient");

         this.smtpClient = smtpClient;
      }

      public virtual ContactInput CreateContactInput() {
         return new ContactInput();
      }

      protected virtual void InitializeContactInput(ContactInput input) { }

      public ContactInput Send() {

         ContactInput input = CreateContactInput();
         InitializeContactInput(input);

         return input;
      }

      public virtual bool Send(ContactInput input, Func<string, object, string> renderViewAsString) {

         EnsureConfig();

         var message = new MailMessage {
            To = { this.config.To },
            ReplyToList = { new MailAddress(input.Email, input.Name) },
            Subject = input.Subject,
            Body = renderViewAsString("_MailHtml", input)
         };

         if (this.config.From.HasValue())
            message.From = new MailAddress(this.config.From);

         if (this.config.CC.HasValue())
            message.CC.Add(this.config.CC);

         if (this.config.Bcc.HasValue())
            message.Bcc.Add(this.config.Bcc);

         try {
            this.smtpClient.Send(message);

         } catch (SmtpException ex) {
            
            LogException(ex);

            return false;
         }

         return true;
      }

      void EnsureConfig() {

         if (this.config == null)
            throw new InvalidOperationException("Configuration cannot be null.");
      }

      protected void LogException(Exception exception) {
         WebEvents.RaiseUnhandledErrorEvent(this, exception);
      }
   }
}
