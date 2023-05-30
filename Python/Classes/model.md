---
layout: default
title: node
nav_order: 6
parent: Classe
grand_parent: Python
---

# Model

**Model** is the class that describes the whole piping geometry and loadings.


## 1. Properties

| Name | Return | Description |
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
| ModalRefCase | StaticCase | Young modulus is evaluated at the temperature of the reference case (Hot modulus option only)  |
| CutOffFrequency | float | Cut-off frequency for modal extraction |
| MassGenerationFrequency | float | Frequency for automatic mass point generation |
| NbMaxModes | int | Maximum number of extracted mode shapes |

The class **Model** also provides lists of the objects contained in the piping model:


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
| RestrainedNodes | List of restrained nodes|
| Layers | List of **Layer** |
| Specifications | List of the specification names (string) |


