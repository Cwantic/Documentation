---
layout: default
title: Matrix
nav_order: 14
parent: Elements
grand_parent: Piping
---

# Create matrix

A **matrix** is a virtual element with a user oriented stiffness matrix.

When you click on the **Add matrix** button without selection, the left panel shows a message :

    Select 1 node

![Image](../../Images/Matrix1.jpg)

The **selection mode** is automatically set to **POINT**. You can so directly select a node.

## 1. Create a matrix

- Select a **node**.
- Click the **Add matrix** button.

![Image](../../Images/Matrix2.jpg)

**MATRIX PROPERTIES** :

| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- |
| Length | m | ft |
| Mass | ton | kips |

**MATRIX VALUES** :

| Metric |  |  |  |  |  |
| --- | --- | --- | --- | --- | --- |
| <font color="green">kN/mm</font> |  |  |  |  |  |
| <font color="green">kN/mm</font> | <font color="green">kN/mm</font> |  |  |  |  |
| <font color="green">kN/mm</font> | <font color="green">kN/mm</font> | <font color="green">kN/mm</font> |  |  |  |
| <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | kN.m/rad |  |  |
| <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | kN.m/rad | kN.m/rad |  |
| <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | <font color="red">kN.m/mm</font> | kN.m/rad | kN.m/rad | kN.m/rad |

| USA |  |  |  |  |  |
| --- | --- | --- | --- | --- | --- |
| <font color="green">kips/in</font> |  |  |  |  |  |
| <font color="green">kips/in</font> | <font color="green">kips/in</font> |  |  |  |  |
| <font color="green">kips/in</font> | <font color="green">kips/in</font> | <font color="green">kips/in</font> |  |  |  |
| <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | ft.kips/rad |  |  |
| <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | ft.kips/rad | ft.kips/rad |  |
| <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | <font color="red">ft.kips/in</font> | ft.kips/rad | ft.kips/rad | ft.kips/rad |

{: .warning }
>ATTENTION : a warning will be raised if the matrix is not invertible but without blocking !

>To know the UNIT of a property, just let the mouse over the cell.

>The length must be defined by the **orientation tool**.

**MATERIAL** :

Select the material of the matrix element.

Click [here](https://documentation.metapiping.com/Design/Specification/Data.html#11-material-definition) for more information about the materials definition.

**X-AXIS and Z-AXIS DIRECTION** :

You can define the **X-axis** and **Z-axis** vectors by defining Xx, Xy, Xz and Zx, Zy, Zz in global coordinates.

>The directions can be different than the orientation of the element.

**LABEL** :

You can define a label to this element. The labels are shown with the node names view button.

![Image](../../Images/Label1.jpg)

**NEXT NODE** :

You can set the next extremity node name of the element. If blank, the software will define it automatically. The software will also check that the name doesn't already exist.

---

You can then define the second point of the matrix thanks to the **Orientation tool**.

Click [here](https://documentation.metapiping.com/Design/Elements/Orientation.html) for more information about the orientation tool.

Create the matrix element (represented by a black line) :

![Image](../../Images/Matrix3.jpg)

## 2. Modify/Remove a matrix

Change the **Selection mode** to ELEMENT and select a matrix element by dragging a selection rectangle :

![Image](../../Images/Rigid5.jpg)

Click [here](https://documentation.metapiping.com/Design/Selection.html) for more information about the selection tool.

You can change the properties of the selected matrix (except the length).

Click on the **Modify** button to change the selected matrix with new properties.

You can **undo** this command.

Click on the **Remove** button to delete the selected matrix.

You can **undo** this command.

## 3. Insert a matrix on an intermediate node

Click on the **Add matrix** button and select an **intermediate node** between 2 elements.

![Image](../../Images/Matrix4.jpg)

Fill the properties (see §1) and select the **insertion mode** :

- Shift forward
- Shift backwards
- Reduce the next element
- Reduce the previous element
- Symmetrically reduce the neighboring elements

{: .warning }
>ATTENTION, if the length is null, no mode will be proposed (empty list)

{: .warning }
>Based on the length of the matrix element and the lengths of the neighboring elements, some mode could be hidden.

Select for example "Reduce the next element" and click the **Insert** button :

![Image](../../Images/Matrix5.jpg)

You can **undo** this command.