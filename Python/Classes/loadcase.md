---
layout: default
title: loadcase
nav_order: 13
parent: Classes
grand_parent: Python
---

# Loadcase

**LoadCase** is an abstract class with common properties.

### Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Number | int | Unique load number |
| Title | string | Load title |
| Equation | char | |
| NbCycles | int | |
| Level | char | |
| Duration | float | In hours (HDPE material) |
| IsDynamic | bool | False by default |
| IsSigned | bool | False by default |
| RefCase | StaticCase | |
| Memo | string | |
| CheckFasteners | bool | For structure loads only |

## 1. DynamicCase

**DynamicCase** is an abstract class derivated from **LoadCase** with a ModalSet property.

### Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| ModalSet | string | If empty, use of model's modal extraction properties |

IsDynamic => true

IsSigned => false

## 2. ModalSet

**ModalSet** describes the modal extraction properties of piping or structure model.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Name | string | |
| CutOffFrequency | float | |
| NbMaxModes | int | |
| RefCase | StaticCase | |

Can be used in all DynamicCase.

## 3. StaticCase

**StaticCase** consists of internal and/or external static loadings on the piping/structure system.

It inherits from **Loadcase** class.

### Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Category | LoadCategory | |
| ColdModulus | bool | |
| Weight | WeightOption | |
| ThermalExpansion | bool | |
| PressureElongation | bool | |
| IsSecondary | bool | |
| IsNonLinear | bool | |
| DisableHangers | bool | |
| DistributedLoadType | DistributedLoadType | |
| DefaultOperatingCondition | OperatingCondition | |
| DefaultContentDensity | ContentDensity | |
| DefaultStaticAcceleration | StaticAcceleration | |
| DefaultDistributedLoad | DistributedLoad | |
| OperatingConditions | Dictionary<Element, OperatingCondition> | |
| ContentDensities | Dictionary<Element, ContentDensity> | |
| StaticAccelerations | Dictionary<Element, StaticAcceleration> | |
| DistributedLoads | Dictionary<Element, DistributedLoad> | |
| ColdSprings | Dictionary<Element, ColdSpring> | |
| Stratifications | Dictionary<Element, Stratification> | |
| NodeLoads | Dictionary<Node, NodeLoad> | |
| RestraintMovements | Dictionary<Restraint, RestraintMovement> | |

IsSigned => true

