using System;
using System.Collections.Generic;
using System.IO;


using Autodesk.Revit.ApplicationServices;
using Autodesk;
using Autodesk.Revit.DB;
using DesignAutomationFramework;
using Autodesk.Revit.UI;


namespace DesignAutomationHandler
{
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   class DesignAutomationHandlerApp : IExternalDBApplication
   {
      public ExternalDBApplicationResult OnStartup(Autodesk.Revit.ApplicationServices.ControlledApplication app)
      {
         // register for application initialized.
         app.ApplicationInitialized += HandleApplicationInitializedEvent;
         return ExternalDBApplicationResult.Succeeded;
      }

      public ExternalDBApplicationResult OnShutdown(Autodesk.Revit.ApplicationServices.ControlledApplication app)
      {
         return ExternalDBApplicationResult.Succeeded;
      }

      public void HandleApplicationInitializedEvent(object sender, Autodesk.Revit.DB.Events.ApplicationInitializedEventArgs e)
      {
         Application app = sender as Application;
         // Configure open file dialog box
         FileOpenDialog dialog = new FileOpenDialog("Revit Files(*.rvt) | *.rvt");
         dialog.Title = "Input Revit File";
         // Show open file dialog box
         dialog.Show();

         string filename = ModelPathUtils.ConvertModelPathToUserVisiblePath(dialog.GetSelectedModelPath());
         // when application ready is called, set design automation ready.
         bool designAutomationResult = DesignAutomationBridge.SetDesignAutomationReady(app, filename);
      }
   }
}
