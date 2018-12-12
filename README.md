# SketchIt Sample

[![.net](https://img.shields.io/badge/.net-4.5-green.svg)](http://www.microsoft.com/en-us/download/details.aspx?id=30653)
[![Design Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://developer.autodesk.com/)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2017-green.svg)](https://www.visualstudio.com/)

## Description

SketchIt is an application that creates walls and floors in a rvt file. It takes a JSON file that specifies the walls and floors to be created, and outputs a new rvt file.

## Dependencies 

This project was built in Visual Studio 2017. Download it [here](https://www.visualstudio.com/).

This sample references Revit 2018's `RevitAPI.dll`, [DesignAutomationBridge.dll](https://revitio.s3.amazonaws.com/documentation/DesignAutomationBridge.dll) for Revit 2018 and [Newtonsoft JSON framework](https://www.newtonsoft.com/json).

In order to POST appbundles, activities, and workitems you must have credentials for [Forge](../Docs/Forge.md).

## Building SketchIt.sln

Download [DesignAutomationBridge.dll](https://revitio.s3.amazonaws.com/documentation/DesignAutomationBridge.dll) for Revit 2018 and [Newtonsoft JSON framework](https://www.newtonsoft.com/json). DesignAutomationBridge.dlls for other Revit versions can be found [here](../Docs/AppBundle.md#engine-version-aliases).

Find `RevitAPI.dll` in your Revit 2018 install location and note its location. 

Clone this repository and open `SketchIt.sln` in Visual Studio.  

In the SketchIt C# project, repair the references to `DesignAutomationBridge`, `Newtonsoft JSON framework` and `RevitAPI`.  You can do this by removing and re-adding the references, or by opening the `SketchIt.csproj` for edit and manually updating the reference paths.

Build `SketchIt.sln` in `Release` or `Debug` configuration.

## Creating and Publishing the Appbundle

Create an `appbundle` zip package from the build outputs and publish the `appbundle` to Design Automation.

The `JSON` in your appbundle POST should look like this:
```json
{
  "id": "SketchItApp",
  "engine": "Autodesk.Revit+2018",
  "description": "SketchIt appbundle based on Revit 2018"
}
```
Notes:
* `engine` = `Autodesk.Revit+2018` - A list of engine versions can be found [here](../Docs/AppBundle.md#engine-version-aliases).

After you upload the `appbundle` zip package, you should create an alias for this appbundle. The `JSON` in the POST should look like this:
```json
{
  "version": 1,
  "id": "test"
}
```

> **The instructions for these steps and more about `appbundle` are [here](../Docs/AppBundle.md)**.

## Creating the Activity

Define an `activity` to run against the `appbundle`.

The `JSON` that accompanies the `activity` POST will look like this:

```json
{
   "id": "SketchItActivity",
   "commandLine": [ "$(engine.path)\\\\revitcoreconsole.exe /al $(appbundles[SketchItApp].path)" ],
   "parameters": {
      "sketchItInput": {
         "zip": false,
         "ondemand": false,
         "verb": "get",
         "description": "SketchIt input parameters",
         "required": true,
         "localName": "SketchItInput.json"
      },
      "result": {
         "zip": false,
         "ondemand": false,
         "verb": "put",
         "description": "Results",
         "required": true,
         "localName": "sketchIt.rvt"
      }
   },
   "engine": "Autodesk.Revit+2018",
   "appbundles": [ "YourNickname.SketchItApp+test" ],
   "description": "Creates walls and floors from an input JSON file."
}
```
Notes:
*  `engine` = `Autodesk.Revit+2018` - A list of engine versions can be found [here](../Docs/Appbundle.md#engine-version-aliases).
*  `YourNickname` - The owner of appbundle `SketchItApp`. More information can be found [here](../Docs/Nickname.md).

Then you should create an alias for this activity. The `JSON` in the POST should look like this:
```json
{
  "version": 1,
  "id": "test"
}
```

> **The instructions for these steps and more about `activity` are [here](../Docs/Activity.md)**.

## POST a WorkItem

Now POST a `workitem` against the `activity` to run a job on your `appbundle`.

The `JSON` that accompanies the `workitem` POST will look like this:

```json
{
  "activityId": "YourNickname.SketchItActivity+test",
  "arguments": {
    "sketchItInput": {
      "url": "data:application/json,{ 'walls': [ {'start': { 'x': -100, 'y': 100, 'z': 0.0}, 'end': { 'x': 100, 'y': 100, 'z': 0.0}}, {'start': { 'x': -100, 'y': 100, 'z': 0.0}, 'end': { 'x': 100, 'y': 100, 'z': 0.0}}, {'start': { 'x': 100, 'y': 100, 'z': 0.0}, 'end': { 'x': 100, 'y': -100, 'z': 0.0}}, {'start': { 'x': 100, 'y': -100, 'z': 0.0}, 'end': { 'x': -100, 'y': -100, 'z': 0.0}}, {'start': { 'x': -100, 'y': -100, 'z': 0.0}, 'end': { 'x': -100, 'y': 100, 'z': 0.0}}, {'start': { 'x': -500, 'y': -300, 'z': 0.0}, 'end': { 'x': -300, 'y': -300, 'z': 0.0}}, {'start': { 'x': -300, 'y': -300, 'z': 0.0}, 'end': { 'x': -300, 'y': -500, 'z': 0.0}}, {'start': { 'x': -300, 'y': -500, 'z': 0.0}, 'end': { 'x': -500, 'y': -500, 'z': 0.0}}, {'start': { 'x': -500, 'y': -500, 'z': 0.0}, 'end': { 'x': -500, 'y': -300, 'z': 0.0}}],'floors' : [ [{'x': -100, 'y': 100, 'z':0.0}, {'x': 100, 'y': 100, 'z': 0.0}, {'x': 100, 'y': -100, 'z': 0.0}, {'x': -100, 'y': -100, 'z': 0.0}], [{'x': -500, 'y': -300, 'z':0.0}, {'x': -300, 'y': -300, 'z': 0.0}, {'x': -300, 'y': -500, 'z': 0.0}, {'x': -500, 'y': -500, 'z': 0.0}] ]}"
    },
    "result": {
      "verb": "put",
      "url": "https://myWebsite/signed/url/to/sketchIt.rvt"
    }
  }
}
```
Notes:
* `YourNickname` - The owner of activity `SketchItActivity`. More information can be found [here](../Docs/Nickname.md).

> **The instructions for this step and more about `workitem` are [here](../Docs/WorkItem.md)**.

`SketchItActivity` expects an input file `SketchItInput.json`. The contents of the embedded JSON are stored in a file named `SketchItInput.json`, as specified by the `parameters` of `sketchItInput` in the activity `SketchItActivity`. The SketchIt application reads this file from current working folder, parses the JSON and creates walls and floors from the extracted specifications in a new created Revit file `sketchIt.rvt`, which will be uploaded to `url` you provide in the workitem.

The function `SketchItFunc` in [SketchIt.cs](SketchItApp/SketchIt.cs) performs these operations.
