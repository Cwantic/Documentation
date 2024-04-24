---
layout: default
title: Graphical ending
nav_order: 2
parent: Beam
grand_parent: Elements
---

# Graphical ending

MetaStructure proposes several ending for each extremity of a beam :

| Type | Description |
| -------- | ----------- |
| None | Ending plane = perpendicular plane to the current beam through the node |
| Front | Ending plane = nearest plane encountered of the specified beam |
| Back | Ending plane = furthest plane encountered of the specified beam |
| Miter | Ending plane = bisector plane between current beam and specified beam |
| Plate | Ending plane = plane of the anchor plate |

## 1. Definition

![Image](../../../Images/End12.jpg)

The direction of a selected beam is represented by a **white arrow** (Node1 to Node2).

All beams (not // to current one) of each extremities are numbered.

At extremity 1 (Node1), the numbers are drawn inside a **black** square.

At extremity 2 (Node2), the numbers are drawn inside a **white** square.

You can specify the beam with wich you want a particular ending.

The **Offset** add (or subtract if negative value) an offset distance to the ending plane (// to the plane).

| Property | Unit Metric | Unit USA |
| -------- | ---- | ---- | 
| Offset | mm | in |

{: .warning }
>ATTENTION, this endings are only graphical and have no impact to the calculation. It helps for visualization and for the calculation of plate dimensions. In fact the beams do intersect at the node :

![Image](../../../Images/End10.jpg)

### 1.1 None ending

Ending plane = perpendicular plane to the current beam through the node :

![Image](../../../Images/End1.jpg)

### 1.2 Front ending

Ending plane = nearest plane encountered of the specified beam :

![Image](../../../Images/End2.jpg)

### 1.3 Back ending

Ending plane = furthest plane encountered of the specified beam :

![Image](../../../Images/End3.jpg)

### 1.4 Miter ending

Ending plane = bisector plane between current beam and specified beam :

![Image](../../../Images/End4.jpg)

### 1.5 Plate ending

Ending plane = plane of the anchor plate.

An **anchor plate** must exists at the extremity node.

See §2. for an example of plate ending.

## 2. Examples

In this example, the selected beam has on its first extremity (black column) a **front** ending on beam 2 :

![Image](../../../Images/End5.jpg)

In this example, the selected beam has on its first extremity (black column) a **miter** ending with beam 2 :

![Image](../../../Images/End7.jpg)

In this example, the selected beam has on its first extremity (black column) a **plate** ending and on its second extremity (white column) a **miter** ending with beam 2 :

![Image](../../../Images/End6.jpg)

In this example, the selected beam has on its first extremity (black column) a **front** ending on beam 3 with an offset of 116 mm :

![Image](../../../Images/End9.jpg)

The **offset** corresponds to the distance from the first face encoutered to the web = (240 - 7.5) / 2  = +/- 116 mm :

![Image](../../../Images/End8.jpg)

Click [here](https://documentation.metapiping.com/Structure/Elements/Beam/index.html) to return to **beam** page.