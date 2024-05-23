---
layout: default
title: Explorer
nav_order: 2
has_children: true
---

# Explorer

![Image](../Images/Explorer1.jpg)

Click on **Organize** button to access the explorer panel.

## 1. Organizer

You can organize your projects in the left panel.

Right click on **Projects** lets you :

![Image](../Images/Explorer2.jpg)

- Add a new piping project (if MetaPiping active on your licence)
- Add a new structure project (if MetaStructure active on your licence)
- Import a project (file with extension *.prockage)
- Add a new folder

Select a **folder** (Ex : Group A). Right click on it lets you :

![Image](../Images/Explorer3.jpg)

- Add a new piping project (if MetaPiping active on your licence)
- Add a new structure project (if MetaStructure active on your licence)
- Import a project (file with extension *.prockage)
- Add a new sub-folder
- Delete the current folder with all projects

Select a **project** (Ex : Demo). Right click on it lets you :

![Image](../Images/Explorer4.jpg)

- Delete the current project
- Export the project (file with extension *.prockage)

{: .warning }
>The EXPORT project command (from source computer) will copy all studies but also all external files, the used python scripts... and will paste it (or install scripts if not exist on target computer) during IMPORT command.

{: .warning }
>The EXPORT/IMPORT project will not work for **distant studies** (those created by opening a **FRE** file directly from windows explorer) !

## 2. Project preview

A **project** is a container of **studies**.

When selecting a project, a preview of all studies is shown :

![Image](../Images/Explorer5.jpg)

You can have general information about one study by selecting a thumbnail :

![Image](../Images/Explorer6.jpg)

### 2.1 Project/study edition

![Image](../Images/Explorer8.jpg)

To edit a project or a study, just **double click** on the thumbnail of any study (1).

To edit a specific study, **click** on button (2).

## 3. Python script

A **Python script** can be created to explore the current **MetaL** and **results** of the study and show your own information.

![Image](../Images/Explorer7.jpg)

Click [here](https://documentation.metapiping.com/Python/Info.html) to have more information about python script creation for a project.

Click [here](https://documentation.metapiping.com/Settings/General.html) to see how to define a python script as default "information script" in the settings.

## 4. External opening

User can **Right click** a *.fre file in Windows explorer and ask to open it with MetaPiping.

A project will be created with a study and a complete connection of the internal MetaL to this file + solver PIPESTRESS.

Click [here](https://documentation.metapiping.com/Explorer/Study.html#35-pipestress) to have more information about PIPESTRESS **bricks**.