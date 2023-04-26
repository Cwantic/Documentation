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
| getCurrentLayerID() |  |  |
| getCurrentJointType() |  |  |
| getMetal() |  |  |
| addText() |  |  |
| addSeparator() |  |  |
| result |  |  |


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
## 8. getCurrentLayerID()



```python
# Python script

```

---
## 9. getCurrentJointType()



```python
# Python script

```

---
## 10. getMetal()



```python
# Python script

```

---
## 11. addText()



```python
# Python script

```

---
## 12. addSeparator()



```python
# Python script

```

---
## 13. result



```python
# Python script

```

---