---
layout: default
title: Supervisor
nav_order: 3
parent: Explorer
---

# Supervisor

![Image](../Images/Supervisor1.png)

Click on **Supervisor** button to access the batch tool.

## Batch calculation

MetaPiping let you calculate projects in batch mode.

1. Select piping or structure studies from all projects

![Image](../Images/Supervisor2.png)

2. Select a solver

![Image](../Images/Supervisor3.png)

* Auto          : use the study's specified solver
* Aster         : use Code_Aster solver (even if PIPESTRESS solver is specified in the study)
* PipeStress    : use PIPESTRESS solver (even if Aster solver is specified in the study) - only for piping studies

3. Calculation

![Image](../Images/Supervisor4.png)

Depending on the solver selected, a progress window will appear for each study.

The **supervisor** will calculate the solution of all studies and place the result files in the studies' directories.
