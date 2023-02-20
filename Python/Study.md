---
layout: default
title: Study
nav_order: 2
parent: Python
---

# Study

A study is a workflow of **bricks** and **connections** - [See Study page for more information](https://documentation.metapiping.com/Explorer/Study.html)

User can create its own **bricks** via Python scripts.

Click on **Python** in application's ribbon in the current study :

![Image](../Images/PythonStudy1.jpg)

Select a script via the drop-down list :

![Image](../Images/PythonStudy2.jpg)

You can create scripts that are independant of the current study, you can **inject** data to the internal model (MetaL - point 1), you can **extract** data from the internal model (MetaL - point 2), or you can **extract** data from the solution (Solution - point 3).

Let's see how to create this kind of script.

---

## 1. Script properties

From the Home/Python, click on button 1 (Add project script) :

![Image](../Images/PythonMenu.jpg)

Give it a name and wait several seconds the ***Python Virtual Environment*** is generating...

A new *main.py* will be created in the file explorer and *Inputs* and *Outputs* nodes in the Project script. Requirements.txt and the Editor are empty :

![Image](../Images/PythonStudy3.jpg)

Buttons with three points indicates the presence of a dropdown list :

In file explorer :

```
    - Add a python file
    - Import image
    - Open folder in explorer
    - Refresh
    - Remove selected file
```

In Project script :

```
    - Add TEXT input
    - Add TEXTLIST input
    - Add EDIT input
    - Add METAL input
    - Add SOLUTION input
    - Add TEXT output
    - Add FILENAME output
    - Save
    - Remove
```

In requirements.txt :

```
    - Save
    - Install
```

In main.py

```
    - Save
```

---

## 2. Independant script

This kind of script don't need to have access to the files of the current study/project/metaL/solution but only some interaction with the user.

It can for example ask some data from the user via INPUT entries and give answers after treatment via OUTPUTS.



---
## 3. MetaL injection

Based on the explained [MetaL](https://documentation.metapiping.com/Python/Classes/metal.html) internal structure, user can create his own **CONVERTERS** from other file format or from company's internal datas.

Cwantic has created **PLUGINS**, with the same principle, that converts **PIPESTRESS** and **NUPIPE** file format to MetaL file format.

User can for example inject **LOADIND TEMPLATES** in current project based on his own datas.



---

## 4. MetaL extraction

Documentation will come soon...

---

## 5. Solution extraction

Documentation will come soon...

