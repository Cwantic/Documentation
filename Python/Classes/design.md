---
layout: default
title: design
nav_order: 2
parent: Classes
grand_parent: Python
---

# design

The **design** object gives access to several methods and can be used only in [Design script](https://documentation.metapiping.com/Python/Design.html) during the 3D modelisation.

This object gives you access to the objects in selection, some current properties, the whole metal model. It gives you the opportunity to create your own [commands](https://documentation.metapiping.com/Python/Classes/commands.html) and to show information on the left panel.

## 1. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| selectedList | array of objects | Get the objects actually in selection (see § 2) |
| getType() | string | Get the type of an object in parameter (see § 3) |
| isType() | bool | Return True if param1 (object) is from type param2 (string) (see § 4) |
| createCommand() | CustomCommand | Return an empty command with a name (param1) (see § 5) |
| executeCommand() | - | Execute a CustomCommand passed in parameter (see § 6) |
| getVerticalVector() | array of 3 double | Return the current vertical vector (Y or Z) |
| getMetal() | metal | Access to current MetaL object of the study |
| getMetalWithSelection() | metal | Access to the owner MetaL of the selected element or node |
| addText() | - | Add a text on left panel |
| addSeparator() | - | Add a line separator on left panel |
| result | - | Set a message as output (empty = no message) |
| getCurrentLayer() | Layer | Return the current layer |
| getCurrentJointType() | JointType | Return the current joint type |
| getCurrentSpecValues() | CurrentPipingValues | Return the current piping/structure values (section, material, diameter, radius...) |
| getScriptDirectory() | string | Return the current script directory |
| createVariableWindow() | createVariableWindow | Return an empty window |

## 2. selectedList

Retrieve the current selection list. This list can contain nodes, elements, restraints...

```python
# Python script
n = len(design.selectedList)
if n==2:
    # we have 2 selected objects
    # you can access the object i : design.selectedList[i]
```

---
## 3. getType()

Retrieve the Assembly.Class type of an object.

```python
# Python script
# ...
value = design.getType(design.selectedList[0])
result = value
```

This will show a message box with the **complete class type** of the first selected object

Example : "Cwantic.MetaPiping.Core.Node" for a node. **Cwantic.MetaPiping.Core** is the Assembly and **Node** is the class type.

---
## 4. isType()

Check if the object (param1) is from class type (param2)

```python
# Python script
if design.isType(design.selectedList[0], "Node"):
    # ...
```

Unlike getType(), isType() do not refer to the assembly of the class type.

---
## 5. createCommand()

Return an empty [CustomCommand](https://documentation.metapiping.com/Python/Classes/commands.html) with a given name (param1).

createCommand() must be used in conjunction with design.executeCommand()

```python
# Python script
cmd = design.createCommand("MyCommand1")
# ...
# Fill cmd with sub commands
# ...
design.executeCommand(cmd)
```

See an example of [custom command](https://documentation.metapiping.com/Python/Samples/lyre.html).

---
## 6. executeCommand() 

Execute the [CustomCommand](https://documentation.metapiping.com/Python/Classes/commands.html) passed in parameter.

design.executeCommand() must be used in conjunction with createCommand()

```python
# Python script
cmd = design.createCommand("MyCommand1")
# ...
# Fill cmd with sub commands
# ...
design.executeCommand(cmd)
```

See an example of [custom command](https://documentation.metapiping.com/Python/Samples/lyre.html).

---
## 7. getVerticalVector()

Return (0, 0, 1) if Z vertical or (0, 1, 0) if Y vertical

```python
# Python script
verticalvec = design.getVerticalVector()
```

---
## 8. getMetal()


Imagine user wants to check if the 3D model exists (result as a text in Outputs[0]).
```python
# Python script
metal = design.getMetal()
if metal != None:
    study.Outputs[0] = "The model exists"
else:
    study.Outputs[0] = "The model doesn't exist"
```

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.


---
## 9. addText()

In review mode, it can be usefull to shows some information about the model or about the selected objects.

These informations can be shown in a standard way using the same controls as MetaPiping.

You can show texts on the left panel using the **addText** method :

| Param | Type | Description |
| ---- | ----------- | ----------- |
| Text | String  | The text |
| IsTitle | Bool  | True or False - if True, enlarged text |
| R | Byte  | Red component of the text color |
| G | Byte  | Green component of the text color |
| B | Byte  | Blue component of the text color |

```python
# Python script
distance = 1.0

design.addText("Distances", True, 255, 255, 255)
design.addSeparator()
design.addText(" ")
design.addText("Distance = " + str(round(distance, 3)) + " m", False, 255, 255, 255)
```

---
## 10. addSeparator()

In the same way as the **addText** method, **addSeparator** just add a white horizontal line

```python
# Python script
distance = 1.0

design.addText("Distances", True, 255, 255, 255)
design.addSeparator()
design.addText(" ")
design.addText("Distance = " + str(round(distance, 3)) + " m", False, 255, 255, 255)
```

---
## 11. result

If result is not an empty string, a message will appears at the end of exuction of the script.

```python
# Python script
res = "Error !"
if valid:
    res = ""
design.result = res
```

---

## 12. getScriptDirectory()

Returns the current script directory.

```python
# Python script
scriptdirectory = design.getScriptDirectory()
```

---

## 13. createVariableWindow()

createVariableWindow() returns an empty window that will show user's variables.

```python
# Python script
window = design.createVariableWindow()
```

### 13.1 Window components

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
