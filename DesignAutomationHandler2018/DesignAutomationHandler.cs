using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DesignAutomationFramework;
using System.IO;
using System.Windows.Forms;

namespace DesignAutomationHandler
{
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   class DesignAutomationHandlerApp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var app = commandData.Application.Application;
            var doc = commandData.Application.ActiveUIDocument?.Document;
            HandleDAApplication(app, doc);
            return Result.Succeeded;
        }

      public void HandleDAApplication(Autodesk.Revit.ApplicationServices.Application app, Document doc)
      {
            try
            {
                var filename = doc?.PathName;
                var currentdir = Directory.GetCurrentDirectory();
                var message = string.Empty;
                if (string.IsNullOrEmpty(filename))
                {
                    message = $"No input file.\nIf you have json file for parameters, now copy it under the current folder:\n{currentdir}";
                    MessageBox.Show(message, "DesignAutomationHandler");
                }
                
                bool designAutomationResult = DesignAutomationBridge.SetDesignAutomationReady(app, filename);
               
                if (designAutomationResult)
                {
                    var resultFolder = string.IsNullOrEmpty(filename) ? currentdir : Path.GetDirectoryName(filename);
                    message = $"Succeed!\nFind the results at folder: {resultFolder}";
                }
                else
                {
                    message = $"Failed! You may debug the addin dll.";                   
                }

                MessageBox.Show(message, "DesignAutomationHandler");

            } 
            catch(System.Exception e)
            {
                MessageBox.Show(e.ToString(), "DesignAutomationHandler");
            }           
        }
   }
}
