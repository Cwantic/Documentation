---
layout: default
title: node
nav_order: 6
parent: Classe
grand_parent: Python
---

# Model (OBSOLETE)

**Model** is the class that describes the whole piping/structure geometry and loadings. Extension *.metaL on disk.

```python
# Python script
from Cwantic.MetaPiping.Core import Model
```

## 1. Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Plant | string | Plant |
| Engineer | string | Engineer |
| Title | string | Title |
| Units | Units | System units |
| ZVertical | bool | True if Z vertical, otherwise Y vertical |
| CalculationCode | PipingCode | Piping code |
| DefaultRoomTemperature | float | Default room temperature |
| DefaultOperatingDensity | float | Default operating density |
| DefaultTestDensity | float | Default test density |
| DefaultDesignCondition | OperatingCondition | Default design condition |
| ColdModulus | bool | True if cold modulus is used for all cases |
| HotAllowable | bool | True if allowable stress at operating temperature is used, otherwise design temperature is used |
| PressureStiffening | bool | True if pressure correction for bends |
| PressureElongation | bool | True if pressure elongation is considered for thermal expansion and test cases |
| SimplePressureStress | bool | True if simplified formula is used for pressure stress |
| ModalAnalysis | bool | True if modal extraction is performed |
| ModalRefCase | StaticCase | Young modulus is evaluated at the temperature of the reference case (Hot modulus option only) |
| CutOffFrequency | float | Cut-off frequency for modal extraction |
| MassGenerationFrequency | float | Frequency for automatic mass point generation |
| NbMaxModes | int | Maximum number of extracted mode shapes |
| MassModeling | int | |
| BranchModeling | TeeModeling | |
| BranchForcesAtSurface | bool | |
| ThermalCyclesPerElement | bool | |
| TrueTransientRange | bool | |
| AlternativeKe | bool | |
| Average3Sm | bool | |
| OptimizedResidualMoments | bool | |
| OutputFatigueAtAllPoints | bool | |
| OutputEq12And13Always | bool | |
| ExtrapolateFatigueCurves | bool | |
| ExtrapolateCreepCurves | bool | |
| RB3661_15 | bool | |
| ReducerModulus | ReducerModulus | |
| RB3662_24 | bool | |
| RB3662_Relaxation | bool | |
| SteelToConcreteRatio | float | |
| ConsistentMasses | bool | |

[Click here for more information about Units, PipingCode, OperatingCondition, TeeModeling and ReducerModulus](https://documentation.metapiping.com/Python/Classes/types.html)

The class **Model** also provides lists of the objects contained in the piping/structure model:

| Name | Description |
| ---- | ----------- |
| Nodes | List of **Node** |
| Elements | List of **Element** |
| LumpedMasses | List of **LumpedMass** |
| Restraints | List of **Restraint** |
| Materials | List of **Material** |
| Sections | List of **Section** |
| DLCSs | List of **DLCS** (Defined Local Coordinate System) |
| Tees | Dictionary<**Node**, **Tee**> |
| UserSIFs | List of **UserSIF** (User-defined SIF) |
| RestrainedNodes | List of restrained nodes |
| Layers | List of **Layer** |
| Specifications | List of the specification names (string) |
| Joints | List of **Joint** |
| PipingCodes | List of **PipingCode** |
| DesignConditions | List of **OperatingCondition** |
| Soils | List of **Soil** |
| Links | List of **NodeLink** |
| ModalSets | List of **ModalSet** |

[Click here for more information about Node](https://documentation.metapiping.com/Python/Classes/node.html)

[Click here for more information about Element and Tee](https://documentation.metapiping.com/Python/Classes/element.html)

[Click here for more information about LumpedMass, DLCS, UserSIF, Layer, Joint, PipingCode, OperatingCondition, Soil and NodeLink](https://documentation.metapiping.com/Python/Classes/types.html)

[Click here for more information about Restraint](https://documentation.metapiping.com/Python/Classes/restraint.html)

[Click here for more information about Material](https://documentation.metapiping.com/Python/Classes/material.html)

[Click here for more information about Section](https://documentation.metapiping.com/Python/Classes/section.html)

[Click here for more information about ModalSet](https://documentation.metapiping.com/Python/Classes/loadcase.html)

The class **Model** also provides lists of load cases :

| Name | Description |
| ---- | ----------- |
| StaticCases | List of **StaticCase** |
| THFCases | List of **THFCase** |
| RPrimCases | List of **RPrimCase** |
| RSecCases | List of **RSecCase** |
| CombiCases | List of **CombiCase** |
| StressCases | List of **StressCase** |
| RSpectra | List of **RSpectrum** |
| ThermalCases | List of **ThermalCase** |
| LoadSets | List of **LoadSet** |
| ExternalCases | List of **ExternalCase** |
| THFEvents | List of **THFEvent** |

[Click here for more information about all Loadcase types](https://documentation.metapiping.com/Python/Classes/loadcase.html)

The class **Model** also provides constants values (in MKS units) for restraint's default stiffness :

| Name | Value | Description |
| ---- | ----- | ----------- |
| ANCH_TSTIFF | 1.75e13 | |
| ANCH_RSTIFF | 1.13e12 | |
| ROTR_STIFF | 1.13e12 | |
| RSTN_STIFF | 8.75e8 | |
| SNUB_STIFF | 2.625e8 | |
| VSUP_STIFF | 8.75e8 | |
| VSUP_KPIN | 1.75e13 | |
| SPRS_TSTIFF | 17.513 | |
| SPRS_RSTIFF | 0.136 | |
| SPRF_TFLEX | 5.71e-14 | |
| SPRF_RFLEX | 8.851e-13 | |
