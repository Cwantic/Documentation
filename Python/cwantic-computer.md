---
layout: default
title: cwantic-computer
nav_order: 8
parent: Python
---

# cwantic-computer

    cwantic-computer is the Cwantic's Python Library that gives access to MetaPiping and MetaStructure.

The library does not require the software to be launched !

>cwantic_computer will only work with correctly installed software and with a valid licence!

More info at https://pypi.org/project/cwantic-computer/

## Initialization

Before accessing cwantic_computer, you must initialize the library with the path of the installation folder and the module you want to use.

This will load MetaPiping/MetaStructure's dll and check your licence.

The library does not require the software to be launched !

```python
import cwantic_computer as cc

installationPath = "C:\\Program Files\\Cwantic\\MetaPiping 20XX.Y"

valid = cc.setup_cwantic_computer(installationPath, cc.CwanticModule.MetaPiping)
if valid:
    print("Success")
```

The module can be:
* cc.CwanticModule.All
* cc.CwanticModule.MetaPiping
* cc.CwanticModule.MetaStructure

## 1. MetaL methods

### 1.1 loadMetal

Load a MetaL model from file.

>loadMetal(metalFilename: str)

Parameters
-
- metalFilename : Path to the .metal file.

Returns
-
MetaL object if successful, None otherwise.

More info for class **Model** at https://documentation.metapiping.com/Python/Classes/metal.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-

```python
metal = cc.loadMetal(filename)
if metal != None:
    pass
```

### 1.2 saveMetal

Save a MetaL model to file, including associated .fre file.

>saveMetal(metal: Any, metalFilename: str)

Parameters
-
- metal : MetaL object to save.
- metalFilename : Path to save the metal file.

Raises
-
EnvironmentError if setup has not been completed.

Example
-

```python
metal = cc.loadMetal(filename)
if metal != None:
    cc.saveMetal(metal, newFilename)
```

### 1.3 getMetal

Return the first MetaL filename in the directory.

>getMetal(directory: str)

Parameters
-
- directory : Directory to search for .metal files.

Returns
-
Full path of the first .metal file found, or empty string if none.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
metalFilename = cc.getMetal(directory)
if metalFilename != "":
    metal = cc.loadMetal(metalFilename)
```

### 1.4 createPipingMetal

Create an empty piping MetaL model with a layer 0.

>createPipingMetal()

Returns
-
Empty piping MetaL object.

More info for class **Model** at https://documentation.metapiping.com/Python/Classes/metal.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
metal = cc.createPipingMetal()
cc.saveMetal(metal, filename)
```

### 1.5 createStructureMetal

Create an empty structure MetaL model with a layer 0.

>createStructureMetal()

Returns
-
Empty structure MetaL object.

More info for class **Model** at https://documentation.metapiping.com/Python/Classes/metal.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
metal = cc.createStructureMetal()
cc.saveMetal(metal, filename)
```

## 2. Solver methods

### 2.1 solve

Solve a piping or structure MetaL model using specified solver.

>solve(filename: str, solvername: str, sandbox: bool)

Parameters
-
- filename : Path to the .metal file.
- solvername : "Aster" or "PipeStress".
- sandbox : True to run in a temporary directory, False to run in place.

Returns
-
Solution object if solved successfully, None otherwise.

More info for class **Solution** at https://documentation.metapiping.com/Python/Classes/solution.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-

```python
filename = "...\\Study1.metaL"
solution = cc.solve(filename, "Aster", True)
if solution != None:
    print(f"  Max stress ratio = {solution.getMaxStressRatio(False)}")
    cc.disposeSolution()
```

### 2.2 solvePipingModel

Solve a piping MetaL using specified solver.

>solvePipingModel(metal: Any, metalFilename: str, solvername: str, directory: str)

Parameters
-
- metal : Piping MetaL object.
- metalFilename : Path to the metal file.
- solvername : Solver name ('Aster' or 'PipeStress').
- directory : Directory to execute the solver in.

Returns
-
Solution object if solved successfully, None otherwise.

More info for class **Solution** at https://documentation.metapiping.com/Python/Classes/solution.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-

```python
solution = cc.solvePipingModel(metal, metalFilename, "Aster", directory)
if solution != None:
    print(f"  Max stress ratio = {solution.getMaxStressRatio(False)}")
    cc.disposeSolution()
