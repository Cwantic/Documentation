---
layout: default
title: libraries
nav_order: 8
parent: Classes
grand_parent: Python
---

# 1. MaterialLibraryModel

A **MaterialLibraryModel** is a database containing a list of MaterialModel.

| Name | Return | Description |
| --- | ----------- | ----------- |
| GetMaterialByDescription() | MaterialModel | Access to a materialModel by its description (param1) |
| MaterialDescriptionExists() | bool | Return True if a material exists with this description (param1) |
| SetRefTemperature() | - | Set the reference temperature (param1) for all materials [°C in metric units] |
| AddMaterial() | MaterialModel | Add an empty materialModel to the library (without description) |
| DeleteMaterial() | - | Delete the materialModel (param1) from the library |
| Save() | - | Save the library |

## 1.1 MaterialModel

A **MaterialModel** represents the definition of a material.

| Name | Return | Description |
| --- | ----------- | ----------- |
| Description |  | The description of the material |
| MaterialType |  | The type of material |
| MaxTemperature |  | Temperature max [°C in metric units] |
| RO |  | Density [kg/m³ in metric units] |
| SG |  | Poisson's ratio |
| Properties |  | List of MaterialProperties |
| Properties.Count | int | Number of MaterialProperties |
| Properties.[i] | MaterialProperties | ith MaterialProperties |
| AddProperties() | MaterialProperties | Add a new line of properties for a temperature |
| Deleteproperties() | - | Delete a MaterialProperties (param1) |

## 1.2 MaterialType

To access the **MaterialType** property of a **MaterialModel**, you need to import the object from *Cwantic.MetaPiping.Core* :

```python
# Python script   
from Cwantic.MetaPiping.Core import MaterialType
```

| Values : |
| --- | 
| MaterialType.CarbonSteel | 
| MaterialType.LowAlloySteel | 
| MaterialType.MartensiticSteel | 
| MaterialType.AusteniticSteel |
| MaterialType.NickelChromeSteel | 
| MaterialType.NickelCopperSteel | 
| MaterialType.Other |
| MaterialType.Composite | 
| MaterialType.HDPE | 

Example :

```python
# Python script   
from Cwantic.MetaPiping.Core import MaterialType
...
if mat.MaterialType == MaterialType.CarbonSteel:
    ...
```

## 1.3 MaterialProperties

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

## 1.4 Example

Imagine user wants to get the first temperature of a specific MaterialModel (study.Inputs[1]) from a specific library (study.Inputs[0]). Result as a text in Outputs[0].

```python
# Python script   
libname = study.Inputs[0]
matname = study.Inputs[1]

lib = study.getMaterialLibraryModel(libname)
if lib != None:
    mat = lib.GetMaterialByDescription(matname)
    if mat != None:
        study.Outputs[0] = str(mat.Properties[0].TE)
    else:
        study.Outputs[0] = "Material not found !"
else:
    study.Outputs[0] = "Library not found !"
```
