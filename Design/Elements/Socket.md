---
layout: default
title: Socket
nav_order: 11
parent: Elements
grand_parent: Design
---

# Create sockets

When you click on the **Add socket** button without selection, the left panel shows a message :

    Select 1 node

![Image](../../Images/Socket1.jpg)

The **selection mode** is automatically set to **POINT**. You can so directly select a node.

## 1. Create a socket

- Select the current **section/material** in the specification box.
- Select a **node**.
- Click the **Add socket** button.

![Image](../../Images/Socket2.jpg)

**SOCKET PROPERTIES** :


| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- |
| Length | m | ft |
| Mass | ton | kips |
| Thickness factor | - | - |

>The length must be defined by the **orientation tool**.

**X-AXIS DIRECTION** :

You can define the **X-axis** vector by defining Xx, Xy, Xz in global coordinates.

**DATABASE** :

To save time, you can also directly select a socket from **database** :

![Image](../../Images/Socket4.jpg)

Click on the **Database** button, select a **Library** and a **Socket**. The **OK** button will appear.

The tables will be filled automatically.

Click [here](https://documentation.metapiping.com/Settings/Databases/Components.html) for more information about creation of library of components.

---

You can then define the second point of the socket thanks to the **Orientation tool**.

Click [here](https://documentation.metapiping.com/Design/Elements/Orientation.html) for more information about the orientation tool.

Create the socket :

![Image](../../Images/Socket3.jpg)

## 2. Modify/Remove a socket

Change the **Selection mode** to ELEMENT and select a socket :

![Image](../../Images/Socket5.jpg)

You can change the properties of the selected socket (except the length).

**SECTION AND MATERIAL** :

You can change the **specification** and **section/material** of the socket.

Click on the **Modify** button to change the selected spring with these new properties.

You can **undo** this command.

Click on the **Remove** button to delete the selected spring.

You can **undo** this command.

## 3. Insert a socket on an intermediate node

Click on the **Add socket** button and select an **intermediate node** between 2 elements.

![Image](../../Images/Socket6.jpg)

Fill the properties (see §1) and select the **insertion mode** :

- Shift forward
- Shift backwards
- Reduce the next element
- Reduce the previous element
- Symmetrically reduce the neighboring elements

{: .warning }
>ATTENTION, if the length is null, no mode will be proposed (empty list)

{: .warning }
>Based on the length of the socket and the lengths of the neighboring elements, some mode could be hidden.

Select for example "Shift forward" and click the **Insert** button :

![Image](../../Images/Socket7.jpg)

You can **undo** this command.