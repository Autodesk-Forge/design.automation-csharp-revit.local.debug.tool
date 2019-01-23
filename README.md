# Design Automation Handler

## About
DesignAutomationHandler is a Revit addin for desktop Revit that allows users to run their Design Automation for Revit(D4R) application locally with desktop Revit. 

## Installation
1. Build the solution `DesignAutomationHandler` which compile DesignAutomationHandler for Revit 2018.3(`DesignAutomationHandler2018`) and Revit 2019.2 (`DesignAutomationHandler2019`)
> Design Automation for Revit currently only supports Revit versions 2018 and 2019.

2. Place `DesignAutomationHandler.addin` in the "Addins" folder under `C:\ProgramData\Autodesk\Revit\Addins\XXXX\` where `XXXX` is the Revit versions to run against.
In `DesignAutomationHandler.addin`, change `Assembly` path to where the `DesignAutomationHandler` locates
> For example you can change the Assembly path to `G:\design-automation-handler\DesignAutomationHandler2019\bin\Release\DesignAutomationHandler.dll`

3. Place your `.addin` for D4R in the same folder(`C:\ProgramData\Autodesk\Revit\Addins\XXXX\`) as above. This will allow Revit to load both addins (`DesignAutomationHandler.addin` and addin for D4R) when it starts up.
In your `.addin` for D4R, change `Assembly` path to where the your addin's dll locates. In this way, you can local debug your addin's dll when we usually develop Revit addin. 
> Design Automation Handler does not expect to handle more than one appbundle for local testing/debugging.

## Usage
Starting Revit:
1. If your addin needs to run on an input Revit model file, then open it from a folder
> If you have json parameter defined for the `WorkItem`, you can save it as a json file where your input Revit is at.
> For example, `{"walls": false,"floors": true,"doors": true,"windows": true}` is saved as `CountItParams.json` in the same folder where the my input file locates. `CountItParams` is the name of parameter I define in the `Activity`

2. Go to `Add-Ins` -> `External Tools`-> `DesignAutomationHandler`, your addin will get excuted! A dialog will pop up to tell the running result (if the runing succeeds the dialog will indicate where to find the output, it should be the folder where your input file is at) 

3. If you don't have input file to run on, after starting Revit, do 2 directly. If you have json parameter defined for the `WorkItem`, there will be a dialog to give the instruction to where to put the json file.  

> You can rerun the same addin without restarting Revit. But to run another addin, you need to follwoing the step above to set it up.  

> Currently, the DAHandler does not support multiple input files, as DA4R does.