```

### 2.3 solveStructureModel

Solve a structure metal with Aster solver in directory:

>solveStructureModel(metal: Any, metalFilename: str, directory: str)

Solve a structure MetaL using Aster solver.

Parameters
-
- metal : Structure MetaL object.
- metalFilename : Path to the metal file.
- directory : Directory to execute the solver in.

Returns
-
Solution object if solved successfully, None otherwise.

More info for class **Solution** at https://documentation.metapiping.com/Python/Classes/solution.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-

```python
solution = cc.solveStructureModel(metal, metalFilename, directory)
if solution != None:
    print(f"  Max stress ratio = {solution.getMaxStressRatio(False)}")
    cc.disposeSolution()
```

### 2.4 disposeSolution

Close the solution and free associated memory and temporary files.

>disposeSolution()

Example
-

```python
solution = cc.solvePipingModel(metal, metalFilename, "Aster", dir)
if solution != None:
    cc.disposeSolution()
```

## 3. Command methods

### 3.1 createCommand

Create a custom command for the MetaL.

>createCommand(commandName: str, metal: Any)

Parameters
-
- commandName : Name of the custom command.
- metal : MetaL object the command applies to.

Returns
-
Command object ready to execute.

More info for class **CustomCommand** at https://documentation.metapiping.com/Python/Classes/commands.html 

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
cmd = cc.createCommand("ModifyMetal", metal)
...
cc.executeCommand(cmd)
```

### 3.2 executeCommand

Execute a previously created custom command.

>executeCommand(command: Any)

Parameters
-
- command : Command object returned by createCommand.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
cmd = cc.createCommand("ModifyMetal", metal)
...
cc.executeCommand(cmd)
```

## 4. Project methods

### 4.1 addProjectFolder

Add a new folder for a project.

>addProjectFolder(directory: str, folderName: str)

Parameters
-
- directory : Parent directory where folder will be created.
- folderName : Name of the folder to create.

Returns
-
Full path of created folder, empty string if folder already exists.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addStructureProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addStructureStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 4.2 removeProjectFolder

Remove a project folder.

>removeProjectFolder(folderDirectory: str)

Parameters
-
- folderDirectory : Path of the folder to remove.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addStructureProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addStructureStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 4.3 addPipingProject

Add a new project containing a piping study.

>addPipingProject(directory: str, projectName: str, studyName: str, screenWidth: int, screenheight: int)

Parameters
-
- directory : Path to the parent directory where the project folder will be created.
- projectName : Name of the new project folder.
- studyName : Name of the piping study to create inside the project.
- screenWidth : Width of the window used to initialize the study (used for UI positioning).
- screenheight : Height of the window used to initialize the study (used for UI positioning).

Returns
-
Full path of the created project directory if successful; empty string if the project folder already exists or creation failed.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addPipingProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addPipingStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 4.4 addStructureProject

Add a new project containing a structure study.

>addStructureProject(directory: str, projectName: str, studyName: str, screenWidth: int, screenheight: int)

Parameters
-
- directory : Path to the parent directory where the project folder will be created.
- projectName : Name of the new project folder.
- studyName : Name of the structure study to create inside the project.
- screenWidth : Width of the window used to initialize the study (used for UI positioning).
- screenheight : Height of the window used to initialize the study (used for UI positioning).

Returns
-
Full path of the created project directory if successful; empty string if the project folder already exists or creation failed.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addStructureProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addStructureStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 4.5 removeProject

Remove a project by path.

>removeProject(projectDirectory: str)

Parameters
-
- projectDirectory : Path of the project folder to remove.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
projectDirectory = cc.addPipingProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
if projectDirectory != "":
    cc.removeProject(projectDirectory)
```

## 5. Study methods

### 5.1 addPipingStudy

Add a piping study to an existing project.

>addPipingStudy(projectDirectory: str, studyName: str, screenWidth: int, screenheight: int)

