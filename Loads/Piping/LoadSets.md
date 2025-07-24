---
layout: default
title: Load sets
nav_order: 10
parent: Piping
grand_parent: Loads
---

# Load sets (Class 1 only)

    A load set is a specific combination of load cases assumed to act simultaneously on a
    piping system at a given instant. Pairs of load sets are employed in pipe stress analysis
    to determine physical changes in the system from one load set instant to another.
    Typical load set parameters, which may occur in various combinations, are : pressure,
    temperature, moment and thermal transient effects.

When selecting **Load sets**, all existing load sets are listed in the combobox :

![Image](../../Images/Load30.jpg)

The load sets appear with their **Title**. There is no **Case number** for that kind of case.

## 1. General

When editing, the definition window shows up :

![Image](../../Images/Load31.jpg)

Enter a **Title**.

<ins>Allowable stress reference case</ins> :

The temperature of the reference case is used to determine the allowable stress intensity Sm.

<ins>Situation number</ins> :

For RCC-M Class 1 and RCC-MRx codes only : the two load sets, which form a situation, must be defined with the same situation number. Moreover, the two load sets must have the same number of cycles. The situation numbers are used to determine the maximum value of the penalty factor Ke for RCC-M code.

<ins>Transient case</ins> :

Thermal case associated with the load set.

<ins>Cool-down transient</ins> :

Check the box if the final temperature of the transient is lower than the initial temperature. This information is not necessary when **True transient range** is checked in the **Model options**.

<ins>Number of cycles</ins> :

Number of expected occurrences.

<ins>Pressure case</ins> :

The pressure associated with the load set is taken from the pressure case.

**ASME and RCC-M codes** : if the moment case for this load set is a dynamic case, then moments used in evaluating equation 12 will be the moments for the pressure case multiplied by Ec/Eh.

**RCC-MRx** : the pressure case and allowable stress reference case must be equal. Moreover, MetaPiping assumes that the pressure case also corresponds to the sole thermal expansion moments (noted ‘m’ in the code). It shall be noted that, for programming reasons, there must be at least another load set which the moment case is equal to this pressure case.

<ins>Moment case</ins> :

The moments associated with the load set are taken from the moment case.

<ins>Dynamic load flag</ins> :

**ASME code** : if the moment case for this load set is a dynamic case, then the moments used in the evaluation of equation 13  are taken from the combination case with the same flag number.
**RCC-MRx** : if the moment case for this load set is a dynamic case, then the primary dynamic moments are taken from the combination case with the same flag number and type of analysis 1. The secondary dynamic moments are taken from the combination case with the same flag number and type of analysis 6.

The dynamic flag is not used for the RCC-M code.