---
layout: default
title: study
nav_order: 1
parent: Classes
grand_parent: Python
---

# study

The **study** object gives access to several methods and can be used only in [Project script](https://documentation.metapiping.com/Python/Study.html).



## 1. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| Inputs | array of string | Access to an item [i] in Project script's Inputs |
| Outputs | array of string | Access to an item [i] in Project script's Outputs |
| getDirectory() | string | Get the current study directory|
| createMetal() | metal | Create an empty MetaL object |
| getMetal() | metal | Access to current MetaL object of the study |
| getSolution() | solution | Access to current Solution object of the study |
| getMaterialLibraryModel() | materialLibraryModel | Access to a material library by its name (without .materials) |
| createMaterialLibraryModel() | materialLibraryModel | Create a material library by a name (without .materials) |
| showInformation() | - | Add a string into the description of a strudy |

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.

See [solution](https://documentation.metapiping.com/Python/Classes/solution.html) for more information.

See [libraries](https://documentation.metapiping.com/Python/Classes/libraries.html) for more information about materialLibraryModel.

---

## 2. Examples

### 2.1 Inputs/Outputs

Imagine a **brick** (script) composed by an EDIT control (user can write something) and a TEXT control (text link from another brick).

We want that when clicking on **Run** button, the script returns as result the combination of the EDIT and the TEXT :

![Image](../../Images/PythonSample2_1.jpg)

```python
# Python script    
study.Outputs[0] = study.Inputs[0] + " " + study.Inputs[1]
```

### 2.2 getDirectory()

Imagine user wants to save content in a text file in the current study directory :
```python
# Python script   
dir = study.getDirectory()
filename = os.path.join(dir, "info.txt")
with open(filename,'w') as f:
	f.write(content)
```

### 2.3 createMetal()

The **metal** object contains the whole definition of a piping : (geometry, loads, code and edition...).

Imagine user wants to create an empty model for the current study :

REM : a model contains default values but must have at least one layer

REM : the model of the study must be named "conception.metaL"


```python
# Python script
from Cwantic.MetaPiping.Core import Layer

metal = study.createMetal()

layer = Layer("0")
metal.Layers.Add(layer) # Attention ! metal.Layers is a C# list. Use Add instead of append

dir = study.getDirectory()
filename = os.path.join(dir, "conception.metaL")

metal.SaveToFile(filename)
```

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.

### 2.4 getMetal()

Imagine user wants to check if the 3D model exists (result as a text in Outputs[0]).
```python
# Python script
metal = study.getMetal()
if metal != None:
    study.Outputs[0] = "The model exists"
else:
    study.Outputs[0] = "The model doesn't exist"
```

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.

### 2.5 getSolution()

The **solution** object contains all results after calculation.

Imagine user wants to check if the solution exists (result as a text in Outputs[0]).

```python
# Python script
solution = study.getSolution()
if solution != None:
    study.Outputs[0] = "The solution exists"
else:
    study.Outputs[0] = "The solution doesn't exist"
```

See [solution](https://documentation.metapiping.com/Python/Classes/solution.html) for more information.
