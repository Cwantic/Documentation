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
currentTeeValues.Type = TeeType.BranchConnection
currentTeeValues.TN = 4.2
currentTeeValues.CollectorSize = 0.1429
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
| Type | TeeType | Type of tee | - | BranchConnection (see below) |
| TN | float | Branch pipe wall thickness | Diameter | 0 |
| RP | float | Branch Outer Radius | Diameter | 0 |
| PD | float | Pad Thickness for Reinforced Fabricated Tees  | Diameter | 0 |
| R2 | float | Branch-to-run Fillet Radius | Diameter | 0 |
| RX | float | Transition Radius | Diameter | 0 |
| Angle | float | Angle between collector and branch | Degree | 0 |
| CollectorSize | float | Length of collector | Length | 0.3 |
| BranchSize | float | Length of branch | Length | 0.3 |

See [Units](https://documentation.metapiping.com/Design/units.html) for explanation of Length and Diameter units.

The type *TeeType* is an enumeration with the following values:

| Value | Description |
| ---- | ----------- |
| BranchConnection | Branch connection |
| WeldingTee | Butt welding tee |
| NonStandard | Junction of elements |
| Fabricated | Reinforced or un-reinforced fabricated tee |
| SweepoletFlush | Bonney Forge Sweepolet® (flush welded) |
| SweepoletAsWelded | Bonney Forge Sweepolet® (as welded) |
| Weldolet | Bonney Forge Weldolet® |
| ExtrudedOutlet | Extruded Outlet or Extruded welding tee |
| WeldedInContourInsert | Welded-in contour insert |
| BranchWeldedOnFitting | Branch welded-on fitting |
| Lateral | Piping lateral connection per WRC Bulletin 360 |
| PartialPenetration | Branch connection with partial penetration welds or fillet welds |

See an example of creation of a [CurrentTeeValues](https://documentation.metapiping.com/Python/Samples/lyre.html).

### 4.2 CurrentPipingValues

The **CurrentPipingValues** object contains all properties needed for piping element as layer, material, section, bend radius...

The easiest way to create a **CurrentPipingValues** object is to get the **current one** from design:

```python
# Python script
from Cwantic.MetaPiping.Core import CurrentPipingValues

currentPipingValues = design.getCurrentPipingValues()
```

More properties can be explained on demand...

---
## 5. Commands


### 5.1 DrawPipingCommand

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node  | First extremity of the pipe - cannot be None |
| Node2 | Node  | Second extremity of the pipe - can be None |
| DX | Float  | Distance along X axis of end point from Node1 |
| DY | Float  | Distance along Y axis of end point from Node1 |
| DZ | Float  | Distance along Z axis of end point from Node1 |
| LocalX | Float  | X value of local axis |
| LocalY | Float  | Y value of local axis |
| LocalZ | Float  | Z value of local axis |
| PipingValues | CurrentPipingValues  | Current piping properties (see §4.2) |

Rem : LocalX, LocalY, LocalZ can be set to (0, 0, 0)

Imagine a customCommand cmd, a first node N1, a second node N2, a size of pipe (float), a direction (Vector3D), a currentPipingValues, here is how to create a pipe  :

```python
# Python script
params = []
params.append(N1)
params.append(N2)
params.append(size*dir[0])
params.append(size*dir[1])
params.append(size*dir[2])
params.append(0.0)
params.append(0.0)
params.append(0.0)
params.append(currentPipingValues)

valid = cmd.addSubCommand("DrawPipingCommand", params)
```

You can also write the command in this way :

```python
# Python script
valid = cmd.addSubCommand("DrawPipingCommand", [N1, N2, size*dir[0], size*dir[1], size*dir[2], 0.0, 0.0, 0.0, currentPipingValues])
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

You can also write the command in this way :

```python
# Python script
valid = cmd.addSubCommand("RemoveElementCommand", [design.selectedList])
```

5.3 Other commands

>Other commands can be explained on demand...

5.4 Example

Click [here](https://documentation.metapiping.com/Python/Samples/lyre.html) for a complete example using custom commands : Create a loop.