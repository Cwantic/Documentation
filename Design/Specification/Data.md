---
layout: default
title: Data
nav_order: 1
parent: Specification
grand_parent: Piping
---

# Data

The **Data** window let you create all materials and all piping sections of the model.

It let you also select one or more predefined **specifications**.
## 1. New project

When starting a new modelisation, the **Data** window opens :

![Image](../../Images/Design17.jpg)

### 1.1 Material definition

Let's define a new material.

Click on the **+** button and give a name to the new material (Ex : My material).

![Image](../../Images/Design22.jpg)

A new name has been created for this material (Ex : 100).

Click the **-** button (next to Name) to remove it.

Define the description, the type, the temperature max, the density and the Poisson's ratio.

Click the **+** button (next to Properties) to add a new row of properties for a **specific temperature** or click the **-** button (end of row) to remove one.

| Property | Description | Unit Metric | Unit USA |
| -------- | ----------- | ---- | ---- |
| Max. temperature | Temperature max | °C | °F |
| Density | Density | kg/m³ | lb/ft³ |
| Poisson | Poisson's ratio | - | - |
| EH | Modulus of Elasticity | kN/mm² | 10^6.psi |
| EX | Thermal Expansion | 10^-6.mm/mm/°C | 10^-6.in/in/°F |
| SH | Non-Class 1 Allowable Stress | N/mm² | ksi |
| SY | Yield Stress | N/mm² | ksi |
| SU | Ultimate Tensile Stress | N/mm² | ksi |
| SM | Class 1 Allowable Stress | N/mm² | ksi |
| CR | Creep | N/mm² | ksi |
| GH | Shear Modulus | kN/mm² | 10^6.psi |
| CO | Class 1 Thermal Conductivity | kJ/hr/m/°C | btu/hr/ft/°F |
| DI | Class 1 Thermal Diffusivity | mm²/s | ft²/hr |

See [Units](https://documentation.metapiping.com/Design/units.html) for more informations.

{: .warning }
>ATTENTION, temperatures must be entered in ascending order!

---

To save time, you can also directly select a material from **database** :

![Image](../../Images/Design23.jpg)

Click on the **Database** button, select a **Library** and a **Material**. The tables will be filled automatically :

![Image](../../Images/Design24.jpg)

Click [here](https://documentation.metapiping.com/Settings/Databases/Materials.html) for more information about creation of library of materials.

### 1.2 Piping definition

![Image](../../Images/Design25.jpg)

To add new pipe sizes, click on **+** button (1) and give it a name (Ex : 4").

Each size exists in different schedules. click on **+** button to add schedules :

| Property | Unit Metric | Unit USA | 
| -------- | ---- | ---- | 
| Schedule | - | - | 
| Outside diameter | mm | in |
| Thickness | mm | in | 
| Linear mass | kg/m | lb/ft | 

    To know the UNIT of a property, just let the mouse over the property name. 
    For example : mm for the Outside diameter

![Image](../../Images/Piping2.jpg)

{: .warning }
>ATTENTION, the name of the pipe size is very important (Ex : 4"). It will be used as a **reference** for all other piping elements. The american notation is used even in metric definition.

{: .warning }
>ATTENTION, the sizes must be defined in an **ascending** order.

To add **bend** properties for each pipe sizes, click on **+** button and select a pipe size :

![Image](../../Images/Piping3.jpg)

Standard radius and mass can be entered :

| Property | Unit Metric | Unit USA | 
| -------- | ---- | ---- | 
| Long radius | m | ft | 
| Small radius | m | ft |
| Mass | ton | kips | 

{: .warning }
>ATTENTION, for a better readability, we recommend to enter the sizes in **ascending** order. 

To add **reducer** properties for each pipe sizes, click on **+** button and select a pipe size :

![Image](../../Images/Piping4.jpg)

Click on **+** button (next to Mass) to add all possible reduction from the current size to a **smaller** one.

Length and mass can be entered :

| Property | Unit Metric | Unit USA | 
| -------- | ---- | ---- | 
| Length | m | ft | 
| Mass | ton | kips | 

{: .warning }
>ATTENTION, for a better readability, we recommend to enter the sizes in **ascending** order. 

---

To save time, you can also directly select a pipe size from **database** (2) :

![Image](../../Images/Design25.jpg)

Select a **Library**, a **Pipe size** and a **Schedule**. The tables will be filled automatically :

![Image](../../Images/Design26.jpg)

Click [here](https://documentation.metapiping.com/Settings/Databases/Piping.html) for more information about creation of library of piping elements.

---

Finally, you can define the **sections** of the model by defining pairs of Piping size/Material + special properties of the project.

Click to **+** button and select pipe sizes (Ex : 4") :

![Image](../../Images/Design28.jpg)

For each size, define the **schedule** and the **material**. A **pipe** knows now its section and its material.

Select then the **node connections** of the pipe between :
- None
- Butt weld - flush
- Butt weld - as welded
- Fillet weld
- Full fillet weld
- Threaded
- Brazed

Based on this property, define the **mismatch** or the **fillet length** [mm or in].

Select then the **Long weld type** of the pipe between :
- None
- Butt weld flush
- Butt weld as welde

Based on this property, define the **Long weld mismatch** [mm or in].

Other properties :

| Property | Unit Metric | Unit USA | Default |
| -------- | ---- | ---- | -- |
| Linear mass + insulation | kg/m | lb/ft | Linear mass of the pipe |
| Insulation thickness | mm |in | 0 |
| External corrosion | mm | in | 0 |
| Internal erosion | mm | in | 0 |
| Bend thickness | mm | in | Thickness of the pipe |

### 1.3 Spec driven mode

Another way to define **Materials** and **Piping elements** is to use a predefined **Specification**.

The goal of a specification is to supervise the engineer's work by predefining all piping elements, sections, materials, bend radius, reducer lengths, tees...

Click to **+** button and select a specification :

![Image](../../Images/Design27.jpg)

![Image](../../Images/Design29.jpg)

Click [here](https://documentation.metapiping.com/Settings/Specifications.html) for more information about creation of specification.

Now, you can use these 2 dropdown lists to select the current **section** :

![Image](../../Images/Design4.jpg)