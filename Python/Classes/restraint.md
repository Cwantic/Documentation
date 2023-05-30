---
layout: default
title: element
nav_order: 8
parent: Classes
grand_parent: Python
---


# 1. Restraint

**Restraint** is the base class for all restraints.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Node | Node | Restrained node |
| Level | string | Level (for seismic analysis) |
| AttachedElement | Element | Element attached to restraint (for local axes - see LCS)|
| LCS | CoordinateSystem | Coordinate system used for restraint directions |
| Label | string | Label |
| LayerID | int | Layer number |


The type *CoordinateSystem* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| Global | Global coordinate system |
| LocalToConnectedElement |  Local coordinate system of the adjacent element |
| LocalToPrecedingElement |  Local coordinate system of the preceding element |
| LocalToFollowingElement |  Local coordinate system of the following element |
| Local | Local coordinate system specified at restrained node |


# 2. AxialRestraint

**AxialRestraint** is an abstract class that inherits from **Restraint**. Every **AxialRestraint** object has the properties of **Restraint**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Stiffness | float | Stiffness |
| Direction | Vector3D | Restrained direction |


# 3. LinearRestraint

**LinearRestraint** inherits from **AxialRestraint**. It represents linear axial restraints.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Type | LinearRestraintType | Type of restraint |

The type *LinearRestraintType* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| Translational | Translational |
| Rotational | Rotational|
| Snubber | Snubber|


# 4. SpringHanger

**Branch** inherits from **AxialRestraint**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Force | float | Type of restraint |
| PinnedCase | PinnedCase | Pinned case option |

The type *PinnedCase* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| Design | Pinned for design weight analysis |
| DesignAndTest | Pinned for design weight and test weight analyses|
| DesignAndEmpty | Pinned for design weight and empty weight analyses|


# 5. MultiRestraint

**MultiRestraint** inherits from **Restraint**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Kx | float | Stiffness along X: 0 if free, > 0 if rigid |
| Ky | float | Stiffness along Y: 0 if free, > 0 if rigid |
| Kz | float | Stiffness along Z: 0 if free, > 0 if rigid |
| Krx | float | Stiffness around X: 0 if free, > 0 if rigid |
| Kry | float | Stiffness around Y: 0 if free, > 0 if rigid |
| Krz | float | Stiffness around Z: 0 if free, > 0 if rigid |


# 6. Anchor

**Anchor** inherits from **Restraint**.

## Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Kx | float | Stiffness along X |
| Ky | float | Stiffness along Y |
| Kz | float | Stiffness along Z |
| Krx | float | Stiffness around X |
| Kry | float | Stiffness around Y |
| Krz | float | Stiffness around Z |
