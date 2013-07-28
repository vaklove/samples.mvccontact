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
using System.Web.Management;
using System.Reflection;

namespace maxtoroq.apps.web.contact {

   /// <summary>
   /// Provides a set of static (Shared in Visual Basic) methods to easily raise ASP.NET 
   /// health-monitoring events.
   /// </summary>
   static class WebEvents {

      static readonly Action<object, int, int, Exception> _RaiseSystemEvent;

      static WebEvents() {

         _RaiseSystemEvent = (Action<object, int, int, Exception>)Delegate.CreateDelegate(
            typeof(Action<object, int, int, Exception>),
            typeof(WebBaseEvent).GetMethod("RaiseSystemEvent", BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(object), typeof(int), typeof(int), typeof(Exception) }, null)
         );
      }

      public static void RaiseUnhandledErrorEvent(object source, Exception exception) {

         if (source == null) throw new ArgumentNullException("source");
         if (exception == null) throw new ArgumentNullException("exception");

         _RaiseSystemEvent(source, WebEventCodes.RuntimeErrorUnhandledException, 0, exception);
      }
   }
}
