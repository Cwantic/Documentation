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
| getMaterialLibraryModel() | MaterialLibraryModel | Access to a material library by its name (without .materials) |
| createMaterialLibraryModel() | MaterialLibraryModel | Create a material library by a name (without .materials) |
| showInformation() | - | Add 2 strings into the description of a study (one for column 1 and one form column 2)|
| getScriptDirectory() | string | Return the current script directory |
| createVariableWindow() | createVariableWindow | Return an empty window |

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.

See [solution](https://documentation.metapiping.com/Python/Classes/solution.html) for more information.

See [libraries](https://documentation.metapiping.com/Python/Classes/libraries.html) for more information about materialLibraryModel.

---

## 2. Examples

### 2.1 Inputs/Outputs

Imagine a **brick** (script) composed of an EDIT control (user can write something) and a TEXT control (text link from another brick).

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

### 2.6 getMaterialLibraryModel()

Return a MaterialLibraryModel based on a name (without extension).

Return **None** if the library doesn't exist.

See [libraries](https://documentation.metapiping.com/Python/Classes/libraries.html) for more information about materialLibraryModel with an example.

### 2.7 createMaterialLibraryModel()

You can create your own library of material based on a name (without extension).

Return a new empty MaterialLibraryModel or **None** if already exists.

See [libraries](https://documentation.metapiping.com/Python/Classes/libraries.html) for more information about materialLibraryModel with an example.

### 2.8 showInformation()

This method is only accessible in scripts that show informations about the MetaL and the results of the current study in **Explorer**.


```python
metal = study.getMetal()
if metal != None:
    study.showInformation('Model exists !', '') 
```

[See an example here](https://documentation.metapiping.com/Python/Samples/info.html) : Show informations about a study.

### 2.9 getScriptDirectory()

Returns the current script directory.

```python
# Python script
scriptdirectory = design.getScriptDirectory()
```

---

### 2.10 createVariableWindow()

createVariableWindow() returns an empty window that will show user's variables.

```python
# Python script
window = design.createVariableWindow()
```

**Window components** :

| Method | Params  | Description |
| ------ | ------  | ----------- |
| AddComment | string | Add a comment (text)|
| AddValue | string, string, double | Add a numeric variable (variable name, text, default value) |
| AddImage | string | Add an image (local filename) |
| AddList | string, string, [string], int | Add a variable list of texts (variable name, text, array of texts, default index) |
| AddCheck | string, string, bool| Add a variable checkbox (variable name, text, default value) |
| ShowModal | bool | Show the window and return true if click on OK button |
| GetValue | string | Return a **numerical** value (variable name) |

```python
# Python script
directory = design.getScriptDirectory()

window = design.createVariableWindow()
window.AddComment("Fill the variables")
window.AddValue("L", "L =", 10)
window.AddList("CHOICE", "Choice =", ["Choice A", "Choice B", "Choice C"], 1)
window.AddCheck("ACTIVE", "Active ?", True)
window.AddImage(os.path.join(directory, "image.jpg"))
if window.ShowModal():
    val1 = window.GetValue("L")
    CHOICE_ID = window.GetValue("CHOICE")
    # CHOICE_ID = 0, 1 or 2
    val2 = 0
    if CHOICEID == 1:
        val2 = 0.5
    else:
        if CHOICE == 2:
            val2 = 3
    ACTIVE_ID = window.GetValue("ACTIVE")
    # ACTIVE_ID = 0 (False) or 1 (True)
    val3 = ACTIVE_ID == 1
```

In this example, we have 3 variables (L, CHOICE, ACTIVE), 1 comment and 1 image. We suppose image.jpg existing in the script directory next to main.py.


L will show the default value of 10

CHOICE will show the default value of "Choice B" (index 1)

ACTIVE will be checked by default

After window show :

val1 will receive the user value for L

val2 will receive the user value for CHOICE transformed to a real value (0, 0.5 or 3)

val3 will receive the user value for ACTIVE transformed to bool
