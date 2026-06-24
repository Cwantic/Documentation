---
layout: default
title: element
nav_order: 7
parent: Classes
grand_parent: Python
---

# 1. Element

**Element** is the base class for all elements (piping and structure).

```python
# Python script
from Cwantic.MetaPiping.Core import Element
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Node1 | Node | Start node |
| Node2 | Node | End node |
| DL | Vector3D | DL.X, DL.Y and DL.Z are the coordinate changes from Node1 to Node2 in the global coordinate system |
| Material | Material | Material |
| RoomTemperature | float | Installation temperature. If null, same as the room temperature specified for the model |
| XDir | Vector3D | Local X' axis. If (0,0,0), the default local axes are used |
| Label | string | Label |
| LayerID | int | Layer number |
| Diameter | float | Element cross size (for graphics). Same as section outside diameter for **Piping** elements |
| Mass | float | Mass. The meaning depends on *MassModel* |
| MassModel | MassModel | Mass modeling option |

Vector3D comes from the library *System.Windows.Media.Media3D*

```python
# Python script
from System.Windows.Media.Media3D import Vector3D

element.XDir = Vector3D(1, 0, 0)
element.DL = Vector3D(0, 0, 2)    
...
```

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about Material](https://documentation.metapiping.com/Python/Classes/material.html)

[Click here for more information about MassModel](https://documentation.metapiping.com/Python/Classes/types.html)

# 2. Piping

**Piping** is an abstract class that inherits from **Element** (see § 1). Every **Piping** object has the properties of **Element**.

```python
# Python script
from Cwantic.MetaPiping.Core import Piping
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Section | PipeSection | Pipe section |
| LongWeldType | LongWeldType | Longitudinal weld type |
| LongWeldMismatch | float | Longitudinal weld mismatch |
| DesignCondition | OperatingCondition | Design condition. If null, same as general design condition of the model |
| PipingCode | PipingCode | Piping code. If null, same as general piping code of the model |
| StresOff | bool | True if stress calculation is disabled |
| ThicknessFactor | float | Thickness factor |
| OutsideDiameter | float | Outside diameter |
| InsideDiameter | float | Inside diameter |
| Thickness | float | Thickness |
| ContentDiameter | float | Inside diameter for calculation of fluid weight |

[Click here for more information about PipeSection](https://documentation.metapiping.com/Python/Classes/section.html#2-pipesection)

[Click here for more information about LongWeldType, OperatingCondition and PipingCode](https://documentation.metapiping.com/Python/Classes/types.html)

# 3. Pipe

**Pipe** inherits from **Piping**. It represents straight pipes.

```python
# Python script
from Cwantic.MetaPiping.Core import Pipe
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Pipe",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| NbDivisions | int | Number of subdivisions for analysis |
| Glue | bool | For composite pipe only |

# 4. Tee

**Tee** contains data that represent all geometric properties of the connection between the collector and the branch.

```python
# Python script
from Cwantic.MetaPiping.Core import Tee
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Node | Node | Where the tee take place |
| Branch | Pipe | Branch pipe |
| Run1 | Pipe | Collector part 1 |
| Run2 | Pipe | Collector part 2 |
| Type | TeeType | Type of tee |
| Taper | bool | True if variable thickness |
| Nc | int | Number of flanges attached to the run elements (B31J only) |
| L1 | float | Branch reinforcement length |
| TN | float | Branch connections and lateral connections CONSTANT thickness |
| RP | float | Branch outer radius |
| PD | float | Pad thickness for reinforced fabricated tees |
| R2 | float | Branch-to-run fillet radius |
| RX | float | Transition radius |
| RE | float | Pad or saddle outer radius for reinforced fabricated tees |
| Angle | float | Angle of connection in radian (0 <= angle <= PI/2) |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about TeeType](https://documentation.metapiping.com/Python/Classes/types.html)

# 5. Bend

**Bend** inherits from **Piping**. It represents elbows and miter bends.

```python
# Python script
from Cwantic.MetaPiping.Core import Bend
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Bend",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Miter | bool | True if miter bend |
| DL1 | Vector3D | First tangent vector |
| DL2 | Vector3D | Second tangent vector |
| Node3 | Node | Intersection node |
| Radius | float | Geometrical radius |
| Angle | float | Angle (in radians) |
| NbDivisions | int | Number of subdivisions for analysis (elbow) or number of miter cuts (miter bend) |
| Spacing | float | Miter spacing at center line |
| NbFlanges | int | Number of attached flanges |
| UserFlex | float | User-defined flexibility factor |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

# 6. Reducer

**Reducer** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Reducer
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Reducer",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Section2 | PipeSection | Section at end node |
| Angle | float | Cone angle (in dgrees) |
| L12 | float | Minimum tangent L1, L2 (Class 1 and B31J) |
| R12 | float | Minimum radius r1, r2 (Class 1 and B31J) |
| FF | float | |

[Click here for more information about PipeSection](https://documentation.metapiping.com/Python/Classes/section.html#2-pipesection)

# 7. Valve

**Valve** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Valve
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Valve",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Type | ValveType | Type of valve |
| PB | Node | Node at valve midpoint. Null if no midpoint |
| PC | Node | Node at end of valve stem. Null if no stem |
| BL | Vector3D | Midpoint to stem offset |
| IsStemEmpty | bool | True if the stem is empty |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

The type *ValveType* is an enumeration used for graphics. It has the following values:

| Value | Description |
| --- | ----------- |
| Valve | Valve is represented depending on PB and PC |
| ToCenter | Valve end to center |
| FromCenter | Center to valve end |
| Stem | Center to stem |

# 8. Flange

**Flange** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Flange
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Flange",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| FDiameter | float | Outside diameter of the flange |
| FThickness | float | Thickness of the flange |

# 9. Socket

**Socket** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Socket
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Socket",
      ...
    }
    ]
    ...  
```

## Properties

No additional properties.

# 10. Structural

**Structural** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Structural
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Structural",
      ...
    }
    ]
    ...  
