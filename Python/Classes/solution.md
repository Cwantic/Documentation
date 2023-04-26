---
layout: default
title: solution
nav_order: 4
parent: Classes
grand_parent: Python
---

# solution

The **solution** object gives access to all analysis results and can be accessed through the [study](https://documentation.metapiping.com/Python/Classes/study.html) object.

## 1. Properties

| Name | Return | Description |
| --- | ----------- | ----------- |
| getMetal() | metal | Access to the analysis MetaL object of the solution |
| getDisplacements() | list of (displacement, rotation) | Get the displacement/rotation results for a load case number on each node (see § 3)
| getAccelerations() | list of accelerations | Get the acceleration results for a load case number on each node (see § 4)
| getReactions() | list of (force, moment) | Get the force/moment results for a load case number on each **restrained** node (see § 5)
| getForces() | list of (force, moment) | Get the force/moment results for a load case number on each element (see § 6)
| getModeShape() | list of (displacement, rotation) | Get the displacement/rotation results for a mode number on each node (see § 7)
| getStressIDList() | list of string | Get the list of all stress types for a load case number (see § 8)
| getStresses() | list of double | Get the stress value for a load case number and a stress index on each element (see § 9)
| getMaxStressRatio() | double | Get the max stress ratio for all elements and all load cases. You can specify if the result include the thermal (bool - false by default) (see § 10)


    ATTENTION : the metal given by the solution (getMetal) is different from the metal given by the study ! 
    The 'solution metal' has been transformed by the current piping code.

See [metal](https://documentation.metapiping.com/Python/Classes/metal.html) for more information.

## 2. How to get the solution ?

The solution object can be reached via the [study](https://documentation.metapiping.com/Python/Classes/study.html) object. An analysis must have been done before.

```python
# Python script  
solution = study.getSolution()
if solution != None:
    # ...
```
---
## 3. getDisplacements()

Once the solution exists, you can retrieve the displacement and rotation on each [node](https://documentation.metapiping.com/Python/Classes/node.html) for a certain load case number (int).

getDisplacements() returns a list of (Item1, Item2). Item1 represents the displacement (Vector3D) and Item2 the rotation (Vector3D) of a node. This list is ordered like the metal's nodes one.

```python
# Python script    
displacements = solution.getDisplacements(case)
if len(displacements) > 0:
    for item in displacements:
        displacement = item.Item1
        rotation = item.Item2
```

You can access the **X**, **Y** and **Z** properties like this :

```python
# Python script
length = (displacement.X**2 + displacement.Y**2 + displacement.Z**2) ** 0.5
```

The displacement/rotation values are given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.

---
## 4. getAccelerations()

Once the solution exists, you can retrieve the acceleration on each [node](https://documentation.metapiping.com/Python/Classes/node.html) for a certain load case number (int).

getAccelerations() returns a list of Vector3D. This list is ordered like the metal's nodes one.

```python
# Python script    
accelerations = solution.getAccelerations(case)
if len(accelerations) > 0:
    for acceleration in accelerations:
        # you can access acceleration.X, acceleration.Y, acceleration.Z
```


The acceleration values are given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.

---
## 5. getReactions()

Once the solution exists, you can retrieve the reaction on each [restrained node](https://documentation.metapiping.com/Python/Classes/node.html) for a certain load case number (int).

    ATTENTION : the 'restrained nodes' are the nodes where a restraint has been defined. 
    It is a special list in the metal. The reactions are given in the same order.

getReactions() returns a list of (Item1, Item2). Item1 represents the force (Vector3D) and Item2 the moment (Vector3D) on a node.

```python
# Python script    
reactions = solution.getReactions(case)
if len(reactions) > 0:
    for reaction in reactions:
        force = reaction.Item1
        moment = reaction.Item2
        # you can access force.X, force.Y, force.Z
        # you can access moment.X, moment.Y, moment.Z
```

The force/moment values are given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.

---
## 6. getForces()

Once the solution exists, you can retrieve the forces on each [element](https://documentation.metapiping.com/Python/Classes/element.html) for a certain load case number (int).

getForces() returns a list of (Item1, Item2). One couple for the extremity 1 and one couple for the extremity 2. Item1 represents the force (Vector3D) and Item2 the moment (Vector3D) on an extremity of an element. This list is ordered like the metal's elements but with twice the size.

```python
# Python script    
forces = solution.getForces(case)
if len(forces) > 0:
    firstExtremity = True
    for item in forces:
        force = item.Item1
        moment = item.Item2
        # you can access force.X, force.Y, force.Z for an extremity of an element
        # you can access moment.X, moment.Y, moment.Z
        firstExtremity = not firstExtremity
```

The force/moment values are given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.


---
## 7. getModeShape()

Once the solution exists, you can retrieve the displacement and rotation on each [node](https://documentation.metapiping.com/Python/Classes/node.html) for a certain mode number (int).

getModeShape() returns a list of (Item1, Item2). Item1 represents the displacement (Vector3D) and Item2 the rotation (Vector3D) of a node. This list is ordered like the metal's nodes one.

```python
# Python script    
displacements = solution.getModeShape(mode)
if len(displacements) > 0:
    for item in displacements:
        displacement = item.Item1
        rotation = item.Item2
        # you can access displacement.X, displacement.Y, displacement.Z
        # you can access rotation.X, rotation.Y, rotation.Z
```


The displacement/rotation values are given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.

---
## 8. getStressIDList()

Once the solution exists, you can retrieve the stress id list for a certain load case number/ or mode shape.

getStressIDList() returns a list of String depending on the load case (int) and internally the current piping code.

Example of result for RCCM class2, equation 2 : { "Ratio", "Eq. 6", "Sallow", "SPres", "SMomA" }


---
## 9. getStresses()

Once the solution exists, you can retrieve the stresses on each [element](https://documentation.metapiping.com/Python/Classes/element.html) for a certain load case number (int) and a certain stress index (int) from getStressIDList (see § 8).

getStresses() returns a list of Double. Two Double by element, one for the extremity 1 and one for the extremity 2. This list is ordered like the metal's elements but with twice the size.

```python
# Python script    
stresses = solution.getStresses(case, stressIndex)
if len(stresses) > 0:
    firstExtremity = True
    for stress in stresses:
        # you have the stress value for an extremity of an element
        # ...
        firstExtremity = not firstExtremity
```

The stress value is given in the [output units](https://documentation.metapiping.com/Design/units.html) specified in the model options.


---
## 10. getMaxStressRatio()

Once the solution exists, you can retrieve the MAX stress ratio for the whole piping and for all load cases.

getMaxStressRatio() returns a Double. You can specify as parameter a Boolean to include Thermal or not.

```python
# Python script    
maxStress = solution.getMaxStressRatio(True)
```

    A value less than 1 indicates a valid piping model !

The max stress value is unitless.

