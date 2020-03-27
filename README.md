# Design Automation for Revit - Local debug tool 

![Platforms](https://img.shields.io/badge/Plugins-Windows-lightgray.svg)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.7-blue.svg)
[![Revit](https://img.shields.io/badge/Revit-2018|2019|2020|2021-lightblue.svg)](http://developer.autodesk.com/)

# Description

DesignAutomationHandler is a Revit addin that allows users to run/debug their Design Automation for Revit application locally with desktop Revit. 

# Demonstration

See [step-by-step video](https://www.youtube.com/watch?v=i0LJ9JOpKMQ)

# Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). 
2. **Visual Studio**: [2017 or newer](https://visualstudio.microsoft.com/)
3. **.NET Framework** basic knowledge with C#
4. **Revit** 2019: required to compile changes into the plugin

## Compile and Load on Revit

1. Build the solution `DesignAutomationHandler`, compiling DesignAutomationHandler for Revit 2018.3 (`DesignAutomationHandler2018`), Revit 2019.2 (`DesignAutomationHandler2019`), Revit 2020.0 (`DesignAutomationHandler2020`) and Revit 2021.0 (`DesignAutomationHandler2021`)
> Design Automation for Revit currently only supports Revit 2018, 2019, 2020, and 2021.

2. The `DesignAutomationHandler.addin` should be copied to the "Addins" folder (`C:\ProgramData\Autodesk\Revit\Addins\XXXX\`), see Post-Build event. Note `XXXX` is the Revit version(e.g. 2018, 2019, 2020, 2021) to run against.

3. Place the `.addin` of your Design Automation for Revit plugin in the same folder(`C:\ProgramData\Autodesk\Revit\Addins\XXXX\`) as above. 

> DesignAutomationHandler does not expect to handle more than one addin for local testing/debugging.

> To allow Revit loads your `.addin` correctly, `DesignAutomationBridge.dll` should be in the same folder as your addin's dll is.

## Usage

Starting Revit:

- If your addin needs to run on an input Revit model file, then open it in Revit or specify with startup argument

> If you have json parameter defined to run the `WorkItem` in Design Automation, you can save json payload as a json file where your input file is at.

> For example, `{"walls": false,"floors": true,"doors": true,"windows": true}` is saved as `CountItParams.json` in the same folder where my input file locates. `CountItParams` is the name of parameter I define in the `Activity` for Design Automation. 

- Go to `Add-Ins` -> `External Tools`-> Click `DesignAutomationHandler`, your addin will get excuted! A dialog will pop up to tell the running result (if the runing succeeds the dialog will indicate where to find the output(s), it is supposed to be the folder where your input file is at) 

- If you don't have input file to run on, after starting Revit, do 2 directly. If you have json parameter defined to run the `WorkItem` in Design Automation, there will be a dialog to instruct where to put the json file.  

> You can rerun the same addin without restarting Revit. But to run another addin, you need to following the step above to set it up.  

> Currently, the DesignAutomationHandler does not support multiple input files yet, as Design Automation does.

# Further Reading

Documentation:

- [Design Automation v3](https://forge.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/)

Desktop APIs:

- [My First Revit Plugin](https://knowledge.autodesk.com/support/revit-products/learn-explore/caas/simplecontent/content/my-first-revit-plug-overview.html)

Blog articles:

- [Learn Forge tutorial for Revit](https://forge.autodesk.com/blog/introducing-design-automation-tutorial-autocad-inventor-revit-engines)
- [Design Automation - Debug Revit plugin locally](https://forge.autodesk.com/blog/design-automation-debug-revit-plugin-locally)

## License

Please see the [LICENSE](LICENSE) file for full details.

## Written by

Lijuan Zhu, Ashwin Shivashankar.