[Click here for more information about LoadCategory, WeightOption, DistributedLoadType, OperatingCondition, ContentDensity, StaticAcceleration, DistributedLoad, ColdSpring, Stratification, NodeLoad and RestraintMovement](https://documentation.metapiping.com/Python/Classes/types.html)

[Click here for more information about Element](https://documentation.metapiping.com/Python/Classes/element.html)

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

## 4. ThermalCase (Class 1 and piping only)

**ThermalCase** consists of the definition of TRANSIENTS that describes the evolution of the fluid temperature during time inside the pipes. Additional stresses will result from the temperature gradients.

### Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Number | int | Unique load number |
| Title | string | Load title |
| DefaultTransient | Transient | Default transient |
| Transients | Dictionary<Element, Transient> | Transients associated to elements |
| GrossDiscs | Dictionary<Node, GrossDisc> | Discontinuities associated to nodes |

[Click here for more information about Transient and GrossDisc](https://documentation.metapiping.com/Python/Classes/types.html)

[Click here for more information about Element](https://documentation.metapiping.com/Python/Classes/element.html)

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

### 5. RSpectrum

**RSpectrum** consists of the definition of series of SPECTRA that describe the support movement loading for primary and secondary floor response cases.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Event | int | Unique event number |
| Title | string | |
| Name | string | |
| Damping | float | |
| Duration | float | |
| Shift | float | |
| RLevels | List of **RLevel** | |
| NbLevels | int | |
| InterpolationMethod | RInterpolationMethod | |
| IsPeriodSpectrum | bool | |

[Click here for more information about RLevel and RInterpolationMethod](https://documentation.metapiping.com/Python/Classes/types.html)

### 6. RPrimCase

**RPrimCase** describes the floor response spectra for each support level. The **PRIMARY** part of the solution u(t) for displacements, rotations, forces, moments and stresses due to the dynamic support movement loading.


It inherits from **Dynamiccase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Event | int | Unique event number |
| ModalCombination | ModalCombination | |
| LevelCombination | LevelCombination | |
| SpatialCombination | SpatialCombination | |
| CombinationOrder | CombinationOrder | |
| RigidCorrection | RigidCorrection | |
| FX | float | Multiplier of the X component of the loading |
| FY | float | Multiplier of the Y component of the loading |
| FZ | float | Multiplier of the Z component of the loading |

[Click here for more information about ModalCombination, LevelCombination, SpatialCombination, CombinationOrder and RigidCorrection](https://documentation.metapiping.com/Python/Classes/types.html)

### 7. RSecCase

**RSecCase** describes the floor response spectra for each support level. The **SECONDARY** part of the solution u(t) for displacements, rotations, forces, moments and stresses due to the dynamic support movement loading.

It inherits from **Dynamiccase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Event | int | Unique event number |
| SecondaryCombination | SecondaryCombination | |
| SpatialCombination | SpatialCombination | |
| FX | float | Multiplier of the X component of the loading |
| FY | float | Multiplier of the Y component of the loading |
| FZ | float | Multiplier of the Z component of the loading |
| IsSecondary | bool | |

[Click here for more information about SecondaryCombination and SpatialCombination](https://documentation.metapiping.com/Python/Classes/types.html)

### 8. THFEvent

**THFEvent** consists of the definition of forces and moments time histories.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Name | string | Filename without extension |
| Title | string | |
| NbFunctions | int | |
| NbTimeSteps | int | |
| FunctionIDs | array of string | |
| TimeHistories | array of array of float | |
| NodeLoads | Dictionary<Node, DynamicNodeLoad> | |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about DynamicNodeLoad](https://documentation.metapiping.com/Python/Classes/types.html)

### 9. THFCase

**THFCase** consists of dynamic forces and moments applied to some nodes of the model.

It inherits from **Dynamiccase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Event | string | |
| Damping | float | |
| RigidCorrection | bool | |
| ResultantMoment | bool | |
| ExplicitScheme | bool | |
| TimeStep | float | |
| ArchiveRate | int | |

### 10. CombiCase

**CombiCase** consists of combining the results of load cases, dynamic cases or previously calculated combination cases to form a new case.

It inherits from **Loadcase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Cases | List of **LoadCase** | |
| Multipliers | List of float | |
| Method | CombinationMethod | |
| Flag | int | |
| TY | int | |

[Click here for more information about CombinationMethod](https://documentation.metapiping.com/Python/Classes/types.html)

### 11. StressCase (piping only)

**StressCase** consists of combining the results of load cases, dynamic cases or previously calculated combination cases to form a new case and of calculating additive stresses which are based on the resultant moments of the constituent cases.

It inherits from **Loadcase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Cases | List of **LoadCase** | |
| Multipliers | List of float | |
| Method | CombinationMethod | |
| FS | int | |

IsDynamic => false

IsSigned => false

[Click here for more information about CombinationMethod](https://documentation.metapiping.com/Python/Classes/types.html)

### 12. LoadSet (Class 1 and piping only)

**LoadSet** is a specific combination of load cases assumed to act simultaneously on a piping system at a given instant. Pairs of load sets are employed in pipe stress analysis to determine physical changes in the system from one load set instant to another.
Typical load set parameters, which may occur in various combinations, are : pressure, temperature, moment and thermal transient effects.

| Name | Type | Description |
| --- | ----------- | ----------- |
| Title | string | |
| NbCycles | int | |
| Flag | int | |
| Situation | int | |
| RefCase | StaticCase | |
| PressureCase | StaticCase | |
| MomentCase | LoadCase | |
| ThermalCase | ThermalCase | |
| CoolDown | bool | |

### 13. ExternalCase (Structure only)

**ExternalCase** consists of a load case based on a linked support reaction on a specified study and load.

It inherits from **Loadcase** class.

| Name | Type | Description |
| --- | ----------- | ----------- |
| StudyID | int | |
| CaseID | int | |
