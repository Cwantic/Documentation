---
layout: default
title: General
nav_order: 2
parent: Settings
---

# General

![Image](../Images/General.jpg)

Define all options proposed by all **PLUGINS**.

## 1. Code Aster

Code Aster is the main **SOLVER** of MetaPiping. It is developped and maintained by EDF (https://code-aster.org).

The Windows version is installed by MetaPiping but you can install the Linux version manually and specify the location on your computer.

In this case, you have to select **LINUX** in the option combobox.

## 2. Explorer

The project explorer let you **calculate** a python script that explores the project/results and show informations.

All projects share the same script that you can specify in this option.

[See Info page for more information](https://documentation.metapiping.com/Python/Info.html).

## 3. Metal

**MetaL** is the name of the 3D modelisation inside MetaPiping and also the file extension of the saved file.

You can specify here 2 values (integers):
* The name of the very first node
* The increment for the next node name

In the example, the nodes will start with name "10" then "20", "30", "40"...

## 4. MetaPiping

The application let the user work with american unities. In this case, it is also possible to specify to work with **imperial** notation.

Example: 4"1/8 for a diameter

## 5. Pipestress

For the users of PIPISTRESS that have installed the plugin, they can specify the path of the SOLVER (*PIPESTRESS64W.exe*) and the HELP file (*PIPESTRESS.chm*).

## 6. Project

You can specify the path of your favorite text editor in case of text report editing.

If blanck, MetaPiping uses Windows NotePad.

