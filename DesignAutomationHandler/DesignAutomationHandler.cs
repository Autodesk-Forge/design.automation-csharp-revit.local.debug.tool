using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using DesignAutomationFramework;
using Autodesk.Revit.UI;
using System.IO;

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


         // First check to see how many DLL's are in the 'DAHandler' folder.

         string folderPath = app.AllUsersAddinsLocation + "\\DesignAutomationHandler";
         DirectoryInfo d = new DirectoryInfo(folderPath);
         FileInfo[] dlls = d.GetFiles("*.dll");

         // if it's anything other than 1, don't run.
         // there's either no DLL (so no app to run)
         // or there's more than one app (which we don't support)
         if(dlls.Length != 1)
         {
            return;
         }

         FileOpenDialog dialog = new FileOpenDialog("Revit Files(*.rvt) | *.rvt");
         dialog.Title = "Main Model Path";
         // Show open file dialog box
         dialog.Show();

         string filename = ModelPathUtils.ConvertModelPathToUserVisiblePath(dialog.GetSelectedModelPath());
         // when application ready is called, set design automation ready.
         bool designAutomationResult = DesignAutomationBridge.SetDesignAutomationReady(app, filename);
      }
   }
}
