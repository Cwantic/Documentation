---
layout: default
title: command
nav_order: 5
parent: Classes
grand_parent: Python
---

# CustomCommand

A custom command is simply a list of MetaPiping existing commands.

## 1. Creation

A **CustomCommand** object can only be created by **design** object via **createCommand** method :

```python
# Python script
cmd = design.createCommand("MyCommand1")
# ...
```

The **CustomCommand** must be defined by a unique name (first param of the createCommand method).

[See the description of the object design](https://documentation.metapiping.com/Python/Classes/design.html)

## 2. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| addSubCommand | bool | Add an existing command by a name and command params (array) |

Example : 

We want to remove the selected objects.
First, create an empty array, add the selectedList from **design** object
Then add the name of the remove command and the params to the **CustomCommand**

```python
# Python script
params = []
params.append(design.selectedList)
        
valid = cmd.addSubCommand("RemoveElementCommand", params)
```

Every command has its own param list !

Return False if the command name doesn't exists or the params are incorrect.

## 3. Execution

Finally, a **CustomCommand** (cmd in the example) can be executed by **design** object via **executeCommand** method:

```python
# Python script
# ...
design.executeCommand(cmd)
```

## 4. Commands

