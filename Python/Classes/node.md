---
layout: default
title: node
nav_order: 6
parent: Classes
grand_parent: Python
---

# Node

## 1. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Name | String | Node name |
| Coor | Point3D | Coor.X, Coor.Y and Coor.Z are the X/Y/Z global coordinates |
| Elements | list of **Element** | List of the elements connected to the node |
| IsCoorInput | bool | True if the coordinates are set by the user |
| IsGenerated | bool | True if the node is generated during analysis |
| IsConstructionNode | bool | True if the node is a fictitious node at an elbow intersection |
| JointType | JointType | Type of joint - see description below |
| Mismatch | float | Mismatch for butt welds, as welded |
| FilletLength | float | Length of fillet weld |
| TMax | float | tmax for Class 1 transition within 1:3 slope envelope |

## 2. Joint types

The type JointType is an enumeration. Its different values may be imported with the following instruction:

```python
from Cwantic.MetaPiping.Core import JointType
```

and used like in this example :

```python
if node.JointType == JointType.ButtWeldAsWelded:
```

### 2.1 Joint types for steel piping

| Value | Description |
| ---  | ----------- |
| None | No weld |
| ButtWeldFlush | Girth butt weld, flush|
| ButtWeldAsWelded | Girth butt weld, as welded|
| CappedEnd | Capped end, as welded|
| FilletWeld | Girth fillet weld|
| FullFilletWeld | Girth full fillet weld|
| TaperedFlush | Tapered transition joint, flush|
| TaperedAsWelded | Tapered transition joint, as welded|
| OneThirdSlopeFlush | Transition within 1:3 slope envelope, flush (Class 1 only)|
| OneThirdSlopeAsWelded | Transition within 1:3 slope envelope, as welded (Class 1 only)|
| Threaded | Threaded joint|
| Brazed | Brazed joint|
| LapFlange | Lap joint for flange|
| SingleWeldSlipOnFlange | Single-weld for slip-on flange (B31J only)|
| DoubleWeldSlipOnFlange | Double-weld for slip-on flange|

### 2.2 Joint types for composite piping

| Value | Description |
| ---  | ----------- |
| None | None |
| AdhesiveBonded | Bell and spigot adhesive bonded joint|
| AdhesiveBondedWithOverlay | Bell and spigot adhesive bonded joint with laminated fiberglass overlay|
| GasketWithOverlay | Bell and spigot gasket joint with laminated fiberglass overlay|
| ButtAndStrap | Butt and strap joint|

### 2.3 Joint types for HDPE piping

| Value | Description |
| ---  | ----------- |
| None | None |
| ConcentricFabricatedReducer | Concentric fabricated reducers|
| ThrustCollar | Thrust collar|
| ElectrofusionCoupling | Electrofusion coupling|
