---
layout: default
title: Study
nav_order: 2
parent: Explorer
---

# Study

A study consists of a **Diagram** of bricks and connections.

It is a folder that contains at least a 3D model and the calculation results.

![Image](../Images/Study1.jpg)

The **study** screen consists of :

1. The **Bricks**
2. The main panel that shows the **Study Diagram**
3. The **Solver brick**
4. A **Connector**
5. A **Connector**
6. The **Edit** button to open the 3D model

An empty study contains at least one **Study brick** and one **Solver brick**.
## 1. Connections

Connect the connectors 4 and 5 to define the current **Solver**. 

    Press left mouse button above connector 4 -> move the mouse to connector 5 -> release the left button

    To remove the connection : select the connection and press DELETE on the keyboard.

Select **Aster** for example :

![Image](../Images/Study2.jpg)

Now, the project will be calculated with **Code_Aster Solver**

Click [here](https://documentation.metapiping.com/Analysis/Solver.html) to have more information about Code_Aster.

## 2. Empty model

Click **Edit** (6) to start a new design.

Click [here](https://documentation.metapiping.com/Design/index.html) to have more information about the design.

## 3. Piping bricks

![Image](../Images/Study1A.jpg)

### 3.1 File

This create a brick that lets you import a file of any extension.

![Image](../Images/Study3.jpg)

This is useful only for Python scripts that need a file as input (Ex : Excel file or Text file).

Click on the button to open a search file dialog.

Use the connector to send the file to another brick as an input.

{: .warning }
>You can import another **MetaL** file and connect it to the **MetaL** connector of the **Study brick**.

### 3.2 Study link

This create a brick that virtually replicates existing studies inside another one. This is useful to create new nodes based on those of the linked studies.

![Image](../Images/Study10.jpg)

{: .warning }
>You can connect multiple studies. All must be defined in the same coordinate system XYZ.

{: .warning }
>In design, you can hide the linked studies.

{: .warning }
>In design, you cannot modify elements of linked studies.

### 3.3 PCF

The **plugin** PCF lets you import *.pcf files.

![Image](../Images/Study4.jpg)

Open a file and connect it to the **MetaL** connector of the **Study brick**.

This will convert the PCF to the MetaL file format.

### 3.4 PIPSYS

The **plugin** PIPSYS lets you import files with several extensions.

![Image](../Images/Study5.jpg)

Open a file and connect it to the **MetaL** connector of the **Study brick**.

This will convert the PIPSYS to the MetaL file format.

### 3.5 PIPESTRESS

The **plugin** PIPESTRESS lets you import *.fre (and *.thf files).

The Time History File is not mandatory and depends on the corresponding FRE file.

![Image](../Images/Study6.jpg)

Open a file and connect it to the **MetaL** connector of the **Study brick**.

This will convert the FRE to the MetaL file format.

The **plugin** PIPESTRESS also lets you import POSTR files for postprocessing.

![Image](../Images/Study7.jpg)

Open a file and connect it to the **Solution** connector of the **Solver brick**.

It will produce a text file (in the result cell) that can be edited by **double click**.

You can specify your favorite text editor in the settings.

The **plugin** PIPESTRESS also lets you configure all bricks by just importing a *.fre file. It checks if a *.thf file is needed, sets the Solver to PIPESTRESS and makes all connections automatically.

![Image](../Images/Study8.jpg)

### 3.6 Python

You can create your own **brick** thanks to the Python scripts.

![Image](../Images/PythonStudy2.jpg)

*Example of a brick connected to the MetaL and another one connected to the solution.*

Click [here](https://documentation.metapiping.com/Python/index.html) to have more information about the script creation.

### 3.7 Comment

This creates a brick with text and color capabilities.

Useful to show the state of progress of the study to other users. A conventionnal color code can be established.

![Image](../Images/Study9.jpg)

### 3.8 Post-processing : supports + flanges

![Image](../Images/PostProc1.jpg)

Documentation will come soon...

## 4. Structure bricks

![Image](../Images/Study1B.jpg)

### 4.1 File

This create a brick that lets you import a file of any extension.

![Image](../Images/Study3.jpg)

This is useful only for Python scripts that need a file as input (Ex : Excel file or Text file).

Click on the button to open a search file dialog.

Use the connector to send the file to another brick as an input.

### 4.2 Study link

This creates a brick that virtually replicates existing studies inside another one. This is useful to create new nodes based on those of linked studies.

![Image](../Images/Study10.jpg)

{: .warning }
>You can connect multiple studies. All must be defined in the same coordinate system XYZ.

{: .warning }
>In design, you can hide the linked studies.

{: .warning }
>In design, you cannot modify elements of linked studies.

### 4.3 BEAMSTRESS

This creates a brick that lets you import *.bst files that are converted to MetaL file.

![Image](../Images/Study11.jpg)

{: .warning }
>ATTENTION, only version 2.0.0 or higher bst files can be imported. If the file version is too old, we recommand to open it with a recent BEAMSTRESS and save the model again.

### 4.4 Python

You can create your own **brick** thanks to the Python scripts.

Click [here](https://documentation.metapiping.com/Python/index.html) to have more information about the script creation.

### 4.5 Comment

This creates a brick with text and color capabilities.

Useful to show the state of progress of the study to other users. A conventionnal color code can be established.
