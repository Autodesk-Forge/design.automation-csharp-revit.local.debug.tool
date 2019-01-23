# Design Automation Handler

## About
DesignAutomationHandler is a Revit addin that allows users to run/debug their Design Automation for Revit(D4R) application locally with desktop Revit. 

## Installation
1. Build the solution `DesignAutomationHandler`, compiling DesignAutomationHandler for Revit 2018.3(`DesignAutomationHandler2018`) and Revit 2019.2 (`DesignAutomationHandler2019`)
> Design Automation for Revit currently only supports Revit 2018 and 2019.

2. Place `DesignAutomationHandler.addin` in the "Addins" folder under `C:\ProgramData\Autodesk\Revit\Addins\XXXX\` where `XXXX` is the Revit version(e.g. 2018, 2019) to run against.
In `DesignAutomationHandler.addin`, change `Assembly` path pointing to where the `DesignAutomationHandler` locates.
> For example you can change the Assembly path to `G:\design-automation-handler\DesignAutomationHandler2019\bin\Release\DesignAutomationHandler.dll`
> To allow Revit loads `DesignAutomationHandler.addin` correctly, `DesignAutomationBridge.dll` should be in the same folder as `DesignAutomationHandler.dll` is.

3. Place your `.addin` for D4R in the same folder(`C:\ProgramData\Autodesk\Revit\Addins\XXXX\`) as above. This will allow Revit to load both addins (`DesignAutomationHandler.addin` and addin for D4R) when it starts up.
In your `.addin` for D4R, change `Assembly` path to where your addin's dll locates. You can local debug the addin's dll as you usually do to develop addin for desktop Revit. 
> DesignAutomationHandler does not expect to handle more than one addin for local testing/debugging.
> To allow Revit loads your `.addin` correctly, `DesignAutomationBridge.dll` should be in the same folder as your addin's dll is.

## Usage
Starting Revit:
1. If your addin needs to run on an input Revit model file, then open it in Revit
> If you have json parameter defined to run the `WorkItem` in D4R, you can save json payload as a json file where your input file is at.
> For example, `{"walls": false,"floors": true,"doors": true,"windows": true}` is saved as `CountItParams.json` in the same folder where my input file locates. `CountItParams` is the name of parameter I define in the `Activity` for D4R. 

2. Go to `Add-Ins` -> `External Tools`-> Click `DesignAutomationHandler`, your addin will get excuted! A dialog will pop up to tell the running result (if the runing succeeds the dialog will indicate where to find the output(s), it is supposed to be the folder where your input file is at) 

3. If you don't have input file to run on, after starting Revit, do 2 directly. If you have json parameter defined to run the `WorkItem` in D4R, there will be a dialog to instruct where to put the json file.  

> You can rerun the same addin without restarting Revit. But to run another addin, you need to follwoing the step above to set it up.  

> Currently, the DesignAutomationHandler does not support multiple input files yet, as D4R does.
