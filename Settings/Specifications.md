---
layout: default
title: Specifications
nav_order: 4
parent: Settings
---

# Specifications

![Image](../Images/Spec1.jpg)

MetaPiping let you create **specifications** = predefined choice of piping elements and properties dedicated to a particular project.

It brings together a variety of information :

- Calculation code and edition
- Library of materials
- Library of piping elements

Click the **+** button to add a new specification or click the **-** button to remove an **unused** one.

>ATTENTION, do not remove specification used in one or more projects otherwise the opening will be compromised.

## 1. Header

![Image](../Images/Spec2.jpg)

Properties :

- Units                         - Metric or USA
- Code                          - See [Codes](https://documentation.metapiping.com/Analysis/Codes.html) for more information
- Edition                       - See [Codes](https://documentation.metapiping.com/Analysis/Codes.html) for more information
- Max design temperature        - °C or °F
- Max design pressure           - N/mm² or psi
- Material library              - See [Materials](https://documentation.metapiping.com/Settings/Databases/Materials.html) for more information
- Piping library                - See [Piping](https://documentation.metapiping.com/Settings/Databases/Piping.html) for more information


> ATTENTION, a specification has UNITS, so only libraries of materials and piping elements with the same UNITS can be connected.

> ATTENTION, when starting a new project, be sure to select a specification that will be compatible with the Units, Code and Edition of the project and do not change these 3 properties during design.

## 2. Elements

To create a **specification**, just click to **+** button and select several pipe sizes :

![Image](../Images/Spec3.jpg)

MetaPiping fills automatically the tables and let you make some choices.

## 2.1 Pipes

For each size, define the **schedule** and the **material**. A **pipe** knows now its section and its material :

![Image](../Images/Spec4.jpg)

Select then the **node connections** of the pipe between :
- None
- Butt weld - flush
- Butt weld - as welded
- Fillet weld
- Full fillet weld
- Threaded
- Brazed

Based on this property, define the **mismatch** or the **fillet length** [mm or in].

Select then the **Long weld type** of the pipe between :
- None
- Butt weld flush
- Butt weld as welde

Based on this property, define the **Long weld mismatch** [mm or in].

Other properties :

| Property | Unit Metric | Unit USA | Default |
| -------- | ---- | ---- | -- |
| Linear mass + insulation | kg/m | lb/ft | Linear mass of the pipe |
| Insulation thickness | mm |in | 0 |
| External corrosion | mm | in | 0 |
| Internal erosion | mm | in | 0 |
| Bend thickness | mm | in | Thickness of the pipe |

## 2.2 Bends

MetaPiping automatically fills the table with the corresponding informations :

![Image](../Images/Spec5.jpg)

| Property | Unit Metric | Unit USA | 
| -------- | ---- | ---- | 
| Long radius | m | ft | 
| Small radius | m | ft |
| Mass | ton | kips | 

Just informative.

    To know the UNIT of a property, just let the mouse over the property name.

## 2.3 Reducers

MetaPiping automatically fills the table with the corresponding informations :

![Image](../Images/Spec6.jpg)

| Property | Unit Metric | Unit USA | Note |
| -------- | ---- | ---- | -- |
| Length | m | ft | |
| Mass | ton | kips | |
| Angle | ° | ° | Class 1 only|

    To know the UNIT of a property, just let the mouse over the property name.

## 2.4 Tees

MetaPiping automatically fills the table with the corresponding informations :

![Image](../Images/Spec7.jpg)

For each combination, you can define the type of tee :

- Branch connection
- WeldingTee
- Non Standard
- Fabricated
- Sweepolet flush weld
- Sweepolet as welded
- Weldolet
- Extruded weldingTee
- Welded-in contour insert
- Branch welded-on fitting
- Lateral connection
- Partial penetration branch connection

Based on the type, some other properties must be filled :

| Property | Description | Unit Metric | Unit USA |
| -------- | ---- | ---- | -- |
| L1 | Branch length | m | ft |
| R2 | Branch-to-run fillet radius | mm | in |
| TN | Branch connections and piping lateral connections CONSTANT thickness | mm | in |
| Y | Branch connections and piping lateral connections VARIABLE thickness | mm | in |
| Thickness type | Variable or constant | - | - |
| RE | Pad or saddle outer radius for reinforced fabricated tees  | mm | in |
| RX | Transition radius | mm | in |
| PD | Pad thickness for reinforced fabricated tees | mm | in |
| Collector length | Half length of the collector of welding tees | m | ft |
| Branch length | Branch length of welding tees | m | ft |
| Mass | Mass of the tee | ton | kips |

## 2.5 Flanges

MetaPiping automatically fills the table with the corresponding informations :

![Image](../Images/Spec8.jpg)

For each size, select the **Nominal pressure** (Rating) and select the predefined **type** of flange :

- Welding neck
- Slip-on
- Lap joint
- Threaded
- Socket welding
- Blind

The predefined properties will be shown.

| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- |
| Length | m | ft |
| Mass | ton | kips |
