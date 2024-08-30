---
layout: default
title: Solvers
nav_order: 4
parent: Analysis
---

# Solvers

MetaPiping comes with its built-in solver based on the finite element program Code_Aster from EDF. It can also connect to previously installed PIPESTRESS program.

## 1. Code_Aster (piping & structure)

    Code_Aster offers a full range of multiphysical analysis and modeling methods that go well beyond the 
    standard functions of a thermomechanical calculation code: from seismic analysis to porous media via 
    acoustics, fatigue, stochastic dynamics, etc.

The following features are currently implemented in Code_Aster based solver :

-	complex geometries made of straight pipes, elbows, miter bends, tees, reducers, valves, rigids, expansion joints, flanges, structual elements, socket welded fittings, beams, matrices and springs, lumped masses
-	supports : anchors, translational and rotational restraints, multiple restraints, snubbers, variable and constant spring hangers
-	static loads : dead weight, thermal expansion, anchor movements, nodal forces and moments, distributed forces, wind and snow, static acceleration, cold springing, variable fluid density and stratification
-	load combinations
-	automatic mass point generation
-	modal extraction
-	time history analysis with applied forces and moments
-	floor response spectrum analysis

Supported codes :

- EN 13480-3 Editions 2017 and 2020 with Table H.3 (bidirectionnal SIFs)
- RCC-M Class 1 & 2 Editions 2002, 2007, 2012, 2016, 2017, 2018, 2020
- ASME Section III Class 1, 2 & 3 Editions 2004 + A06, 2007, 2010, 2013, 2015, 2017, 2019, 2021
- ANSI/ASME B31.1 Editions 1998, 2004, 2007, 2010, 2012, 2014, 2016, 2018, 2020 (with B31J SIFs)


## 2. PIPESTRESS (piping)

>ONLY FOR USERS WITH A VALID PIPESTRESS LICENCE

    PIPESTRESS is a pipe stress analysis software developed by DST Computer Services.

Supported codes :

- ASME Section III Classes 1, 2 and 3 (1967 to 2021)
- ANSI/ASME B31.1 (1972 to 2020)
- ANSI/ASME B31.3 (1999 to 2018)
- CODETI (1982 to 2016)
- RCC-M Classes 1 and 2 (1983 to 2020)
- RCC-MX (2008)
- KTA Classes 1 and 2 (1980 to 1992)
- EDF Piping Code for Composite Materials, Indice D
- EN 13480-3 Piping Code (2002 to 2017 - A4:2021)
- ASME HDPE Piping Code (2011 to 2017) includes Code Case N-7555 and Section III Appendix XXVI
