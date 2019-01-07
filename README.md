# Design Automation Handler

## About
DAHandler is an Addin for desktop Revit that allows users to run their basic Design Automation for Revit application locally. 

## Installation
Place `DesignAutomationHandler.addin` along with `DesignAutomationHandler.dll` in the "Addins" folder under `C:\ProgramData\Autodesk\Revit\Addins\XXXX\` where `XXXX` is the Revit versions to run against.
> Design Automation for Revit currently only supports Revit versions 2018 and 2019.

Place your `.addin` and `.dll` in the same folder as above. This will allow Revit to load both addins.
> Design Automation Handler does not handle more than one appbundle for local testing.

## Usage
After starting Revit, a dialog will open asking to select an input revit file. 
Once selected, DesignAutomationHandler will simulate the cloud execution of the Design Automation for Revit app.

> Currently, the DAHandler does not support multiple input files, as DA4R does.