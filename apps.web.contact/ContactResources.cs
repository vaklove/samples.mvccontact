﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Web;

namespace apps.web.contact {

   class ContactResources {       
      
      /// <summary>
      /// Looks up a localized string similar to 'An unexpected error ocurred, please try again later.'.
      /// </summary>
      public static string Error_Unexpected { 
         get {
            return GetResource("Error_Unexpected");
         }
      }
      
      /// <summary>
      /// Looks up a localized string similar to 'The {0} is invalid.'.
      /// </summary>
      public static string Validation_EmailPattern { 
         get {
            return GetResource("Validation_EmailPattern");
         }
      }
      
      /// <summary>
      /// Looks up a localized string similar to 'Required field cannot be left blank.'.
      /// </summary>
      public static string Validation_Required { 
         get {
            return GetResource("Validation_Required");
         }
      }
      
      /// <summary>
      /// Looks up a localized string similar to 'The {0} cannot have more than {1} characters.'.
      /// </summary>
      public static string Validation_StringLength { 
         get {
            return GetResource("Validation_StringLength");
         }
      }
      
      /// <summary>
      /// Looks up a localized string similar to 'The {0} must have between {2} and  {1} characters.'.
      /// </summary>
      public static string Validation_StringLengthWithMin { 
         get {
            return GetResource("Validation_StringLengthWithMin");
         }
      }
      
      static string GetResource(string resourceKey) {

         CultureInfo culture = CultureInfo.CurrentUICulture;

         return GetUserResourceString(resourceKey, culture)
            ?? resources.ContactResources.ResourceManager.GetString(resourceKey, culture);
      }

      static string GetUserResourceString(string resourceKey, CultureInfo culture) {

         string classKey = ContactConfiguration.ResourceClassKey;

         if (String.IsNullOrEmpty(classKey))
            return null;

         return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture) as string;
      }
      
      public static class Keys {
          public const string Error_Unexpected = "Error_Unexpected";
          public const string Validation_EmailPattern = "Validation_EmailPattern";
          public const string Validation_Required = "Validation_Required";
          public const string Validation_StringLength = "Validation_StringLength";
          public const string Validation_StringLengthWithMin = "Validation_StringLengthWithMin";
               
      }
   }
}
