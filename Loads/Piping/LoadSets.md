---
layout: default
title: Load sets
nav_order: 9
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

![Image](../Images/Load30.jpg)

The load sets appear with their **Title**. There is no **Case number** for that kind of case.

## 1. General

When editing, the definition window shows up :

![Image](../Images/Load31.jpg)

Enter a **Title**.

<ins>Allowable stress reference case number</ins> :

The temperature of the reference case is used to determine the allowable stress intensity Sm.

<ins>Situation number</ins> :

For RCC-M Class 1 code only : the two load sets, which form a situation, must be defined with the same situation number. Moreover, the two load sets must have the same number of cycles. The situations are used to determine the maximum value of the penalty factor Ke.

<ins>Transient case number</ins> :

Number of the thermal case associated with the load set.

    Use positive (+) sign for heat up transients
    Use negative (-) sign for cool down transients

<ins>Number of cycles</ins> :

Number of expected occurences.

<ins>Pressure case number</ins> :

The pressure associated with the load set is taken from the pressure case.

If the moment case for this load set is a dynamic case, then moments used in evaluating equation 12 will be the moments for the pressure case multiplied by Ec/Eh.

<ins>Moment case number</ins> :

The moments associated with the load set are taken from the moment case.

<ins>Dynamic load flag</ins> :

For ASME Class 1 only : if the moment case for this load set is a dynamic case, then the moments used in the evaluation of equation 13  are taken from the combination case with the same flag number.
