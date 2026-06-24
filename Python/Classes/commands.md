---
layout: default
title: command
nav_order: 5
parent: Classes
grand_parent: Python
---

{: .warning }
>ATTENTION, MetaPiping and MetaStructure internally use MKS units during modelization and calculation. So, the units of the parameters of commands must be entered in MKS units too.

MKS Base Units :

| Physical quantity | MKS unit | Unit symbol |
|-------------------|----------|-------------|
| Length            | metre    | m           |
| Mass              | kilogram | kg          |
| Time              | second   | s           |

MKS Derived Units (informative) :

| Derived quantity        | Expression in MKS base units | Derived unit | Symbol |
|-------------------------|-------------------------------|--------------|--------|
| Velocity                | m·s⁻¹                         | —            | m/s    |
| Acceleration            | m·s⁻²                         | —            | m/s²   |
| Force                   | kg·m·s⁻²                     | newton       | N      |
| Work / Energy           | kg·m²·s⁻²                   | joule        | J      |
| Power                   | kg·m²·s⁻³                   | watt         | W      |
| Pressure                | kg·m⁻¹·s⁻²                  | pascal       | Pa     |
| Momentum                | kg·m·s⁻¹                    | —            | —      |
| Density                 | kg·m⁻³                      | —            | —      |
| Viscosity (dynamic)     | kg·m⁻¹·s⁻¹                 | pascal·second| Pa·s   |
| Electric charge         | A·s                           | coulomb      | C      |
| Electric potential      | kg·m²·s⁻³·A⁻¹               | volt         | V      |
| Magnetic flux           | kg·m²·s⁻²·A⁻¹               | weber        | Wb     |
| Magnetic flux density   | kg·s⁻²·A⁻¹                  | tesla        | T      |

# CustomCommand

A custom command is simply a **LIST** of MetaPiping existing commands.

## 1. Creation

A **CustomCommand** object can be created by **study** and **design** object via **createCommand** method :

```python
# Python script
cmd = design.createCommand("MyCommand1")
# ...
```

or 

```python
# Python script
cmd = study.createCommand("MyCommand1", metal)
```

