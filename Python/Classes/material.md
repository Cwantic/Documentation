---
layout: default
title: material
nav_order: 9
parent: Classes
grand_parent: Python
---

# Material

## 1. Material

**Material** is the base class for all materials.

### 1.1 Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Name | String | Material name |
| Type | MaterialType | Type of material |
| RefTemperature | float | Reference temperature |
| Density | float | Density |
| Poisson | float |Poisson coefficient |
| MaxTemperature | float | Max temperature |
| Description | string | Description |


## 2. RegularMaterial

**RegularMaterial** inherits from **Material**. Every **RegularMaterial** object has the properties of **Material**. 

**RegularMaterial** represents regular materials which properties are independent of time.


### 2.1 Properties

No additional properties.
