---
layout: default
title: Adjacent nodes
nav_order: 6
parent: Elements
grand_parent: Structure
---

# Adjacent nodes

![Image](../../Images/Structure14.jpg)

This tool is usefull to construct *structure* nodes around *piping* nodes.

Imagine a small piping system with a **restraint** on a node :

![Image](../../Images/Adjacent1.jpg)

We want to build a **support** at this node.

## 1. Piping

Create a **piping** study and draw the model :

![Image](../../Images/Adjacent2.jpg)

## 2. Support

Create a **structure** study and add a **link** to *PipingStudy* :

![Image](../../Images/Adjacent3.jpg)

Set the calculation code, add materials and beams.

## 3. Structure nodes

![Image](../../Images/Structure14.jpg)

When you click on the **Add adjacent nodes** button without selection, the left panel shows a message :

![Image](../../Images/Adjacent4.jpg)

The **selection mode** is automatically set to **POINT**. You can so directly select a node.

Select a piping node with a restraint :

![Image](../../Images/Adjacent5.jpg)

MetaStructure proposes to create up to 4 nodes perpendicular to the pipe direction.

Checkboxes let you select the desired nodes.

The left panel shows the pipe ray at the selected node and for the 4 directions, the distance of the new nodes.

The default value (0.07 in this example) corresponds to half the height of the current beam (IPE 140) :

![Image](../../Images/Adjacent6.jpg)

| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- |
| Distance | m | ft |

Select only the bottom node and click on the **Create** button :

![Image](../../Images/Adjacent7.jpg)

The **structure** node 1 is created :

![Image](../../Images/Adjacent8.jpg)

>The piping nodes are numbered in blue

When you later draw beams on this new node, you will see that the profile is perfectly adjacent to the pipe :

![Image](../../Images/Adjacent9.jpg)
