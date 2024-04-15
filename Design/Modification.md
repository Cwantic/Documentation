---
layout: default
title: Modification
nav_order: 5
parent: Design
---

# Modification

![Image](../Images/Modification1.jpg)

## 1. Selection

Click on **Select** button to open the selection window :

![Image](../Images/Selection.jpg)

- Click on **Point** to select nodes
- Click on **Element** to select piping elements (pipe, bend, reducer, valve, etc.)
- Click on **Restraint** to select restraints
- Click **Tee** to select nodes where a tee has been assigned
- Press **ESC** on keyboard to hide the selection window

You can now select objects of appropriate type.

    The selection is done by pressing the left mouse button above the desired object

Click [here](https://documentation.metapiping.com/Design/Selection.html) to have more information about the selection.

## 2. Remove elements

Select elements and click the **Remove elements** button to delete these elements.

You can **Undo** this command.

## 3. Cut element

It is possible to cut **pipe** in two parts.

Select one pipe and click to the **Cut element** button :

![Image](../Images/Modification2.jpg)

The length of the pipe is shown on the right.

By default, a distance from the first node of the pipe is calculated, which is the half length of the selected pipe (middle point).

You can change the value. Click on **Cut** to execute the command.

    To know the UNIT of the value, just let the mouse over the cell. 

You can **Undo** this command.

## 4. Merge elements

Select a **Node** between 2 similar colinear pipes and click the **Merge** button.

The 2 pipes must have the same **Material** and the same **Section**.

The 2 pipes will be replaced by one pipe.

{: .warning }
>Attention, the force, restraint, lumped mass or local coordinates defined on the node will be destroyed.

You can **Undo** this command.

## 5. Node SIF

MetaPiping lets you define **Stress Intensification Factors** and **Stress Indices** on nodes.

Each **piping code** has its own factors.

| Code | SIFS | 
| -------- | ----------- | 
| ASME Class 1 | B1, C1, K1, B2, C2, K2, C3, C3', K3 |
| ASME Class 2 | i, B1, B2, B2', C2 |
| B31.1 | i |
| B31.1 B31.J | ii, io, it, ia, Ii, Io, It, Ia |
| EN 13480 | io, ii |
| RCCM Class 2 | i |

These factors are unitless.

Select a node and click on the **Node SIF** button.

- You can change one (or more) factor(s) at the extremity of the first element connected to the node, e.g. in RCC-M Class 2 code :

![Image](../Images/Modification3.jpg)

- You can change one (or more) factor(s) at the **extremity** of the second element connected to the node :

![Image](../Images/Modification4.jpg)

- You can change one (or more) factor(s) of all elements :

![Image](../Images/Modification5.jpg)

Click on **Create** button to apply the SIFs to the model.

You can later modify or remove the SIFs by selecting the node and clicking on **Modify/Remove** buttons.

You can **Undo** this command.

## 6. Body SIF

MetaPiping lets you define **Stress Intensification Factors** and **Stress Indices** on elements.

Select an element and click on the **Body SIF** button :

![Image](../Images/Modification6.jpg)

Click on **Create** button to apply the SIFs to the model.

You can later modify or remove the SIFs by selecting the element and clicking on **Modify/Remove** buttons.

You can **Undo** this command.

## 7. Stress On/Off

MetaPiping lets you deactivate the stress report of a portion of the piping system.

Select multiple elements and click on the **Stress On/Off** button :

![Image](../Images/Modification7.jpg)

Click on the checkbox and the **Modify** button to deactivate the stress reporting of these elements.

You can later modify this property by selecting the elements and activating or deactivating the checkbox.

You can **Undo** this command.