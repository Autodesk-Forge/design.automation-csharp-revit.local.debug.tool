using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DesignAutomationFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DesignAutomationHandler
{
   [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
   [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
   class DesignAutomationHandlerApp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var app = commandData.Application.Application;
            string[] files = Directory.GetFiles(app.AllUsersAddinsLocation, "*.addin");
            foreach (string file in files)
            {
               XElement addin = XElement.Load(file);
               IEnumerable<XElement> childList = from el in addin.Elements() select el;
               foreach (XElement e in childList)
               {
                  try
                  {
                     System.Reflection.Assembly a = System.Reflection.Assembly.LoadFile(e.Element("Assembly").Value);
                     bool designAutomationBridge = false;
                     bool revitAPIUI = false;
                     foreach (System.Reflection.AssemblyName an in a.GetReferencedAssemblies())
                     {
                        string assemblyName = an.Name;
                        if (assemblyName == "DesignAutomationBridge")
                           designAutomationBridge = true;
                        else if (assemblyName == "RevitAPIUI")
                           revitAPIUI = true;
                     }
                     if (designAutomationBridge && revitAPIUI)
                        MessageBox.Show($"RevitAPIUI detected in DA Plugin: {e.Element("Assembly").Value}", "DesignAutomationHandler");
                  }
                  catch
                  {
                     // in case we can't open the dll for some reason, just continue
                     continue;
                  }
               }
            }
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