[See the description of the object design](https://documentation.metapiping.com/Python/Classes/design.html)

[See the description of the object study](https://documentation.metapiping.com/Python/Classes/study.html)

## 2. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| addSubCommand | Bool | Add an existing command by a name and command params (array) |

Example :

Imagine a customCommand cmd where we want to draw a new pipe. The parameters are a first node N1, a second node N2, a size of pipe (float), a direction (Vector3D), and a currentPipingValues  :

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

Every command has its own param list !

Return False if the command name doesn't exists or the params are incorrect.

## 3. Execution

Finally, a **CustomCommand** (cmd in the example) can be executed by **study** or **design** object via **executeCommand** method:

```python
# Python script
design.executeCommand(cmd)
```

or

```python
# Python script
study.executeCommand(cmd, dir) # metaL and fre will be modified in dir
```


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

currentTeeValues = CurrentTeeValues()
currentTeeValues.Type = TeeType.BranchConnection
currentTeeValues.CollectorSize = 0.1429
currentTeeValues.BranchSize = 0.1429
...
```

If you don't need to create a **tee** but need to have a **CurrentTeeValues** for the command, just create an empty object :

```python
# Python script
currentTeeValues = CurrentTeeValues()
```

According to the type of tee, only several properties must be set.

PROPERTIES :

| Name | Type | Description | Default value |
| --- | ----------- | ----------- | --- |
| Type | TeeType | Type of tee | BranchConnection (see below) |
| TN | Float | Branch pipe wall thickness | 0 |
| RP | Float | Branch Outer Radius | 0 |
| PD | Float | Pad Thickness for Reinforced Fabricated Tees | 0 |
| R2 | Float | Branch-to-run Fillet Radius | 0 |
| RX | Float | Transition Radius | 0 |
| Angle | Float | Angle between run and branch | 0 |
| CollectorSize | Float | Length of run | 0.3 |
| BranchSize | Float | Length of branch | 0.3 |

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

The **CurrentPipingValues** object contains all properties needed for piping and beam element as layer, material, section, bend radius...

The easiest way to create a **CurrentPipingValues** object is to get the **current one** from design:

```python
# Python script
currentPipingValues = design.getCurrentPipingValues()
```

or in study, where no values are set, you can create an empty one and fill the desired properties :

```python
# Python script
from Cwantic.MetaPiping.Core import CurrentPipingValues

currentPipingValues = CurrentPipingValues()
```

Properties :

| Property | Type | Description |
| ---- | ----------- | --- |
| Layer | Layer | For all element : see types page |
| Label | String | For all element |
| MaterialName | String | Name of the material |
| SpecMaterial | MaterialModel | For all piping element : see types page |
| SectionName | String | Name of the section |
| SpecPipe | PipeModel | For all piping element : see types page |
| SpecSection | SpecificationPipe | |
| IsGlue | Bool | For composite only |
| MKS_BendRadius | Float | For bend only : Radius |
| MKS_BendMiter | Bool | For bend only : Miter or not ? |
| MKS_BendSpacing | Float | For bend only : Length of miter elements |
| MKS_BendElements | Int | For bend only : Number of miter elements |
| MKS_BendFlange | Int | For bend only : Number of flanges |
| MKS_BendFlex | Float | For bend only : Flexibility |
| SpecBend | SpecificationBend | For bend only : see types page |
| MKS_ReducerLength | Float | For reducer only : Length |
| MKS_ReducerAngle | Float | For reducer only : Angle |
| MKS_ReducerFlexibilityFactor | Float | For reducer only : Flexibility factor |
| MKS_ReducerL12 | Float | For reducer only : L12 value |
| MKS_ReducerR12 | Float | For reducer only : R12 value |
| SpecReducer | SpecificationReducer | For reducer only : see types page |
| NodeJointType | JointType | Node joint type see types page |
| MKS_NodeMismatch | Float | Mismatch at node |
| MKS_NodeFilletLength | Float | Fillet length at node |
| MKS_NodeTMax | Float | TMax at node |
| NextNodeName | String | Force the name of the next node |
| LongWeldType | LongWeldType | Type of longitudinal weld see types page |
| MKS_LongWeldMismatch | Float | Mismatch of longitudinal weld |
| MKS_EffectiveDiameter | Float | Class 1 only : effective diameter of pipe section |
| MKS_EffectiveThickness | Float | Class 1 only : effective thickness of pipe section |
| MKS_SpecBeamSection | BeamSection | For beam only : see types page |
| BeamExtremity1 | BeamExtremity | For beam only : see types page |
| BeamExtremity2 | BeamExtremity | For beam only : see types page |
| BeamIndexExtremity1 | Int | For beam only : the index of the beam to apply the BeamExtremity1 |
| BeamIndexExtremity2 | Int | For beam only : the index of the beam to apply the BeamExtremity2 |
| BeamOffset1 | Float | For beam only : offset at extremity1 after BeamExtremity |
| BeamOffset2 | Float | For beam only : offset at extremity2 after BeamExtremity |
| BeamJoint1 | Joint | For beam only : joint at extremity1 see types page |
| BeamJoint2 | Joint | For beam only : joint at extremity2 see types page |
| Joint1PlateMaterial | MaterialModel | For beam only, bolted joint1 : plate material see types page |
| Joint1BoltMaterial | MaterialModel | For beam only, bolted joint1 : bolt material see types page |
| Joint1WeldMaterial | MaterialModel | For beam only, welded joint1 : weld material see types page |
| Joint2PlateMaterial | MaterialModel | For beam only, bolted joint2 : plate material see types page |
| Joint2BoltMaterial | MaterialModel | For beam only, bolted joint2 : bolt material see types page |
| Joint2WeldMaterial | MaterialModel | For beam only, welded joint2 : weld material see types page |
| BeamBucklingX | Float | For beam only : buckling along X |
| BeamBucklingY | Float | For beam only : buckling along Y |
| BeamBucklingZ | Float | For beam only : buckling along Z |
| BeamLTBModel | LTBModel | For beam only : LTB model see types page |
| BeamIsCable | Bool | For beam only : is the beam a cable ? |

[See the description of the object MaterialModel](https://documentation.metapiping.com/Python/Classes/material.html)

## 5. All commands

    A command is an instruction to MetaPiping/MetaStructure to modify the 3D model (metaL)

All commands can be imported via **Cwantic.MetaPiping.Core** library :

```python
# Python script
from Cwantic.MetaPiping.Core import xxxCommand # Replace xxxCommand by a real command

cmd = xxxCommand() # Replace xxxCommand by a real command
...
```

### 5.1 Common commands

#### 5.1.1 ChangeDirectionCommand

Change the direction of an element (piping element or beam).

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| DX | Float | X component of the new direction |
| DY | Float | Y component of the new direction |
| DZ | Float | Z component of the new direction |
| Shift | Bool | Shift the next elements ? |

REM : (DX, DY, DZ) will replace the DL vector of the element.

#### 5.1.2 ChangeElementIndexCommand

Change the position (index) of an element in model.Elements.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| Index | Int | New index |

REM : Index start from 0

#### 5.1.3 ChangeElementLabelCommand

Change the label of an element.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| Label | String | New label |

#### 5.1.4 ChangeElementLengthCommand

Change the length of an element (piping element or beam). Not bend.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| Length | Float | New length |
| Shift | Bool | Shift the next elements ? |

REM : if length = 0, the element will be removed and the adjacent ones reconnected.

REM : if shift = False, the new length must not exceed the actual length + next element length.

#### 5.1.5 ChangeElementXDirCommand

Change the XDir direction of an element. XDir represents the local X (weak axis) for a beam.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| XDir | Vector3D | New direction |

REM : Vector3D comes from the library *System.Windows.Media.Media3D*

```python
# Python script
from System.Windows.Media.Media3D import Vector3D

XDir = Vector3D(1, 0, 0)
...
```

#### 5.1.6 ChangeNodesElementCommand

Change Node1 and Node2 of an element. Only for beams !!!

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing beam |
| Node1 | Node | New existing Node1 |
| Node2 | Node | New existing Node2 |

#### 5.1.7 CopyCommand

Copy a list of elements in translation, rotation or mirror with repetition.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Elements | `List<Element>` | List of existing element |
| Mode | CopyMode | see below |
| Params | `List<double>` | Params of the copy, see below |
| Repetition | Int | 1 by default, only for translation and rotation |

```python
# Python script
from Cwantic.MetaPiping.Core import Element
from System.Collections.Generic import List

...
# Creation of a C# list
Elements = List[Element]()
Elements.Add(element1) # Use Add instead of append with C# list !

Params = List[double]()
Params.Add(10)
...
```

CopyMode :

    CopyMode.Translation
    CopyMode.Rotation
    CopyMode.Mirror

Params :

    CopyMode.Translation :
        - Params[0] = Dx
        - Params[1] = Dy
        - Params[2] = Dz
    CopyMode.Rotation :
        - Params[0] = Xcenter
        - Params[1] = Ycenter
        - Params[2] = Zcenter
        - Params[3] = 0 for global Xaxis, 1 for global Yaxis, 2 for global Zaxis
        - Params[4] = Angle
    CopyMode.Mirror :
        - Params[0] = Nx
        - Params[1] = Ny
        - Params[2] = Nz
        - Params[3] = Nd

REM : (Dx, Dy, Dz) is the translation vector

REM : The rotation rotates Angle ° around (Xcenter, Ycenter, Zcenter) and a specified global axis

REM : (Nx, Ny, Nz, Nd) are the parametric values of a global plane

#### 5.1.8 CutCommandEx

Cut an element (piping or beam) in two parts from a node and a distance.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| Node | Node | One of the 2 extremities of the element |
| Distance | Float | Distance of the cut from node along the element |
| NodeName | String | Name of the new node |
| Intersection | Bool | Use the intersection points in case of adjacent bends ? |

REM : if Intersection = True, the distance is given from that point instead of the node

#### 5.1.9 CutNCommandEx

Cut an element (piping or beam) in aNumber of equal elements. aNumber > 1.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Element | Element | Existing element |
| Number | Float | Number of elements |
| Intersection | Bool | Use the intersection points in case of adjacent bends ? |

REM : if Intersection = True, the distance to cut is given from that point instead of the extremity nodes

#### 5.1.10 MergeCommand

Merge of 2 colinear elements of same type and properties on node.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Selected node |

REM : the node will be removed as well as force/moment on that node, lump mass, Local coordinates...

#### 5.1.11 ModifyPipingSectionCommand

Modify the section of pipings. Set the section in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Pipings | `List<Piping>` | List of existing pipings |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

```python
# Python script
from Cwantic.MetaPiping.Core import Piping
from System.Collections.Generic import List

...
# Creation of a C# list
Pipings = List[Piping]()
Pipings.Add(piping1) # Use Add instead of append with C# list !
...
```

[See the description of the object Piping](https://documentation.metapiping.com/Python/Classes/element.html)

#### 5.1.12 ModifyStressOnOffCommand

Modify the stress On/Off property of pipings. The list can contain *object* but the command will operate only on *piping*.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Pipings | `List<object>` | List of objects |
| Value | Bool | True = On, False = Off |

```python
# Python script
from System import object
from System.Collections.Generic import List

...
# Creation of a C# list
Pipings = List[object]()
Pipings.Add(piping1) # Use Add instead of append with C# list !
...
```

#### 5.1.13 MoveNodesCommand

Move a list of nodes in translation

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of node |
| DX | Float | X component of the translation |
| DY | Float | Y component of the translation |
| DZ | Float | Z component of the translation |
| Update | Bool | Update adjacent elements on nodes |

```python
# Python script
from Cwantic.MetaPiping.Core import Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !
...
```

#### 5.1.14 MoveNodesCommand

Move a list of nodes in translation, rotation or mirror

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| Mode | MoveMode | See types page |
| Params | `List<double>` | See below |

```python
# Python script
from System import Double
from System.Collections.Generic import List
from Cwantic.MetaPiping.Core import Node

...
# Creation of a C# List
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !
...

Params = List[Double]()
Params.Add(0)
Params.Add(0)
Params.Add(1)
...
```

Params :

    MoveMode.Translation :
        - Params[0] = Dx
        - Params[1] = Dy
        - Params[2] = Dz
    MoveMode.Rotation :
        - Params[0] = Xcenter
        - Params[1] = Ycenter
        - Params[2] = Zcenter
        - Params[3] = 0 for global Xaxis, 1 for global Yaxis, 2 for global Zaxis
        - Params[4] = Angle
    MoveMode.Mirror :
        - Params[0] = Nx
        - Params[1] = Ny
        - Params[2] = Nz
        - Params[3] = Nd  

REM : (Dx, Dy, Dz) is the translation vector

REM : The rotation rotates Angle ° around (Xcenter, Ycenter, Zcenter) and a specified global axis

REM : (Nx, Ny, Nz, Nd) are the parametric values of a global plane

#### 5.1.15 RemoveElementCommand

Remove a list of elements.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Elements | `List<Element>` | List of element |

```python
# Python script
from Cwantic.MetaPiping.Core import Element
from System.Collections.Generic import List

...
# Creation of a C# list
Elements = List[Element]()
Elements.Add(element1) # Use Add instead of append with C# list !
...
```

#### 5.1.16 SetDesignConditionCommand

Set the design conditions on pipings.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Design | OperatingCondition | See types page |
| Pipings | `List<Piping>` | List of pipings |

```python
# Python script
from Cwantic.MetaPiping.Core import Piping
from System.Collections.Generic import List

...
# Creation of a C# list
Pipings = List[Piping]()
Pipings.Add(piping1) # Use Add instead of append with C# list !
...
```

[See the description of the object Piping](https://documentation.metapiping.com/Python/Classes/element.html)

#### 5.1.17 SetEndConditionCommand

Set the connection on nodes.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| JointType | JointType | See types page |
| Mismatch | Float | Mismatch for butt welds, as welded |
| FilletLength | Float | Length of fillet weld |
| TMax | Float | tmax for Class 1 transition within 1:3 slope envelope |
| Nodes | `List<Node>` | List of nodes |

```python
# Python script
from Cwantic.MetaPiping.Core import Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !
...
```

#### 5.1.18 SetRoomTemperatureCommand

Set the room temperature on elements.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Temperature | Float | Room temperature, can be None |
| Elements | `List<Element>` | List of elements |

```python
# Python script
from Cwantic.MetaPiping.Core import Element
from System.Collections.Generic import List

...
# Creation of a C# list
Elements = List[Element]()
Elements.Add(element1) # Use Add instead of append with C# list !
...
```

REM : set Temperature = None to remove the property to the selected elements

### 5.2 Anchor

#### 5.2.1 CreateAnchorCommand

Add an anchor on nodes. Added on **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Kx | float | Stiffness along X: 0 if free, > 0 if rigid |
| Ky | float | Stiffness along Y: 0 if free, > 0 if rigid |
| Kz | float | Stiffness along Z: 0 if free, > 0 if rigid |
| Krx | float | Stiffness around X: 0 if free, > 0 if rigid |
| Kry | float | Stiffness around Y: 0 if free, > 0 if rigid |
| Krz | float | Stiffness around Z: 0 if free, > 0 if rigid |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.2.2 ModifyRestraintsToAnchorCommand

Modify selected restraints to anchor.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of existing restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Kx | float | Stiffness along X: 0 if free, > 0 if rigid |
| Ky | float | Stiffness along Y: 0 if free, > 0 if rigid |
| Kz | float | Stiffness along Z: 0 if free, > 0 if rigid |
| Krx | float | Stiffness around X: 0 if free, > 0 if rigid |
| Kry | float | Stiffness around Y: 0 if free, > 0 if rigid |
| Krz | float | Stiffness around Z: 0 if free, > 0 if rigid |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

### 5.3 Anchor plate

#### 5.3.1 CreateAnchorPlateCommand

Add an anchor plate on a node. Added on **model.Restraints**.

Only available on **MetaStructure**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Existing node |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Element | Element | Attached element on node. Must be a beam |
| Level | String | Level (for seismic analysis) |
| Kx | float | Stiffness along X: 0 if free, > 0 if rigid |
| Ky | float | Stiffness along Y: 0 if free, > 0 if rigid |
| Kz | float | Stiffness along Z: 0 if free, > 0 if rigid |
| Krx | float | Stiffness around X: 0 if free, > 0 if rigid |
| Kry | float | Stiffness around Y: 0 if free, > 0 if rigid |
| Krz | float | Stiffness around Z: 0 if free, > 0 if rigid |
| Layer | Layer | Layer, see types page |
| AnchorPlate | AnchorPlate | Temporary plate, see types page |
| PlateMaterial | MaterialModel | Plate material, can be None, see types page |
| WeldMaterial | MaterialModel | Weld material, can be None, see types page |

REM : a temporary anchor plate must be created first

REM : the label of the temporary AnchorPlate will be used

```python
# Python script
from Cwantic.MetaPiping.Core import AnchorPlate

anchorPlate = AnchorPlate()
...
```

[More info on the anchor plate definition](https://documentation.metapiping.com/Structure/Elements/Restraint.html#2-anchor-plate)

#### 5.3.2 ModifyRestraintsToAnchorPlateCommand

Modify selected restraints to anchor plate. Only available on **MetaStructure**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of existing restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Element | Element | Attached element on node. Must be a beam |
| Level | String | Level (for seismic analysis) |
| Kx | float | Stiffness along X: 0 if free, > 0 if rigid |
| Ky | float | Stiffness along Y: 0 if free, > 0 if rigid |
| Kz | float | Stiffness along Z: 0 if free, > 0 if rigid |
| Krx | float | Stiffness around X: 0 if free, > 0 if rigid |
| Kry | float | Stiffness around Y: 0 if free, > 0 if rigid |
| Krz | float | Stiffness around Z: 0 if free, > 0 if rigid |
| Layer | Layer | Layer, see types page |
| AnchorPlate | AnchorPlate | Temporary plate, see types page |
| PlateMaterial | MaterialModel | Plate material, can be None, see types page |
| WeldMaterial | MaterialModel | Weld material, can be None, see types page |

REM : a temporary anchor plate must be created first

REM : the label of the temporary AnchorPlate will be used

```python
# Python script
from Cwantic.MetaPiping.Core import Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !
...
```

### 5.4 Beam

#### 5.4.1 AddBeamCommand

Add a predefined beam with its properties. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the beam - cannot be None |
| Node2 | Node | Second extremity of the beam - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| E | Float | Young modulus - 0 if property from material |
| R1 | Bool | Extremity1 released ? |
| R2 | Bool | Extremity2 released ? |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the beam |
| LocalX | Float | X component of weak X axis |
| LocalY | Float | Y component of weak X axis |
| LocalZ | Float | Z component of weak X axis |
| Type | BeamSectionType | See types page |
| SectionName | String | Name of the section |
| H | Float | Height of the section |
| B | Float | Width of the section |
| Tw | Float | Thickness of the web |
| Tf | Float | Thickness of the flanges |
| A | Float | Section area |
| Ax | Float | Shear area in X axis |
| Ay | Float | Shear area in Y axis |
| Ix | Float | Weak inertia around X |
| Iy | Float | Strong inertia around Y |
| It | Float | Torsional inertia |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

#### 5.4.2 AddBeamCommand

Add a beam based on current piping and structure values. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the beam - cannot be None |
| Node2 | Node | Second extremity of the beam - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the beam |
| LocalX | Float | X component of weak X axis |
| LocalY | Float | Y component of weak X axis |
| LocalZ | Float | Z component of weak X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.4.3 AddBeamCommand

Add an already created beam.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Already created beam - cannot be None |

#### 5.4.4 ChangeBeamBucklingCommand

Change the buckling values of an existing beam.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| BucklingX | Float | Buckling along X |
| BucklingY | Float | Buckling along Y |
| BucklingZ | Float | Buckling along Z |
| LTBModel | LTBModel | See types page |

#### 5.4.5 ChangeBeamCableCommand

Change the *Cable* property of an existing beam.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| Cable | Bool | True or False |

#### 5.4.6 ChangeBeamExtremityCommand

Change the graphic ending of an existing beam.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| Side | Int | 1 or 2 |
| BeamExtremity | BeamExtremity | see types page |
| BeamIndex | Int | Index of connected beam |
| Offset | Float | Offset of the ending beam plane |

#### 5.4.7 InsertBeamCommand

Insert a beam tangent to the preceding element. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the beam |
| Mode | InsertMode | Mode of insertion, see types page |
| E | Float | Young modulus - 0 if property from material |
| R1 | Bool | Extremity1 released ? |
| R2 | Bool | Extremity2 released ? |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the beam |
| LocalX | Float | X component of weak X axis |
| LocalY | Float | Y component of weak X axis |
| LocalZ | Float | Z component of weak X axis |
| Type | BeamSectionType | See types page |
| SectionName | String | Name of the section |
| H | Float | Height of the section |
| B | Float | Width of the section |
| Tw | Float | Thickness of the web |
| Tf | Float | Thickness of the flanges |
| A | Float | Section area |
| Ax | Float | Shear area in X axis |
| Ay | Float | Shear area in Y axis |
| Ix | Float | Weak inertia around X |
| Iy | Float | Strong inertia around Y |
| It | Float | Torsional inertia |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

#### 5.4.8 ModifyBeamCommand

Modify an existing beam. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| E | Float | Young modulus - 0 if property from material |
| R1 | Bool | Extremity1 released ? |
| R2 | Bool | Extremity2 released ? |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the beam |
| LocalX | Float | X component of weak X axis |
| LocalY | Float | Y component of weak X axis |
| LocalZ | Float | Z component of weak X axis |
| Type | BeamSectionType | See types page |
| SectionName | String | Name of the section |
| H | Float | Height of the section |
| B | Float | Width of the section |
| Tw | Float | Thickness of the web |
| Tf | Float | Thickness of the flanges |
| A | Float | Section area |
| Ax | Float | Shear area in X axis |
| Ay | Float | Shear area in Y axis |
| Ix | Float | Weak inertia around X |
| Iy | Float | Strong inertia around Y |
| It | Float | Torsional inertia |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

#### 5.4.9 ModifyBeamCommand

Modify an existing beam based on current piping and structure values. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the beam |
| LocalX | Float | X component of weak X axis |
| LocalY | Float | Y component of weak X axis |
| LocalZ | Float | Z component of weak X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.4.10 ModifyBeamCommand

Modify an existing beam based only on current piping and structure values. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beam | Beam | Existing beam |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.4.11 ModifyBeamSectionCommand

Modify the section of a list of beam based only on current piping and structure values. Set the section in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Beams | `List<Beam>` | Existing beams |
| PipingValues | CurrentPipingValues | see §4.2, used for section definition |

```python
# Python script
from Cwantic.MetaPiping.Core import Beam
from System.Collections.Generic import List

...
# Creation of a C# list
Beams = List[Beam]()
Beams.Add(beam1) # Use Add instead of append with C# list !
...
```

#### 5.4.12 RemoveBeamConnectivityCommand

Remove the selected beams from the *ExtremityaBeam* and *Extremity2Beam* properties of all beams of the metal before these selected beams will be removed.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Elements | `List<Element>` | List of beams that must be disconnected to all beams |

```python
# Python script
from Cwantic.MetaPiping.Core import Element
from System.Collections.Generic import List

...
# Creation of a C# list
Elements = List[Element]()
Elements.Add(element1) # Use Add instead of append with C# list !
...
```

REM : The command will check that the *Elements* are beams.

### 5.5 Bellow

#### 5.5.1 AddBellowCommand

Add a bellow. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the bellow - cannot be None |
| Node2 | Node | Second extremity of the bellow - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| Type | BellowType | See below |
| DistributedMass | Float | Distributed mass of the bellow |
| PressureArea | Float | Pressure area |
| AxialStiffness | Float | Axial stiffness |
| LateralStiffness | Float | Lateral stiffness |
| AngularStiffness | Float | Angular stiffness |
| TorsionalStiffness | Float | Torsional stiffness |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

BellowType :

    BellowType.Axial
    BellowType.LateralSingle
    BellowType.LateralAll
    BellowType.AngularSingle
    BellowType.AngularAll

#### 5.5.2 InsertBellowCommand

Insert a bellow tangent to the preceding element. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the bellow |
| Mode | InsertMode | Mode of insertion, see types page |
| Type | BellowType | See below |
| DistributedMass | Float | Distributed mass of the bellow |
| PressureArea | Float | Pressure area |
| AxialStiffness | Float | Axial stiffness |
| LateralStiffness | Float | Lateral stiffness |
| AngularStiffness | Float | Angular stiffness |
| TorsionalStiffness | Float | Torsional stiffness |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

BellowType :

    BellowType.Axial
    BellowType.LateralSingle
    BellowType.LateralAll
    BellowType.AngularSingle
    BellowType.AngularAll

#### 5.5.3 ModifyBellowCommand

Modify an existing bellow based on current piping values. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Bellow | Bellow | Existing bellow |
| Type | BellowType | See below |
| DistributedMass | Float | Distributed mass of the bellow |
| PressureArea | Float | Pressure area |
| AxialStiffness | Float | Axial stiffness |
| LateralStiffness | Float | Lateral stiffness |
| AngularStiffness | Float | Angular stiffness |
| TorsionalStiffness | Float | Torsional stiffness |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

BellowType :

    BellowType.Axial
    BellowType.LateralSingle
    BellowType.LateralAll
    BellowType.AngularSingle
    BellowType.AngularAll

### 5.6 Bend

#### 5.6.1 AddBendCommand

Add a bend from a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | First extremity of the bend |
| X2 | Float | X coordinate of the second extremity of the bend |
| Y2 | Float | Y coordinate of the second extremity of the bend |
| Z2 | Float | Z coordinate of the second extremity of the bend |
| X3 | Float | X coordinate of the intersection point |
| Y3 | Float | Y coordinate of the intersection point |
| Z3 | Float | Z coordinate of the intersection point |
| Angle | Float | Angle of the bend |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.6.2 AddBendCommand

Add a bend between 2 nodes. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the bend |
| Node2 | Node | Second extremity of the bend |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

REM : the preceding and next element will be extended to the bend.

#### 5.6.3 InsertBendCommand

Insert a bend on a node. Set the properties, the section and the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.6.4 InsertBendCommand

Insert a bend at (X, Y, Z). Set the properties, the section and the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| X | Float | Inserting X coordinate |
| Y | Float | Inserting Y coordinate |
| Z | Float | Inserting Z coordinate |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

REM : a node must exists at (X, Y, Z)

#### 5. 6.5 ModifyBendCommand

Modify an existing bend. Set the new properties, the section and the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Bend | Bend | Existing bend |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.7 Flange

#### 5.7.1 AddFlangeCommand

Add a flange. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the flange - cannot be None |
| Node2 | Node | Second extremity of the flange - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| EndMass | Bool | Mass at the end ? |
| Mass | Float | Mass of the flange |
| ThicknessFactor | Float | Thickness factor |
| FlangeDiameter | Float | Diameter |
| FlangeThickness | Float | Thickness |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.7.2 InsertFlangeCommand

Insert a flange on a node. Set the section and the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the flange |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| EndMass | Bool | Mass at the end ? |
| Mass | Float | Mass of the flange |
| ThicknessFactor | Float | Thickness factor |
| FlangeDiameter | Float | Diameter |
| FlangeThickness | Float | Thickness |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.7.3 ModifyFlangeCommand

Modify an existing flange. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Flange | Flange | Existing flange |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| EndMass | Bool | Mass at the end ? |
| Mass | Float | Mass of the flange |
| ThicknessFactor | Float | Thickness factor |
| FlangeDiameter | Float | Diameter |
| FlangeThickness | Float | Thickness |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.8 Hanger

#### 5.8.1 CreateConstantHangerCommand

Add a constant hanger on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the hanger direction |
| Dy | Float | Y component of the hanger direction |
| Dz | Float | Z component of the hanger direction |
| Stiffness | Float | Stiffness, must be equal to 0 |
| Force | Float | Pre-compression/pre-tension force |
| Pinned | PinnedCase | See types page, must be equal to PinnedCase.Design |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.8.2 CreateVariableHangerCommand

Add a variable hanger on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the hanger direction |
| Dy | Float | Y component of the hanger direction |
| Dz | Float | Z component of the hanger direction |
| Stiffness | Float | Stiffness, must be > 0 |
| Force | Float | Pre-compression/pre-tension force |
| Pinned | PinnedCase | See types page, must be equal to PinnedCase.Design |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.8.3 ModifyRestraintsToConstantHangerCommand

Modify a list of restraints to constant hanger.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the hanger direction |
| Dy | Float | Y component of the hanger direction |
| Dz | Float | Z component of the hanger direction |
| Stiffness | Float | Stiffness, must be equal to 0 |
| Force | Float | Pre-compression/pre-tension force |
| Pinned | PinnedCase | See types page, must be equal to PinnedCase.Design |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.8.4 ModifyRestraintsToVariableHangerCommand

Modify a list of restraints to variable hanger.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the hanger direction |
| Dy | Float | Y component of the hanger direction |
| Dz | Float | Z component of the hanger direction |
| Stiffness | Float | Stiffness, must be > 0 |
| Force | Float | Pre-compression/pre-tension force |
| Pinned | PinnedCase | See types page, must be equal to PinnedCase.Design |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

### 5.9 Load

TO DO...

### 5.10 Matrix

#### 5.10.1 AddMatrixCommand

Add a matrix element. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the matrix - cannot be None |
| Node2 | Node | Second extremity of the matrix - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| LocalZX | Float | X component of local Z axis |
| LocalZY | Float | Y component of local Z axis |
| LocalZZ | Float | Z component of local Z axis |
| S11 | Float | Element in the symetric 6x6 matrix |
| S21 | Float | Element in the symetric 6x6 matrix |
| S22 | Float | Element in the symetric 6x6 matrix |
| S31 | Float | Element in the symetric 6x6 matrix |
| S32 | Float | Element in the symetric 6x6 matrix |
| S33 | Float | Element in the symetric 6x6 matrix |
| S41 | Float | Element in the symetric 6x6 matrix |
| S42 | Float | Element in the symetric 6x6 matrix |
| S43 | Float | Element in the symetric 6x6 matrix |
| S44 | Float | Element in the symetric 6x6 matrix |
| S51 | Float | Element in the symetric 6x6 matrix |
| S52 | Float | Element in the symetric 6x6 matrix |
| S53 | Float | Element in the symetric 6x6 matrix |
| S54 | Float | Element in the symetric 6x6 matrix |
| S55 | Float | Element in the symetric 6x6 matrix |
| S61 | Float | Element in the symetric 6x6 matrix |
| S62 | Float | Element in the symetric 6x6 matrix |
| S63 | Float | Element in the symetric 6x6 matrix |
| S64 | Float | Element in the symetric 6x6 matrix |
| S65 | Float | Element in the symetric 6x6 matrix |
| S66 | Float | Element in the symetric 6x6 matrix |
| Diameter | Float | Diameter |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the matrix |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.10.2 InsertMatrixCommand

Insert a matrix element on a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the matrix |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| LocalZX | Float | X component of local Z axis |
| LocalZY | Float | Y component of local Z axis |
| LocalZZ | Float | Z component of local Z axis |
| S11 | Float | Element in the symetric 6x6 matrix |
| S21 | Float | Element in the symetric 6x6 matrix |
| S22 | Float | Element in the symetric 6x6 matrix |
| S31 | Float | Element in the symetric 6x6 matrix |
| S32 | Float | Element in the symetric 6x6 matrix |
| S33 | Float | Element in the symetric 6x6 matrix |
| S41 | Float | Element in the symetric 6x6 matrix |
| S42 | Float | Element in the symetric 6x6 matrix |
| S43 | Float | Element in the symetric 6x6 matrix |
| S44 | Float | Element in the symetric 6x6 matrix |
| S51 | Float | Element in the symetric 6x6 matrix |
| S52 | Float | Element in the symetric 6x6 matrix |
| S53 | Float | Element in the symetric 6x6 matrix |
| S54 | Float | Element in the symetric 6x6 matrix |
| S55 | Float | Element in the symetric 6x6 matrix |
| S61 | Float | Element in the symetric 6x6 matrix |
| S62 | Float | Element in the symetric 6x6 matrix |
| S63 | Float | Element in the symetric 6x6 matrix |
| S64 | Float | Element in the symetric 6x6 matrix |
| S65 | Float | Element in the symetric 6x6 matrix |
| S66 | Float | Element in the symetric 6x6 matrix |
| Diameter | Float | Diameter |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the matrix |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.10.3 ModifyMatrixCommand

Modify an existing matrix element. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Matrix | Matrix | Existing matrix |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| LocalZX | Float | X component of local Z axis |
| LocalZY | Float | Y component of local Z axis |
| LocalZZ | Float | Z component of local Z axis |
| S11 | Float | Element in the symetric 6x6 matrix |
| S21 | Float | Element in the symetric 6x6 matrix |
| S22 | Float | Element in the symetric 6x6 matrix |
| S31 | Float | Element in the symetric 6x6 matrix |
| S32 | Float | Element in the symetric 6x6 matrix |
| S33 | Float | Element in the symetric 6x6 matrix |
| S41 | Float | Element in the symetric 6x6 matrix |
| S42 | Float | Element in the symetric 6x6 matrix |
| S43 | Float | Element in the symetric 6x6 matrix |
| S44 | Float | Element in the symetric 6x6 matrix |
| S51 | Float | Element in the symetric 6x6 matrix |
| S52 | Float | Element in the symetric 6x6 matrix |
| S53 | Float | Element in the symetric 6x6 matrix |
| S54 | Float | Element in the symetric 6x6 matrix |
| S55 | Float | Element in the symetric 6x6 matrix |
| S61 | Float | Element in the symetric 6x6 matrix |
| S62 | Float | Element in the symetric 6x6 matrix |
| S63 | Float | Element in the symetric 6x6 matrix |
| S64 | Float | Element in the symetric 6x6 matrix |
| S65 | Float | Element in the symetric 6x6 matrix |
| S66 | Float | Element in the symetric 6x6 matrix |
| Diameter | Float | Diameter |
| MassModel | MassModel | See types page |
| Mass | Float | Mass of the matrix |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.11 Node

#### 5.11.1 AddLocalCoordinateSystemCommand

Add a local coordinate system on an existing node. Added on **model.DLCSs**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Existing node |
| X | Vector3D | X direction |
| Z | Vector3D | Z direction |

```python
# Python script
from System.Windows.Media.Media3D import Vector3D

X = Vector3D(1, 0, 0)
Z = Vector3D(0, 0, 1)
...
```

#### 5.11.2 AddLumpedMassCommand

Add a lumped mass on an existing node. Added on **model.LumpedMasses**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Existing node |
| Mass | Float | Mass on node |

#### 5.11.3 AddNodeCommand

Add a node. Set all connection properties in CurrentPipingValues first. Added to **model.Nodes**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| X | Float | X coordinate |
| Y | Float | Y coordinate |
| Z | Float | Z coordinate |
| Name | String | Node name |
| NewPoint | Bool | True or False |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.11.4 AddNodeCommand

Add a node. Set all connection properties in CurrentPipingValues first. Added to **model.Nodes**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Node created outside the command |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.11.5 AddNodesCommand

Add a list of nodes based on coordinates and CurrentPipingValues. Added to **model.Nodes**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Points | `List<Point3D>` | List of Point3D |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

```python
# Python script
from System.Windows.Media.Media3D import Point3D

pt = Point3D(0, 0, 0)
...
```

#### 5.11.6 ModifyLocalCoordinateSystemCommand

Modify an existing local coordinate system.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| DLCS | DLCS | Existing local coordinate system, see types page |
| X | Vector3D | X direction |
| Z | Vector3D | Z direction |

```python
# Python script
from System.Windows.Media.Media3D import Vector3D

X = Vector3D(1, 0, 0)
Z = Vector3D(0, 0, 1)
...
```

#### 5.11.7 ModifyLumpedMassCommand

Modify an existing lump mass.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| LumpedMass | LumpedMass | See types page |
| Mass | Float | Mass on node |

#### 5.11.8 ModifyNodeCommand

Modify an existing node.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Existing node |
| Name | String | Name |
| Mismatch | Float | Mismatch for butt welds, as welded |
| FilletLength | Float | Length of fillet weld |
| TMax | Float | tmax for Class 1 transition within 1:3 slope envelope |
| JointType | JointType | See types page |

#### 5.11.9 ModifyNodeNameCommand

Modify the name of a node.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Existing node |
| Name | String | Name |

#### 5.11.10 RemoveEmptyNodeCommand

Remove nodes that are not connected to elements. Removed from **model.Nodes**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of Point3D |

```python
# Python script
from Cwantic.MetaPiping.Core import Node
from System.Collections.Generic import List

Nodes = List[Node]()
...
```

#### 5.11.11 RemoveLocalCoordinateSystemCommand

Remove an existing local coordinate system. Removed from **model.DLCSs**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| DLCS | DLCS | Existing local coordinate system, see types page |

#### 5.11.12 RemoveLumpedMassCommand

Remove a lump mass. Removed from **model.LumpedMasses**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| LumpedMass | LumpedMass | See types page |

### 5.12 Node link

#### 5.12.1 AddNodeLinkCommand

Add a link between a node of a linked piping model and multiple nodes of current structural model. Added in **model.Links**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| StudyID | Int | The Id of the linked study of the piping model |
| ExternalNode | Node | A piping node in the linked piping model |
| NodeList | `List<Node>` | List of nodes of the current structural model |
| StaticFriction | Float | Static friction of the contact |
| DynamicFriction | Float | Dynamic friction of the contact |
| Clamp | Clamp | U-bolt object at node - can be None. See types page |

```python
# Python script
from System.Collections.Generic import List
from Cwantic.MetaPiping.Core import Clamp, Node

...
# Creation of a C# List
nodes = List[Node]()
nodes.Add(N1)
...

ubolt = Clamp()
...
```

#### 5.12.2 ModifyNodeLinkCommand

Modify an existing node link.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Link | NodeLink | Existing node link, see types page |
| NodeList | `List<Node>` | List of nodes of the current structural model |
| StaticFriction | Float | Static friction of the contact |
| DynamicFriction | Float | Dynamic friction of the contact |
| Clamp | Clamp | U-bolt object at node - can be None. See types page |

#### 5.12.3 RemoveNodeLinkCommand

Remove a node link from **model.Links**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Link | NodeLink | Existing node link, see types page |

### 5.13 Pipe

#### 5.13.1 DrawPipingCommand

Add a pipe, with possible bend (if not tangent to preceding element) or reducer (if other section).

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the pipe - cannot be None |
| Node2 | Node | Second extremity of the pipe - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | Current piping properties (see §4.2) |

REM : LocalX, LocalY, LocalZ can be set to (0, 0, 0)

#### 5.13.2 DrawPipingCommand

Add a pipe, with possible bend (if not tangent to preceding element) or reducer (if other section).

| Param | Type | Description |
| ---- | ----------- | ----------- |
| X | Float | X coordinate of Node1 |
| Y | Float | Y coordinate of Node1 |
| Z | Float | Z coordinate of Node1 |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | Current piping properties (see §4.2) |

REM : a start node must exists at (X, Y, Z)

#### 5.13.3 ModifyPipeCommand

Modify an existing pipe. Set the properties, the section and the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Pipe | Pipe | Existing pipe |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.14 Reducer

#### 5.14.1 AddReducerCommand

Add a reducer. Set the properties, the end section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the reducer - cannot be None |
| Node2 | Node | Second extremity of the reducer - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Section | PipeSection | Start section, see below |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

[See the description of the object PipeSection](https://documentation.metapiping.com/Python/Classes/section.html)

#### 5.14.2 InsertReducerCommand

Insert a reducer on a node. Set the properties, the end section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the reducer |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Section | PipeSection | Start section, see below |
| PipingValues | CurrentPipingValues | see §4.2, used for section2 and material definition |

[See the description of the object PipeSection](https://documentation.metapiping.com/Python/Classes/section.html)

#### 5.14.3 ModifyReducerCommand

Modify an existing reducer. Set the properties, the section and the material in PipingValues1 and PipingValues2 first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Reducer | Reducer | Existing reducer |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Angle | Float | Angle |
| FlexibilityFactor | Float | Flexibility factor |
| R12 | Float | Class 1 only |
| L12 | Float | Class 1 only |
| PipingValues1 | CurrentPipingValues | see §4.2, used for section1 and material definition |
| PipingValues2 | CurrentPipingValues | see §4.2, used for section2 definition |

### 5.15 Restraint

#### 5.15.1 CreateMultiRestraintCommand

Add a multi-restraint on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Kx | Float | Translational stiffness along X |
| Ky | Float | Translational stiffness along Y |
| Kz | Float | Translational stiffness along Z |
| Krx | Float | Rotational stiffness around X |
| Kry | Float | Rotational stiffness around Y |
| Krz | Float | Rotational stiffness around Z |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.2 CreateNonLinearRestraintCommand

Add a non-linear restraint on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Gapm | Float | Negative gap |
| K1m | Float | First spring constant in the negative direction |
| K2m | Float | Second spring constant in the negative direction |
| FLm | Float | Reaction at stiffness transition from K1m to K2m |
| Gapp | Float | Positive gap |
| K1p | Float | First spring constant in the positive direction |
| K2p | Float | Second spring constant in the positive direction |
| FLp | Float | Reaction at stiffness transition from K1p to K2p |
| Mu | Float | Coulomb coefficient of friction between the pipe and the support |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.3 CreateRestraintCommand

Add a translational restraint on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.4 CreateRotationalRestraintCommand

Add a rotational restraint on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the rotation axis |
| Dy | Float | Y component of the rotation axis |
| Dz | Float | Z component of the rotation axis |
| Stiffness | Float | Rotational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.5 ModifyRestraintsToMultiRestraintCommand

Modify a list of restraints to multi-restraint.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Kx | Float | Translational stiffness along X |
| Ky | Float | Translational stiffness along Y |
| Kz | Float | Translational stiffness along Z |
| Krx | Float | Rotational stiffness around X |
| Kry | Float | Rotational stiffness around Y |
| Krz | Float | Rotational stiffness around Z |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.6 ModifyRestraintToNonLinearRestraintCommand

Modify a list of restraints to non-linear restraint.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Gapm | Float | Negative gap |
| K1m | Float | First spring constant in the negative direction |
| K2m | Float | Second spring constant in the negative direction |
| FLm | Float | Reaction at stiffness transition from K1m to K2m |
| Gapp | Float | Positive gap |
| K1p | Float | First spring constant in the positive direction |
| K2p | Float | Second spring constant in the positive direction |
| FLp | Float | Reaction at stiffness transition from K1p to K2p |
| Mu | Float | Coulomb coefficient of friction between the pipe and the support |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.7 ModifyRestraintsToRestraintCommand

Modify a list of restraints to translational restraint.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.8 ModifyRestraintsToRotationalRestraintCommand

Modify a list of restraints to rotational restraint.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the rotation axis |
| Dy | Float | Y component of the rotation axis |
| Dz | Float | Z component of the rotation axis |
| Stiffness | Float | Translational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.15.9 RemoveRestraintCommand

Remove all kind of restraints. Removed from **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |

```python
# Python script
from Cwantic.MetaPiping.Core import Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !
...
```

### 5.16 Rigid

#### 5.16.1 AddRigidCommand

Add a rigid. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the rigid - cannot be None |
| Node2 | Node | Second extremity of the rigid - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Diameter | Float | Diameter, use 0.01 |
| Mass | Float | Mass of the rigid |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

#### 5.16.2 InsertRigidCommand

Insert a rigid on a node. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the rigid |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Diameter | Float | Diameter, use 0.01 |
| Mass | Float | Mass of the rigid |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

#### 5.16.3 ModifyRigidCommand

Modify an existing rigid. Set the material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Rigid | Rigid | Existing rigid |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Diameter | Float | Diameter, use 0.01 |
| Mass | Float | Mass of the rigid |
| PipingValues | CurrentPipingValues | see §4.2, used for material definition |

### 5.17 SIF

#### 5.17.1 AddSifCommand

Add user SIF values.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| SIFs | UserSIF | See types page |

#### 5.17.2 ApplySifsCommand

Add new SifParameters.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Parameters | `List<SifParameters>` | See types page |

```python
# Python script
from System.Collections.Generic import List
from Cwantic.MetaPiping.Core import SifParameters

...
# Creation of a C# List
Parameters = List[SifParameters]()
Parameters.Add(param1) # Use Add instead of append with C# list !
```

#### 5.17.3 ModifySifCommand

Modify an existing SIF definition with new SIF values

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Sif | UserSIF | Existing SIF, see types page |
| sifValues | `Dictionary<string, double>` | New Dictionary of SIF name, SIF value |

```python
# Python script
from System import String, Double
from System.Collections.Generic import Dictionary

...
# Creation of a C# Dictionary<string, double>
sifValues = Dictionary[String, Double]()
sifValues.Add("i", 1.2)
...
```

#### 5.17.4 RemoveSifCommand

Remove SIF.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Sif | UserSIF | Existing SIF, see types page |

### 5.18 Snubber

#### 5.18.1 CreateSnubberCommand

Add a snubber on nodes. Added to **model.Restraints**.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Nodes | `List<Node>` | List of nodes |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Node
from System.Collections.Generic import List

...
# Creation of a C# list
Nodes = List[Node]()
Nodes.Add(N1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

#### 5.18.2 ModifyRestraintsToSnubberCommand

Modify a list of restraints to snubber.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Restraints | `List<Restraint>` | List of restraints |
| CoordinateSystem | CoordinateSystem | Orientation of the restraint, see types page |
| Elements | `List<Element>` | List of the attached elements on nodes |
| Level | String | Level (for seismic analysis) |
| Dx | Float | X component of the restraint direction |
| Dy | Float | Y component of the restraint direction |
| Dz | Float | Z component of the restraint direction |
| Stiffness | Float | Translational Spring Constant |
| Layer | Layer | Layer, see types page |
| Label | String | Label |

```python
# Python script
from Cwantic.MetaPiping.Core import Element, Restraint
from System.Collections.Generic import List

...
# Creation of a C# list
Restraints = List[Restraint]()
Restraints.Add(R1) # Use Add instead of append with C# list !

Elements = List[Element]()
Elements.Add(N1.Elements[0]) # Use Add instead of append with C# list !
...
```

[See the description of the object Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

### 5.19 Socket

#### 5.19.1 AddSocketCommand

Add a socket. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the socket - cannot be None |
| Node2 | Node | Second extremity of the socket - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the socket |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.19.2 InsertSocketCommand

Insert a socket on a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the socket |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the socket |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.19.3 ModifySocketCommand

Modify an existing socket. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Socket | Socket | Existing socket |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the socket |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.20 Spring

#### 5.20.1 AddSpringCommand

Add a spring. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the spring - cannot be None |
| Node2 | Node | Second extremity of the spring - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Kx | Float | Translational stiffness along X |
| Ky | Float | Translational stiffness along Y |
| Kz | Float | Translational stiffness along Z |
| Krx | Float | Rotational stiffness along X |
| Kry | Float | Rotational stiffness along Y |
| Krz | Float | Rotational stiffness along Z |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.20.2 InsertSpringCommand

Insert a spring on a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the spring |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Kx | Float | Translational stiffness along X |
| Ky | Float | Translational stiffness along Y |
| Kz | Float | Translational stiffness along Z |
| Krx | Float | Rotational stiffness along X |
| Kry | Float | Rotational stiffness along Y |
| Krz | Float | Rotational stiffness along Z |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.20.3 ModifySpringCommand

Modify an existing spring. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Spring | Spring | Existing spring |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Kx | Float | Translational stiffness along X |
| Ky | Float | Translational stiffness along Y |
| Kz | Float | Translational stiffness along Z |
| Krx | Float | Rotational stiffness along X |
| Kry | Float | Rotational stiffness along Y |
| Krz | Float | Rotational stiffness along Z |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.21 Soil

#### 5.21.1 SetSoilCommand

Set a soil to pipings.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Soil | Soil | Existing soil, see types page |
| Pipings | `List<Piping>` | List of existing pipings |

REM : create the soil before.

```python
# Python script
from Cwantic.MetaPiping.Core import Piping
from System.Collections.Generic import List

...
# Creation of a C# list
Pipings = List[Piping]()
Pipings.Add(piping1) # Use Add instead of append with C# list !
...
```

[See the description of the object Piping](https://documentation.metapiping.com/Python/Classes/element.html)

#### 5.21.2 ModifySoilCommand

Modify a soil by another one.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| ExistingSoil | Soil | Existing soil, see types page |
| NewSoil | Soil | New soil, see types page |

REM : create the new soil before.

### 5.22 Structural

#### 5.22.1 AddStructuralCommand

Add a structural object. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the structural - cannot be None |
| Node2 | Node | Second extremity of the structural - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the structural |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.22.2 InsertStructuralCommand

Insert a structural on a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the structural |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the structural |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.22.3 ModifyStructuralCommand

Modify an existing structural. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Structural | Structural | Existing structural |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Mass | Float | Mass of the structural |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

### 5.23 Tee

#### 5.23.1 AddBranchCommand

Add a branch (pipe) on a node with already 2 pipes. Set the tee properties in CurrentTeeValues first. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Tee | Tee | Temporary tee with first node |
| Node2 | Node | Second extremity of the branch - can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| TeeValues | CurrentTeeValues | see §4.1 |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.23.2 ModifyTeeCommand

Modify an existing tee.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Tee | Tee | Temporary tee |
| TeeValues | CurrentTeeValues | see §4.1 |

#### 5.23.3 RemoveTeeCommand

Remove a tee.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Tee | Tee | Temporary tee |

#### 5.23.4 RemoveTeesCommand

Remove a list of tees.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Tees | `List<Tee>` | List of tees |

```python
# Python script
from Cwantic.MetaPiping.Core import Tee
from System.Collections.Generic import List

...
# Creation of a C# list
tees = List[Tee]()
tees.Add(tee1) # Use Add instead of append with C# list !
...
```

### 5.24 Valve

#### 5.24.1 AddValveCommand

Add a valve. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node1 | Node | First extremity of the valve - cannot be None |
| Node2 | Node | Second extremity of the valve- can be None |
| DX | Float | Distance along X axis of end point from Node1 |
| DY | Float | Distance along Y axis of end point from Node1 |
| DZ | Float | Distance along Z axis of end point from Node1 |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Type | Int | 1 = simple, 2 = middle point, 3 = excentricity |
| EX | Float | X component of excentricity (if type = 3) |
| EY | Float | Y component of excentricity (if type = 3) |
| EZ | Float | Z component of excentricity (if type = 3) |
| Fluid | Bool | With fluid ? |
| Mass | Float | Mass of the valve |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.24.2 InsertValveCommand

Insert a valve on a node. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Node | Node | Inserting node |
| Length | Float | Length of the valve |
| Mode | InsertMode | Mode of insertion, see types page |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Type | Int | 1 = simple, 2 = middle point, 3 = excentricity |
| EX | Float | X component of excentricity (if type = 3) |
| EY | Float | Y component of excentricity (if type = 3) |
| EZ | Float | Z component of excentricity (if type = 3) |
| Fluid | Bool | With fluid ? |
| Mass | Float | Mass of the valve |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

#### 5.24.3 ModifyValveCommand

Modify an existing valve. Set the section and material in CurrentPipingValues first.

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Valve | Valve | Existing valve |
| LocalX | Float | X component of local X axis |
| LocalY | Float | Y component of local X axis |
| LocalZ | Float | Z component of local X axis |
| Type | Int | 1 = simple, 2 = middle point, 3 = excentricity |
| EX | Float | X component of excentricity (if type = 3) |
| EY | Float | Y component of excentricity (if type = 3) |
| EZ | Float | Z component of excentricity (if type = 3) |
| Fluid | Bool | With fluid ? |
| Mass | Float | Mass of the valve |
| ThicknessFactor | Float | Thickness factor |
| PipingValues | CurrentPipingValues | see §4.2, used for section and material definition |

