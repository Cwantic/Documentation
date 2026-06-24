---
layout: default
title: restraint
nav_order: 9
parent: Classes
grand_parent: Python
---

# 1. Restraint

**Restraint** is the base class for all restraints.

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Node | Node | Restrained node |
| Level | string | Level (for seismic analysis) |
| AttachedElement | Element | Element attached to restraint (for local axes - see LCS) |
| LCS | CoordinateSystem | Coordinate system used for restraint directions |
| Label | string | Label |
| LayerID | int | Layer number |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about Element and Tee](https://documentation.metapiping.com/Python/Classes/element.html)

[Click here for more information about CoordinateSystem](https://documentation.metapiping.com/Python/Classes/types.html)

# 2. AxialRestraint

**AxialRestraint** is an abstract class that inherits from **Restraint**. Every **AxialRestraint** object has the properties of **Restraint**.

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Stiffness | float | Stiffness |
| Direction | Vector3D | Restrained direction |

Vector3D comes from the library *System.Windows.Media.Media3D*

```python
# Python script
from System.Windows.Media.Media3D import Vector3D

restraint.Direction = Vector3D(0, 0, 1)    
```

# 3. LinearRestraint

**LinearRestraint** inherits from **AxialRestraint**. It represents linear axial restraints.

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Type | LinearRestraintType | Type of restraint |

The type *LinearRestraintType* is an enumeration with the following values:

| Value | Description |
| --- | ----------- |
| Translational | Translational |
| Rotational | Rotational |
| Snubber | Snubber |

# 4. SpringHanger

**SpringHanger** inherits from **AxialRestraint**.

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Force | float | Type of restraint |
| PinnedCase | PinnedCase | Pinned case option |

[Click here for more information about PinnedCase](https://documentation.metapiping.com/Python/Classes/types.html)

# 5. MultiRestraint

**MultiRestraint** inherits from **Restraint**.

## Properties

| Name | Type | Description |
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

| Name | Type | Description |
| --- | ----------- | ----------- |
| Kx | float | Stiffness along X |
| Ky | float | Stiffness along Y |
| Kz | float | Stiffness along Z |
| Krx | float | Stiffness around X |
| Kry | float | Stiffness around Y |
| Krz | float | Stiffness around Z |

# 7. NonLinearRestraint

**NonLinearRestraint** inherits from **AxialRestraint**.

## Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Gapm | float | |
| K1m | float | |
| K2m | float | |
| FLm | float | |
| Gapp | float | |
| K1p | float | |
| K2p | float | |
| FLp | float | |
| Mu | float | |
