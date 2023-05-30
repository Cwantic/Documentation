---
layout: default
title: element
nav_order: 7
parent: Classes
grand_parent: Python
---


# 1. Element

**Element** is the base class for all elements.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Node1 | Node | Start node |
| Node2 | Node | End node |
| DL | Vector3D | DL.X, DL.Y and DL.Z are the coordinate changes from Node1 to Node2 in the global coordinate system |
| Material | Material | Material |
| RoomTemperature | float | Installation temperature. If null, same as the room temperature specified for the model |
| XDir | Vector3D| Local X' axis. If (0,0,0), the default local axes are used |
| Label | string | Label |
| LayerID | int | Layer number |
| Diameter | float | Element cross size (for graphics). Same as section outside diameter for **Piping** elements  |
| Mass | float | Mass. The meaning depends on *MassModel* |
| MassModel | MassModel | Mass modeling option |


The type *MassModel* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| AtEnd | *Mass* is a lumped mass located at the end node |
| AtStart | *Mass* is a lumped mass located at the start node|
| HalfAtBoth | *Mass* is a lumped mass divided between both nodes|
| LinearAtBoth | *Mass* is a linear mass. The total mass (*Mass x element length*) is lumped at both nodes|
| LinearAtEnd | *Mass* is a linear mass. The total mass (*Mass x element length*) is lumped at the end node|
| Linear | *Mass* is a linear mass|
| Density | *Mass* is a density (for Beam elements only)|


# 2. Piping

**Piping** is an abstract class that inherits from **Element** (see § 1). Every **Piping** object has the properties of **Element**.

## Properties

| Name | Return | Description |
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

The type *LongWeldType* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| None | No weld |
| ButtWeldFlush | Butt weld, flush|
| ButtWeldAsWelded | Butt weld, as welded|


# 3. Pipe

**Pipe** inherits from **Piping**. It represents straight pipes.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| NbDivisions | int | Number of subdivisions for analysis |


# 4. Branch

**Branch** inherits from **Piping**. It is a fictitious element generated during the analysis that connects the tee center point to the run surface.

## Properties
No additional properties.


# 5. Bend

**Bend** inherits from **Piping**. It represents elbows and miter bends.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Miter | bool | True if miter bend |
| DL1 | Vector3D | First tangent vector|
| DL2 | Vector3D | Second tangent vector|
| Node3 | Node | Intersection node |
| Radius | float | Geometrical radius |
| Angle | float | Angle (in radians) |
| NbDivisions | int | Number of subdivisions for analysis (elbow) or number of miter cuts (miter bend) |
| Spacing | float | Miter spacing at center line |
| NbFlanges | int | Number of attached flanges |
| UserFlex | float | User-defined flexibility factor |


# 6. Reducer

**Reducer** inherits from **Piping**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Section2 | PipeSection | Section at end node |
| Angle | float | Cone angle (in dgrees) |
| L12 | float | Minimum tangent L1, L2 (Class 1 and B31J)|
| R12 | float | Minimum radius r1, r2 (Class 1 and B31J)|


# 7. Valve

**Valve** inherits from **Piping**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Type | ValveType | Type of valve |
| PB | Node | Node at valve midpoint. Null if no midpoint|
| PC | Node | Node at end of valve stem. Null if no stem|
| BL | Vector3D | Midpoint to stem offset|
| IsStemEmpty | bool | True if the stem is empty|

The type *ValveType* is an enumeration used for graphics. It has the following values:

| Value | Description |
| ---  | ----------- |
| Valve | Valve is represented depending on PB and PC |
| ToCenter | Valve end to center|
| FromCenter | Center to valve end|
| Stem | Center to stem|


# 8. Flange

**Flange** inherits from **Piping**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| FDiameter | float | Outside diameter |
| FThickness | float | Thickness|


# 9. Socket

**Socket** inherits from **Piping**.

## Properties
No additional properties.


# 10. Structural

**Structural** inherits from **Piping**.

## Properties
No additional properties.


# 11. Structural

**Structural** inherits from **Piping**.

## Properties
No additional properties.


# 12. Rigid

**Rigid** inherits from **Element**.

## Properties
No additional properties.


# 13. Spring

**Spring** inherits from **Element**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| ZDir | Vector3D | Local Z' direction. Only used if spring length is zero |
| Kx | float | Translation stiffness along X'|
| Ky | float | Translation stiffness along Y'|
| Kz | float | Translation stiffness along Z'|
| Krx | float | Rotation stiffness around X'|
| Kry | float | Rotation stiffness around Y'|
| Krz | float | Rotation stiffness around Z'|


# 14. Matrix

**Matrix** inherits from **Element**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| ZDir | Vector3D | Local Z' direction |
| Stiffness | SquareMatrix | Stiffness matrix|

*SquareMatrix* represents a 6x6 symmetrical matrix.


# 15. Bellow

**Bellow** inherits from **Piping**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Type | BellowType | Type of bellow |
| SA | float | Axial stiffness|
| SL | float | Lateral stiffness|
| SB | float | Angular stiffness|
| ST | float | Torsional stiffness|
| A | float | Pressure thrust area|

The type *BellowType* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| Axial | Axial |
| LateralSingle | Lateral in X'Z' plane|
| LateralAll | lateral in all planes|
| AngularSingle | Angular in X'Z' plane|
| AngularAll | Angular in all planes|


# 16. Beam

**Beam** inherits from **Element**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Section | BeamSection | Section |
| E | float | Young modulus|
| NbDivisions | int | Number of subdivisions|