```

## Properties

No additional properties.

# 11. Rigid

**Rigid** inherits from **Element**.

```python
# Python script
from Cwantic.MetaPiping.Core import Rigid
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Rigid",
      ...
    }
    ]
    ...  
```

## Properties

No additional properties.

No section.

# 12. Spring

**Spring** inherits from **Element**.

```python
# Python script
from Cwantic.MetaPiping.Core import Spring
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Spring",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| ZDir | Vector3D | Local Z' direction. Only used if spring length is zero |
| Kx | float | Translation stiffness along X' |
| Ky | float | Translation stiffness along Y' |
| Kz | float | Translation stiffness along Z' |
| Krx | float | Rotation stiffness around X' |
| Kry | float | Rotation stiffness around Y' |
| Krz | float | Rotation stiffness around Z' |

No section.

# 13. Matrix

**Matrix** inherits from **Element**.

```python
# Python script
from Cwantic.MetaPiping.Core import Matrix
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Matrix",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| ZDir | Vector3D | Local Z' direction |
| Stiffness | SquareMatrix | Stiffness matrix |

*SquareMatrix* represents a 6x6 symmetrical matrix.

No section.

# 14. Bellow

**Bellow** inherits from **Piping**.

```python
# Python script
from Cwantic.MetaPiping.Core import Bellow
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Bellow",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Type | BellowType | Type of bellow |
| SA | float | Axial stiffness |
| SL | float | Lateral stiffness |
| SB | float | Angular stiffness |
| ST | float | Torsional stiffness |
| A | float | Pressure thrust area |

The type *BellowType* is an enumeration with the following values:

| Value | Description |
| --- | ----------- |
| Axial | Axial |
| LateralSingle | Lateral in X'Z' plane |
| LateralAll | lateral in all planes |
| AngularSingle | Angular in X'Z' plane |
| AngularAll | Angular in all planes |

# 15. Beam

**Beam** inherits from **Element**.

```python
# Python script
from Cwantic.MetaPiping.Core import Beam
```

```json
// Property in metaL's JSON Elements list
    ...
    "Elements": [
    {
      ...
      "Element": "Beam",
      ...
    }
    ]
    ...  
```

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Section | BeamSection | Section |
| E | float | Young modulus, if 0 taken from material |
| NbDivisions | int | Number of subdivisions |
| BucklingX | float | Buckling factor in the **weak** inertia plane, 1 by default |
| BucklingY | float | Buckling factor in the **strong** inertia plane, 1 by default |
| BucklingZ | float | the **lateral-torsional** buckling factor, 1 by default |
| LTBmodel | LTBModel | Theoretical model of Lateral Torsional Buckling (Eurocode3 only) |
| Extremity1 | BeamExtremity | Graphical ending of extremity 1 of a beam |
| Extremity2 | BeamExtremity | Graphical ending of extremity 2 of a beam |
| Extremity1Beam | Beam | Beam used in Extremity1 |
| Extremity2Beam | Beam | Beam used in Extremity2 |
| Offset1 | float | Extension of beam at first extremity |
| Offset2 | float | Extension of beam at last extremity |
| Joint1 | Joint | Assembly at first extremity, can be Joint, BoltedJoint or WeldedJoint |
| Joint2 | Joint | Assembly at last extremity, can be Joint, BoltedJoint or WeldedJoint |
| IsCable | bool | True if the beam works only in traction |

[Click here for more information about BeamSection](https://documentation.metapiping.com/Python/Classes/section.html#3-beamsection)

[Click here for more information about LTBModel, BeamExtremity, Joint, BoltedJoint and WeldedJoint](https://documentation.metapiping.com/Python/Classes/types.html)
