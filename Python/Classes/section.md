---
layout: default
title: section
nav_order: 9
parent: Classes
grand_parent: Python
---

# Section

## 1. Section

**Section** is the base class for all sections.

### Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Name | String | Material name |
| A | float | Cross-sectional area |
| Ax | float | Shear area in local X' axis |
| Ay | float | Shear area in local Y' axis |
| Ix | float | Inertia aroud local X' axis  |
| Iy | float | Inertia aroud local Y' axis  |
| It | float | Torsional inertia |
| LinearMass | float | Linear mass|
| Description | string | Description |

## 2. PipeSection

**PipeSection** inherits from **Section**. Every **PipeSection** object has the properties of **Section**. 

**PipeSection** represents circular hollow pipe sections.

### Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Diameter | float | Diameter |
| Thickness | float | Thickness |
| InsulationThickness | float | Insulation thickness |
| Corrosion | float | Corrosion allowance |
| Erosion | float | Erosion allowance |

## 3. BeamSection

**BeamSection** inherits from **Section**.

**BeamSection** represents beam sections.

### Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Type | BeamSectionType | Type of section |
| InputProperties | bool | True if section properties are input by the user, otherwise the properties are calculated from the section geometry |
| H | float | Height |
| B | float | Width |
| Tw | float | Web thickness |
| Tf | float | Flange thickness |

The type *BeamSectionType* is an enumeration with the following values:

| Value | Description |
| ---  | ----------- |
| NonStandard | Non-standard section. The properties must be input |
| I |  Double tee |
| Channel |  Channel |
| Rect |  Rectangular |
| Tee | Tee |
| EqualAngle | Equal angle. H is the side length, Tf is the thickness |
| UnequalAngle | Unequal angle. H and B are the side lengths, Tf is the thickness |
| Round | Round. H is the diameter, Tf is the thickness |
| Plate | Plate. H and B are used |
