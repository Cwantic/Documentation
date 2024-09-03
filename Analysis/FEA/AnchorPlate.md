---
layout: default
title: Anchor plate
nav_order: 1
parent: Finite Element Analysis
---

# Anchor Plate Analysis

MetaStructure proposes a detailed analysis of anchor plate and its fasteners.

![Image](../../Images/FEA6.jpg)

Click [here](https://documentation.metapiping.com/Structure/Elements/Restraint.html#2-anchor-plate) for more information about the anchor plate definition.

## 1. Structure analysis

After structure analysis, the anchor plates of the structure can be examined.

![Image](../../Images/FEA2.jpg)

* Select a load case or mode (1).
* Select the **anchor plate** button (2).
* Select either an anchor plate in the 3D space or in the results table (3).
* Click on the **Analysis** button (4).

The **selection mode** is automatically set to **Restraint** when clicking on **anchor plate** button.

If other analysis exists for the same **Restraint** and the same **Load**, a window will appear :

![Image](../../Images/FEA3.jpg)

* Select **New analysis** to start a new analysis from scratch.
* Or select an existing analysis to reopen it :

![Image](../../Images/FEA4.jpg)

Some properties and results are shown.

Click OK.

## 2. New analysis

If you choose to create a **New analysis**, you have to define a name to the analysis (that doesn't already exist) :

![Image](../../Images/FEA5.jpg)

The **Finite Element Analysis Window** appears :

MetaStructure automatically transforms the actual plate, anchor positions, stiffeners and a part of the beam to surfacing elements (on neutral fiber).

These surfaces are grouping by types, thicknesses and materials :

![Image](../../Images/FEA7.jpg)

The window is divided into 3 areas :

* A : Definition of the assembly, mesh, results and report
* B : Model 3D
* C : Groups of elements with same properties (type, thickness, material)

The first area contains 4 properties :

![Image](../../Images/FEA8.jpg)

* A1 : The node of the anchor plate (restraint) and the current load
* A2 : The configuration
* A3 : The total height of the assembly. Click on **v** button to modify.
* A4 : The desired mesh size. Click on **v** button to **generate the meshing**.

> If the **anchor plate** has a non-zero value for the **Tolerance** property of its fasteners, 2 other configurations will be added in the list representing extreme positions of fasteners.

![Image](../../Images/FEA9.jpg)

Click [here](https://documentation.metapiping.com/Structure/Elements/Restraint.html#22-fastener-definition) for more information about the fastener definition.

## 3. Meshing

Choose a **mesh size** and click on **v** button (1) :

![Image](../../Images/FEA10.jpg)

After several seconds, the assembly is totally meshed (2).

All groups appears on the right (3). You can show/hide each group for a better visualization.

The **Code_Aster** button is now available for a complete calculation.

## 4. Finite element analysis

Click on the **Code_Aster** button to launch a detailed calculation (1) :

![Image](../../Images/FEA11.jpg)

Colored results appears (2) with a corresponding legend.

A result panel appears where the type of results can be choose and some informations are shown (3).

You can show/hide each group for a better visualization (4).

Type of results :

| Property | Unit Metric | Unit USA | Remark |
| -------- | ---- | ---- | ---- |
| Groups | - | - | |
| Displacements | mm | in | Use **Factor** to amplify the deformation |
| Stresses | N/mm² | ksi | |
| Strains | % | % | |
| Compressions | N/mm² | ksi | |
| Iso-displacements | mm | in | Use **Factor** to amplify the deformation |
| Iso-stresses | N/mm² | ksi | |
| Iso-Strains | % | % | |
| Iso-Compressions | N/mm² | ksi | |

Example of the deformation of the plate (with factor = 128) :

![Image](../../Images/FEA20.jpg)

Change for example the type to **Stresses** :

![Image](../../Images/FEA12.jpg)

![Image](../../Images/FEA13.jpg)

The **Static equilibrium** is also evaluated (value near 0 reaches the perfect equilibrium).

    Static Equilibrium refers to the physical state in which a system is at rest and the net force acting 
    on it is null. It is a state in which all the forces acting on an object are balanced out and the 
    object is not found to be in motion to the relative plane.

The **Fastener ratio max** indicates the max value of all ratios of all fasteners of the plate (must be < 1).

Click on the **Open** button to show a summary report of the **fasteners'** results :

![Image](../../Images/FEA14.jpg)

Each fastener is deeply examined according to the current **standard**.

## 5. Report

A report can be generated based on a template and "*tables*" file.

![Image](../../Images/FEA16.jpg)

* Select a template (**open** button) or edit template (**pencil** button) (1).
* Select a *tables* file (**open** button) (2).
* Click on the **Report** button to generate the report (3).

> The template is copy from the settings to the analysis' directory and can be locally modified before report generation (requires Microsoft Word).

The **select document window** (example for table) :

![Image](../../Images/FEA15.jpg)

* Select the document (1)
* Click OK (2)

After generation, the report receive the name of the analysis. 

You can **edit** the final report by clicking on the **pencil** button (requires Microsoft Word) (1) :

![Image](../../Images/FEA17.jpg)

![Image](../../Images/FEA18.jpg)

Click [here](https://documentation.metapiping.com/Settings/Reporting.html) to have more information about the reporting mechanism.

### 5.1 Keywords

The keyword is useful to make a correspondence between the **template** and the **table** document but with specific decorators :

    $$keyword$$ for the template
    [keyword] for the table


| Keyword | Description | Remark |
| -------- | ---- | ---- |
| STUDY NAME | The name of the current study | No table |
| ANALYSIS NAME | The name of the current analysis | No table |
| PICTURE | Take a picture (§5.2) | No table |
| MESH RESULTS | The list of all mesh results | table [MESH RESULTS] |
| CONFIGURATION NAME | The name of the current configuration | No table |
| HEIGHT | The height of the current assembly | No table |
| MESH SIZE | The meshing size | No table |
| IDNODE | The name of the current node | No table |
| LOADCASE | The current load case | No table |
| STATIC EQUILIBRIUM | The static equilibrium value | No table |
| DISPLACEMENT MAX | The displacement max | No table |
| STRESS MAX | The stress max | No table |
| STRAIN MAX | The strain max | No table |
| FASTENER RATIO MAX | The max ratio on all fasteners | No table |

### 5.2 Picture

It is possible to include pictures in the report with use of the keyword **PICTURE**.

When the software encounters this keyword, it simply makes a screenshot of the 3D engine.

It is possible to change the kind of visualization via a **JSON structure** just after the keyword separated by a semicolon character :

    $$PICTURE;{...}$$

JSON parameters :

| Parameter | Description | Default value |
| -------- | ---- | ---- |
| Groups | An array of visible group name | Empty list = all groups will be visible |
| View | Orientation of the camera | 35 (= FrontFaceTopLeft - see below) |
| ResultType | Result category | 0 (= Group - see below) |
| Factor | Amplification factor of the displacements | 1 |
| Dim | 1 = show dimensions | 1 |

View values :

        Front                   = 0
        Right                   = 1
        Rear                    = 2
        Left                    = 3
        Top                     = 4
        Bottom                  = 5
        Isometric               = 6
        Dimetric                = 7
        Trimetric               = 8
        FrontFaceBottom         = 9
        FrontFaceRight          = 10
        FrontFaceTop            = 11
        FrontFaceLeft           = 12
        RightFaceBottom         = 13
        RightFaceRight          = 14
        RightFaceTop            = 15
        RightFaceLeft           = 16
        BackFaceBottom          = 17
        BackFaceRight           = 18
        BackFaceTop             = 19
        BackFaceLeft            = 20
        LeftFaceBottom          = 21
        LeftFaceRight           = 22
        LeftFaceTop             = 23
        LeftFaceLeft            = 24
        BottomFaceBottom        = 25
        BottomFaceRight         = 26
        BottomFaceTop           = 27
        BottomFaceLeft          = 28
        TopFaceBottom           = 29
        TopFaceRight            = 30
        TopFaceTop              = 31
        TopFaceLeft             = 32
        FrontFaceBottomLeft     = 33
        FrontFaceBottomRight    = 34
        FrontFaceTopLeft        = 35
        FrontFaceTopRight       = 36
        BackFaceBottomLeft      = 37
        BackFaceBottomRight     = 38
        BackFaceTopLeft         = 39
        BackFaceTopRight        = 40

Result type values :

        Group = 0
        Displacement = 1
        Stress = 2
        Strain = 3
        Compression = 4
        IsoDisplacement = 5
        IsoStress = 6
        IsoStrain = 7
        IsoCompression = 8

Example :

```
    $$PICTURE;{“ResultType”:8,”Groups”:[“PLATE”],”View”:4,”Dim”:0}$$
```

>ResultType = 8 for an "Iso-compression" view

>Groups = ["PLATE"] will show only the group plate

>View = 4 for a top view

>Dim = 0 will hide the dimensions

Result :

![Image](../../Images/FEA21.jpg)

## 6. Conclusion

The analysis is terminated.

You can keep this analysis on disk by closing the window and answer **Yes** to the question :

![Image](../../Images/FEA19.jpg)

This analysis will be proposed on the window of §1 for the same anchor plate (node) and load.