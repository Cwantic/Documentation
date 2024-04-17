---
layout: default
title: Rigid
nav_order: 8
parent: Elements
grand_parent: Piping
---

# Create rigids

    A rigid is a straight element sufficiently stiff to rigidly transmit all deflections and rotations.

When you click on the **Add rigid** button without selection, the left panel shows a message :

    Select 1 node

![Image](../../Images/Rigid1.jpg)

The **selection mode** is automatically set to **POINT**. You can so directly select a node.

## 1. Create a rigid

- Select a **node**.
- Click the **Add rigid** button.

![Image](../../Images/Rigid2.jpg)

**RIGID PROPERTIES** :

| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- |
| Length | m | ft |
| Mass | ton | kips |

>The length must be defined by the **orientation tool**.

**X-AXIS DIRECTION** :

You can define the **X-axis** vector by defining Xx, Xy, Xz in global coordinates.

---

You can then define the second point of the rigid thanks to the **Orientation tool**.

Click [here](https://documentation.metapiping.com/Design/Elements/Orientation.html) for more information about the orientation tool.

Create the rigid (represented by a black line) :

![Image](../../Images/Rigid3.jpg)

## 2. Modify/Remove a rigid

Change the **Selection mode** to ELEMENT and select a rigid by dragging a selection rectangle :

![Image](../../Images/Rigid5.jpg)

Click [here](https://documentation.metapiping.com/Design/Selection.html) for more information about the selection tool.

You can change the properties of the selected rigid (except the length).

![Image](../../Images/Rigid4.jpg)

**X-AXIS DIRECTION** :

You can change the **X-axis** vector by defining Xx, Xy, Xz in global coordinates.

Click on the **Modify** button to change the selected rigid with these new properties.

You can **undo** this command.

Click on the **Remove** button to delete the selected rigid.

You can **undo** this command.


