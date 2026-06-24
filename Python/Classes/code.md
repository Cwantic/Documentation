---
layout: default
title: code
nav_order: 14
parent: Classes
grand_parent: Python
---

# Codes

## 1. BaseCode

**BaseCode** is the abstract class that describes all standard codes.

### Properties

| Name | Type | Description |
| --- | ----------- | ----------- |
| Code | char | |
| Edition | int | |
| IsImplemented | bool | |
| Name | string | |
| ReleaseDate | string | |
| Target | CodeTarget | |
| Warnings | List of string | For internal use |
| Output | TextReport | For internal use |

**CodeTarget** :

| Property | Value |
| ---- | ----------- |
| Piping | 0 |
| Structure | 1 |
| Anchor | 2 |

```python
# Python script
from Cwantic.MetaPiping.Core import CodeTarget

target = CodeTarget.Piping
```

## 2. CalculationCode

**CalculationCode** is the abstract class that describes a calculation code.

It inherits from **BaseCode** class.

It contains the model and the solution.

### 2.1 PipingCode

**PipingCode** describes a piping code.

It inherits from **CalculationCode** class.

Target => CodeTarget.Piping

```python
# Python script
from Cwantic.MetaPiping.Core import PipingCode

# RCC-MRx Vol. B Class N1 Ed. 2022
code = PipingCode()
code.Code = 'R'
code.Edition = 1
```

[Click here for more information about all possible code and edition](https://documentation.metapiping.com/Analysis/Codes.html)


### 2.2 StructureCode

**StructureCode** describes a structural code.

It inherits from **CalculationCode** class.

Target => CodeTarget.Structure

```python
# Python script
from Cwantic.MetaPiping.Core import StructureCode

# EN13480-3 Ed. July 2024
code = StructureCode()
code.Code = 'F'
code.Edition = 4
```

[Click here for more information about all possible code and edition](https://documentation.metapiping.com/Analysis/Codes.html)

## 3. AnchorCode

**AnchorCode** describes an anchor calculation code.

It inherits from **BaseCode** class.

Target => CodeTarget.Anchor

```python
# Python script
from Cwantic.MetaPiping.Core import AnchorCode

# EN1992_4 Ed. 2018
code = AnchorCode()
code.Code = 'E'
code.Edition = 1
```
[Click here for more information about all possible code and edition](https://documentation.metapiping.com/Analysis/Codes.html)