Parameters
-
- projectDirectory : Path to the project folder.
- studyName : Name of the new study.
- screenWidth : Width of the window used to initialize the study.
- screenheight : Height of the window used to initialize the study.

Returns
-
Study object if added successfully, None otherwise.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addPipingProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addPipingStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 5.2 addStructureStudy

Add a structure study to an existing project.

>addStructureStudy(projectDirectory: str, studyName: str, screenWidth: int, screenheight: int)

Parameters
-
- projectDirectory : Path to the project folder.
- studyName : Name of the new study.
- screenWidth : Width of the window used to initialize the study.
- screenheight : Height of the window used to initialize the study.

Returns
-
Study object if added successfully, None otherwise.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addStructureProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addStructureStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 5.3 removeStudy

Remove a study from a project.

>removeStudy(projectDirectory: str, studyName: str)

Parameters
-
- projectDirectory : Path to the project folder.
- studyName : Name of the study to remove.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addPipingProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addPipingStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

### 5.4 duplicateStudy

Duplicate a study in a project.

>duplicateStudy(projectDirectory: str, studyName: str, copyStudyName: str)

Parameters
-
- projectDirectory : Path to the project folder.
- studyName : Name of the study to duplicate.
- copyStudyName : Name for the duplicated study.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
folder = cc.addProjectFolder(directory, folderName)
if folder != "":
    projectDirectory = cc.addPipingProject(folder, "TEST_PROJECT", "TEST_STUDY", 1920, 1080)
    if projectDirectory != "":
        study = cc.addPipingStudy(projectDirectory, "TEST_STUDY2", 1920, 1080)
        if study != None:
            studyDirectory = os.path.join(projectDirectory, "TEST_STUDY2")
            ...
            cc.removeStudy(projectDirectory, "TEST_STUDY")
            cc.duplicateStudy(projectDirectory, "TEST_STUDY2", "TEST_STUDY3")
            
cc.removeProjectFolder(folder)
```

## 6. Miscellaneous methods

### 6.1 copyDirectoryToTemp

Copy a directory to a unique temporary folder.

>copyDirectoryToTemp(directory: str)

Parameters
-
Directory to copy.

Returns
-
Path to temporary directory or empty string on failure.

Example
-
```python
temp_dir = cc.copyDirectoryToTemp(directory)
```

### 6.2 inspectClass

Export a class or instance as a JSON structure listing properties and public methods.

>inspectClass(instance: Any, indent: bool = False)

Parameters
-
- instance : The class or instance to inspect.
- indent : True to pretty-print JSON with indentation.

Returns
-
JSON string representing the object.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
json = cc.inspectClass(metal, False)
print(json)
```

### 6.3 findNameSpaceAndAssembly

Return the namespace and assembly of a class in MetaPiping.

>findNameSpaceAndAssembly(className: str)

Parameters
-
- className : Name of the class.

Returns
-
Namespace and assembly name, or (None, None) if not found.

Raises
-
EnvironmentError if setup has not been completed.

Example
-
```python
namespace, assembly = cc.findNameSpaceAndAssembly("RegularMaterial")
if namespace != None and assembly != None:
    cc.load_dll(assembly)
    # namespace will be "Cwantic.MetaPiping.Core" so you can manually write the next line
    from Cwantic.MetaPiping.Core import RegularMaterial # type: ignore
    mat = RegularMaterial()
    json = cc.inspectClass(mat, False)
    print(json)
```

### 6.4 load_dll

Load a .NET DLL from assembly name.

>load_dll(dllname: str)

Parameters
-
- dllname : Name of the DLL file to load.

Raises
-
EnvironmentError if setup has not been completed.
FileNotFoundError if the DLL cannot be found in installation directories.

Example
-
```python
namespace, assembly = cc.findNameSpaceAndAssembly("RegularMaterial")
if namespace != None and assembly != None:
    cc.load_dll(assembly)
    # namespace will be "Cwantic.MetaPiping.Core" so you can manually write the next line
    from Cwantic.MetaPiping.Core import RegularMaterial # type: ignore
    mat = RegularMaterial()
    json = cc.inspectClass(mat, False)
    print(json)
```
