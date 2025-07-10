---
layout: default
title: Selection
nav_order: 6
parent: Piping
---

# Selection

MetaPiping lets you select one or multiple objects of the same type.

Click on the **Select** button to open the **Selection tool** :

![Image](../Images/Selection1.png)

Or press directly :

- **F10** for point selection
- **F11** for element/beam selection
- **F12** for restraint selection

## 1. Manual selection

**POINT** :

Click on the **Point** button (or **F10**) to select **Nodes** or **element extremities**.

![Image](../Images/Selection2.jpg)

The node is highlighted and its **Name** appears in magenta.

You can also select a node by entering the node name (1) and click to the **Point** button.

**ELEMENT** :

Click on the **Element** button (or **F11**) to select an **element**.

![Image](../Images/Selection3.jpg)

The element is highlighted in magenta.

You can also select an element by entering the two node names separate by "-" (1) and click to the **Element** button.

You can also select an element by entering its label (1) and click to the **Element** button.

**RESTRAINT** :

Click on the **Restraint** button (or **F12**) to select a **restraint**.

![Image](../Images/Selection4.jpg)

The restraint is highlighted in magenta.

You can also select a restraint by entering the node name or its label (1) and click to the **Restraint** button.

**TEE** :

Click on the **Tee** button to select a **tee**.

![Image](../Images/Selection5.jpg)

The node containing the tee is highlighted and its **Name** appears in magenta.

**CLEAR SELECTION** :

Clicking in the 3D view where no objects are present without **CTRL key** pressed will clear the selection.
  
**CANCEL SELECTION** :

Just press **ESC** on keyboard to hide the **selection tool**.

## 2. Selection type

**MOUSE CLICK** :

To select **ONE** object, just make a click with the **left mouse button** :

![Image](../Images/MouseLeft.jpg)

**RECTANGLE SELECTION** :

It is also possible to make a rectangular selection :

![Image](../Images/Selection6.jpg)

1. Press the **left mouse button**
2. Move the mouse without releasing the left mouse button
3. Release the left mouse button

Every object that intersects the **rectangle** will be selected (in magenta).

**MULTIPLE SELECTION** :

You can make multiple selection by pressing the **CTRL** key on keyboard.

**MULTIPLE SELECTION BY CONNECTION** :

You can make continuous selection by pressing the **SHIFT** key on keyboard and 2 distant **elements**.

1. Select a first element :

![Image](../Images/Selection7.jpg)

2. Press **SHIFT**

3. Select a second element :

![Image](../Images/Selection8.jpg)

Every object between the 2 elements will be selected (in magenta).