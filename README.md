# Design Automation for Revit - Local debug tool 

![Platforms](https://img.shields.io/badge/Plugins-Windows-lightgray.svg)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)
[![Revit](https://img.shields.io/badge/Revit-2018|2019|2020|2021|2022|2023-lightblue.svg)](http://developer.autodesk.com/)

# Description

DesignAutomationHandler is a Revit addin that allows users to run and debug their Design Automation for Revit application locally using desktop Revit. 

# Demonstration

See [step-by-step video](https://www.youtube.com/watch?v=i0LJ9JOpKMQ)

# Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate your subscription, and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). 
2. **Visual Studio**: [2019 or newer](https://visualstudio.microsoft.com/)
3. **.NET Framework** basic knowledge with C#
4. **Revit** 2019: required for compiling plugin changes

## Compile and Load on Revit

1. Build the solution `DesignAutomationHandler`, compiling DesignAutomationHandler for Revit 2018 (`DesignAutomationHandler2018`), Revit 2019 (`DesignAutomationHandler2019`), Revit 2020 (`DesignAutomationHandler2020`), Revit 2021 (`DesignAutomationHandler2021`), Revit 2022 (`DesignAutomationHandler2022`), and Revit 2023 (`DesignAutomationHandler2023`)
> Design Automation for Revit currently supports Revit 2018, 2019, 2020, 2021, 2022, and 2023.

2. Copy/paste the `DesignAutomationHandler.addin` into the "Addins" folder `C:\ProgramData\Autodesk\Revit\Addins\XXXX\`, where `XXXX` is the Revit version (e.g. 2018, 2019, 2020, 2021, 2022, 2023) you intend to run.

3. Copy/paste the `.addin` file of your Design Automation for Revit plugin into the same folder `C:\ProgramData\Autodesk\Revit\Addins\XXXX\`. 

> DesignAutomationHandler doesn't support local testing/debugging of more than one addin at a time.

> Revit needs the `DesignAutomationBridge.dll` to be in the same folder as your addin's dlls.

## Usage

Starting Revit:

- If your addin requires an input Revit model at startup, then open the file in Revit before running the addin or specify the file using a startup argument.

> If you have json parameter defined to run the `WorkItem` in Design Automation, you can save the json payload as a json file in the same folder as your input Revit file.

> For example: if `CountItParams` is the name of the parameter defined in the your Design Automation `Activity`, then you should create a file `CountItParams.json` with contents `{"walls": false,"floors": true,"doors": true,"windows": true}` and save it to the folder which contains your input Revit model.  

- In the Revit ribbon, navigate to the `Add-Ins` tab, then click `External Tools`, and click the `DesignAutomationHandler` command. Your addin will by executed! A dialog will pop-up to report the execution result. If the execution was successful, the dialog will indicate where you can find the output(s). They go to the folder which contained your input files. 

- If your plugin doesn't require any input files, start Revit and run the `DesignAutomationHandler` command without any additional setup. If you have json parameter defined to run the `WorkItem` in Design Automation, a dialog will instruct you where to put your json file.  

> You can rerun the same addin without restarting Revit. 

> To run different addin, repeat the setup steps above.

> Currently, the DesignAutomationHandler doesn't support multiple input files.  (This feature is supported by Design Automation on Forge.)

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

Lijuan Zhu and Ashwin Shivashankar
