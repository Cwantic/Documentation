---
layout: default
title: material
nav_order: 10
parent: Classes
grand_parent: Python
---

# Material

## 1. Material

**Material** is the base class for all materials. In MKS units !

### 1.1 Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Name | String | Material name |
| Type | MaterialType | Type of material |
| Target | MaterialTarget | Target, see below |
| RefTemperature | Float | Reference temperature |
| ThermalExpansionOption | Int | |
| Density | Float | Density |
| Poisson | Float | Poisson coefficient |
| MaxTemperature | Float | Max temperature |
| Description | String | Description |

**MaterialTarget** can be:

    Piping
    Structure
    Bolting
    Welding

```python
# Python script
from Cwantic.MetaPiping.Core import MaterialTarget

target = MaterialTarget.Piping
```

## 2. RegularMaterial

**RegularMaterial** inherits from **Material**. Every **RegularMaterial** object has the properties of **Material**.

**RegularMaterial** represents regular materials which properties are independent of time but dependant of temperature.

### 2.1 Properties

Too complex. Use MaterialLibraryModel object to load a *.materials from database.

```python
# Python script
from Cwantic.MetaPiping.Core import MaterialLibraryModel

library = MaterialLibraryModel("");
library.LoadFromFile(libraryFilename);
materialModel = library.GetMaterialByDenomination(materialName)
material = materialModel.GetMaterial(library.Units) # In MKS units
...
```

# MaterialModel

Class of material in USER units !

```python
# Python script
from Cwantic.MetaPiping.Core import MaterialModel

materialModel = MaterialModel()
...
```

| Property | Type | Description | Unit Metric | Unit USA |
| ---- | ----------- | --- | ---- | ---- |
| Denomination | String | Name | - | - |
| Description | String | Description | - | - |
| MaterialType | MaterialType | Type of material, see below | - | - |
| Properties | List of MaterialProperties | see below | - | - |
| MaxTemperature | Float | Max temperature | °C | °F |
| RefTemp | Float | Reference temperature | °C | °F |
| SulfurPercent | Float | Percent of sulfur | - | - |
| RO | Float | Density | kg/m³ | lb/ft³ |
| SG | Float | Poisson's ratio | - | - |
| ThermalExpansionOption | Int | 0, 1 or 2, see below | - | - |
| HDPE_EX | Float | Thermal Expansion for HDPE material | 10^-6.mm/mm/°C | 10^-6.in/in/°F |
| HDPE_Spec | HDPESpec | see below | - | - |
| RCCMRx_Spec | String | see below | - | - |
| FatigueCurve | List<KeyValuePair<double, double>> | None by default, see below | - | - |

ThermalExpansionOption :

    0 : Linear thermal expansion (LTE)
    1 : Mean coefficient calculated by linear interpolation of LTE values
    2 : Mean coefficient calculated by linear interpolation of submitted values of α

HDPESpec :

    HDPESpec.ISO  : EN 15494:2015 with coefficient = 1.25
    HDPESpec.ASTM : ASTM with factor = 0.63
    HDPESpec.ASME : ASTM with factor = 0.5
    HDPESpec.EDF1 : D305914006648 [E] EDF guide
    HDPESpec.EDF2 : D305921021240 [A] EDF guide
    HDPESpec.EDF3 : D305921021240 [B] EDF guide

RCCMRx_Spec :

    "18AS" : X10CrMoVNb9-1 RM 242-2 & 243-1 + RPP2-2012-9%CR (P91)
    "1S"   : X2CrNiMo17-12-2(N) (316L(N))
    "3S"   : X2CrNiMo17-12-2, X2CrNiMo17-12-3 and X2CrNiMo18-14-3 (316L)
    "4S"   : X2CrNi18-9 & X2CrNi19-11 (304L)
    "8S"   : X4CrNiMo16-05-01

FatigueCurve :

a curve is a list of pairs of stress/cycles (stress in N/mm² | ksi )

# MaterialProperties

Material properties for a specific temperature, in USER units.

```python
# Python script
from Cwantic.MetaPiping.Core import MaterialProperties

properties = MaterialProperties()
properties.TE = 21
...
```

| Property | Description | Unit Metric | Unit USA |
| -------- | ----------- | ---- | ---- |
| TE | Temperature | °C | °F |
| EH | Modulus of Elasticity | kN/mm² | 10^6.psi |
| EX | Thermal Expansion | 10^-6.mm/mm/°C | 10^-6.in/in/°F |
| SH | Non-Class 1 Allowable Stress | N/mm² | ksi |
| SY | Yield Stress | N/mm² | ksi |
| SU | Ultimate Tensile Stress | N/mm² | ksi |
| SM | Class 1 Allowable Stress | N/mm² | ksi |
| CR | Creep | N/mm² | ksi |
| GH | Shear Modulus | kN/mm² | 10^6.psi |
| CO | Class 1 Thermal Conductivity | kJ/hr/m/°C | btu/hr/ft/°F |
| DI | Class 1 Thermal Diffusivity | mm²/s | ft²/hr |
| E2 | Modulus of Elasticity 2 | kN/mm² | 10^6.psi |

# MaterialType

Type of material

```python
# Python script
from Cwantic.MetaPiping.Core import MaterialType

materialType = MaterialType.CarbonSteel
...
```

| Property | Value |
| ---- | ----- |
| CarbonSteel | 1 |
| LowAlloySteel | 2 |
| MartensiticSteel | 3 |
| AusteniticSteel | 4 |
| NickelChromeSteel | 5 |
| NickelCopperSteel | 6 |
| Other | 9 |
| Composite | 10 |
| HDPE | 11 |
| RCCMRx | 100 |
