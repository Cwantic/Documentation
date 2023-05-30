---
layout: default
title: command
nav_order: 5
parent: Classes
grand_parent: Python
---

# CustomCommand

A custom command is simply a list of MetaPiping existing commands.

## 1. Creation

A **CustomCommand** object can only be created by **design** object via **createCommand** method :

```python
# Python script
cmd = design.createCommand("MyCommand1")
# ...
```

The **CustomCommand** must be defined by a unique name (first param of the createCommand method).

[See the description of the object design](https://documentation.metapiping.com/Python/Classes/design.html)

## 2. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| addSubCommand | bool | Add an existing command by a name and command params (array) |

Example : 

We want to remove the selected objects.
First, create an empty array, add the selectedList from **design** object.
Then add the name of the remove command and the params to the **CustomCommand**

```python
# Python script
params = []
params.append(design.selectedList)
        
valid = cmd.addSubCommand("RemoveElementCommand", params)
```

Every command has its own param list !

Return False if the command name doesn't exists or the params are incorrect.

## 3. Execution

Finally, a **CustomCommand** (cmd in the example) can be executed by **design** object via **executeCommand** method:

```python
# Python script
# ...
design.executeCommand(cmd)
```

---
## 4. Common objects

Two general objects control all properties of current tee, current material, current section, current bend radius...

    - CurrentTeeValues
    - CurrentPipingValues

You can set the wanted properties before creating a command and share these properties for all commands.

To use these objects, you need to import the classes in your Python script :

```python
# Python script
from Cwantic.MetaPiping.Core import CurrentPipingValues, CurrentTeeValues
```



### 4.1 CurrentTeeValues

If you need to create a **tee**, you can create a **CurrentTeeValues** object and initialize its properties :

```python
# Python script
from Cwantic.MetaPiping.Core import CurrentTeeValues

...

currentTeeValues = CurrentTeeValues()
currentTeeValues.Type = '1'
currentTeeValues.TN = 4.2
currentTeeValues.ConnectorSize = 0.1429
currentTeeValues.BranchSize = 0.1429
```

If you don't need to create a **tee** but need to have a **CurrentTeeValues** for the command, just create an empty object :

```python
# Python script
currentTeeValues = CurrentTeeValues()
```

According to the type of tee, only several properties must be set.

PROPERTIES :

| Name | Type | Description | Unit | Default value |
| --- | ----------- | ----------- | ---| ---|
| Type | char | Type of tee | - | '0' (see below) |
| TN | float | Branch pipe wall thickness | Diameter | 0 |
| RP | float | Branch Outer Radius | Diameter | 0 |
| PD | float | Pad Thickness for Reinforced Fabricated Tees  | Diameter | 0 |
| R2 | float | Branch-to-run Fillet Radius | Diameter | 0 |
| RX | float | Transition Radius | Diameter | 0 |
| Angle | float | Angle between collector and branch | Degree | 0 |
| ConnectorSize | float | Length of collector | Length | 0.3 |
| BranchSize | float | Length of branch | Length | 0.3 |

See [Units](https://documentation.metapiping.com/Design/units.html) for explanation of Length and Diameter units.

Values for **Type** :

| Value | Description |
| ---- | ----------- |
| '0' | Branch connection |
| '1' | Butt welding tee |
| '2' | Junction of elements |
| '3' | Reinforced or un-reinforced fabricated tee |
| '4' | Bonney Forge Sweepolet® (flush welded) |
| '5' | Bonney Forge Sweepolet® (as welded) |
| '6' | Bonney Forge Weldolet® |
| '7' | Extruded Outlet or Extruded welding tee |
| '8' | Welded-in contour insert |
| '9' | Branch welded-on fitting |
| 'L' | Piping lateral connection per WRC Bulletin 360 |
| 'P' | Branch connection with partial penetration welds or fillet welds |

See an example of creation of a [CurrentTeeValues](https://documentation.metapiping.com/Python/Samples/lyre.html).

### 4.2 CurrentPipingValues

The **CurrentPipingValues** object contains all properties needed for piping element as layer, material, section, bend radius...

The easiest way to create a **CurrentPipingValues** object is to create one from an existing piping element (pipe, bend, reducer...), for example from a selected element.

```python
# Python script
from Cwantic.MetaPiping.Core import CurrentPipingValues

...

piping = design.selectedList[0]
model = design.getMetal()

currentPipingValues = CurrentPipingValues.CreateCurrentPipingValuesFromPiping(model, piping)
```

---
## 5. Commands


### 5.1 AddPipeCommand

| Param | Type | Description |
| ---- | ----------- | ----------- |
| X1 | Length  | X value of start point |
| Y1 | Length  | Y value of start point |
| Z1 | Length  | Z value of start point |
| X2 | Length  | X value of end point |
| Y2 | Length  | Y value of end point |
| Z2 | Length  | Z value of end point |
| localX | Length  | X value of local axis |
| localY | Length  | Y value of local axis |
| localZ | Length  | Z value of local axis |
| teeValues | CurrentTeeValues  | Current tee properties (see §4.1) |
| pipingValues | CurrentPipingValues  | Current piping properties (see §4.2) |

Rem : localX, localY, localZ can be set to (0, 0, 0)

See [Units](https://documentation.metapiping.com/Design/units.html) for explanation of Length unit.

Imagine a customCommand cmd, a point p1 (Point3D), a size of pipe (float), a direction (Vector3D), a currentTeeValues and a currentPipingValues, here is how to create a pipe :

```python
# Python script
params = []
params.append(p1.X)
params.append(p1.Y)
params.append(p1.Z)
params.append(p1.X + size*dir[0])
params.append(p1.Y + size*dir[1])
params.append(p1.Z + size*dir[2])
params.append(0.0)
params.append(0.0)
params.append(0.0)
params.append(currentTeeValues)
params.append(currentPipingValues)

valid = cmd.addSubCommand("AddPipeCommand", params)
```

5.2 RemoveElementCommand

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Elements | Array  | Array of element |

See [Element](https://documentation.metapiping.com/Python/Classes/element.html) for more information.

Imagine a customCommand cmd and elements in selection, here is how to remove these elements :

```python
# Python script
params = []
params.append(design.selectedList)

valid = cmd.addSubCommand("RemoveElementCommand", params)
```

5.3 Other commands

Other commands can be explained on demand...