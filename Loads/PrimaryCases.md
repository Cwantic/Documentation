---
layout: default
title: Primary floor response cases
nav_order: 4
parent: Loads
---

# Primary floor response cases

    This load describes the floor response spectra for each support level. This analysis is used to
    obtain bound solutions for simple multilevel cases (including single level cases) for which the
    dynamic loading is entirely due to movements at the support points.
    The "levels" are groups of support points which are moving in parallel and are entered using the
    level number field on support.

{: .warning }
>Attention, to obtain the complete solution for multilevel problems, it is necessary to calculate the primary and secondary parts of the solution separately and then to combine them.

MetaPiping will calculate the bounds for the **PRIMARY** part of the solution u(t) for displacements, rotations, forces, moments and stresses due to the dynamic support movement loading.

When selecting **Primary floor response cases** load type, all existing loads are listed in the combobox :

![Image](../Images/Load18.jpg)

The loads appear with the **Case number** + **Title**.

## 1. General

When editing, the definition window shows this screen :

![Image](../Images/Load19.jpg)

Enter a **Case number** and a **Title**.

<ins>Event</ins> :

Select a **Spectra** : *R.G. 1.60 - 2% Damping* in this example.

See §2.

<ins>Level</ins> :

Documentation will come soon…

<ins>Equation</ins> :

- 1- None
- 2- Eq. 9 (design)
- 3- Eq. 9 B (occasional)
- 4- Eq. 9 C (occasional)
- 5- Eq. 9 D (occasional)
- 6- Test
- 7- Eq. 12
- 8- Eq. 10 (partial)

Documentation will come soon…

<ins>Method</ins> :

For intermodal :

- 1- Grouping
- 2- Ten percent
- 3- Double sum
- 4- SRSS
- 5- All coupling
- 6- Rosenblueth
- 7- Der Kiureghian

For interlevel :

- 0- Absolute without phase
- 1- SRSS without phase
- 2- Algebraic
- 3- Absolute with phase
- 4- SRSS with phase
- 5- Envelope
- 6- SRSS with counterphase

For order :

- 0- Interlevel / Intermodal / Interspatial
- 1- Interlevel / Interspatial / Intermodal
- 2- Intermodal / Interlevel / Interspatial

Documentation will come soon…

<ins>Rigid correction</ins> :

- 0- SRSS
- 1- None
- 2- Absolute
- A- SRSS with modal
- B- Gupta
- C- Lindley-Yow

Documentation will come soon…

<ins>X, Y, Z multipliers</ins> :

This factor multiplies the X, Y, Z component of the loading.

 If this field is zero or blank, then all X, Y or Z loading components will be zero for this loading.

## 2. Spectra definition

In this example, we use this **Spectra loading** :

![Image](../Images/Load20.jpg)

It contains 2 **LEVELS** with corresponding spectra :

![Image](../Images/Load21.jpg)

Click [here](https://documentation.metapiping.com/Loads/Spectra.html) for more information about the spectra definition.

## 3. Restraint defintion

In this example, all restraints have a **LEVEL** affected :

![Image](../Images/Load17.jpg)

Level 1 for the main line.

Level 2 for the secondary line.

## 4. Secondary floor response cases

Click [here](https://documentation.metapiping.com/Loads/SecondaryCases.html) for more information about the secondary floor response cases.