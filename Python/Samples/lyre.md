---
layout: default
title: Add loop
nav_order: 7
parent: Samples
grand_parent: Python
---

# Sample 7 : Replace a selected pipe by an expansion loop

## 1. Goal

Create a script that will (after pressing a **button** in the ribbon) replace a selected pipe by an expansion loop. A window will appear to define the size and the default bend radius.

![Image](../../Images/illustration256x165.png)

>This feature does not exists in MetaPiping 2023.0 so it is usefull that user can create his own COMMANDS based on the MetaL internal format and the existing documented commands.

>Since the user will have to create a COMMAND, the application will manage the undo/redo operations by itself !

## 2. Script definition

From the Home/Python, click on **button 3** (Add 3D script) :

![Image](../../Images/PythonMenu.jpg)

Give it the name "Add loop"

## 3. requirements.txt

We want to show a **window** so that the user can define the **L** and **R** values, respectively the size and the bend radius of the expansion loop.

We ask [ChatGPT](https://documentation.metapiping.com/Python/chatGPT.html) to recommand some python libraries :

![Image](../../Images/PythonSample7_9.jpg)

We will choose wxPython :

![Image](../../Images/PythonSample7_3.jpg)

Add this library in requirements.txt, **save** and **install** it from the three points button.

This window will appears :

![Image](../../Images/PythonSample7_4.jpg)

{: .warning }
> If you don't see this window, it means that the library has not been correctly installed. Close the application and reinstall requirements.txt.

## 4. Script files

This kind of script needs some **images** in order to illustrate the **button** and the **window**.

![Image](../../Images/PythonSample7_1.jpg)

Press the "three points" button and select "Import image". You need to create a 32x32 transparent PNG for the icon of the button and an illustration of the expansion loop for the window.

Press the "three points" button and select "Add a python file". We will create a file for some trigonometric functions and one for the definition of the window.

### 4.1 trigonometry.py

Select the file.

Copy/paste this code in the Editor :

```python
def cross(vec1, vec2):
    return [vec1[1]*vec2[2] - vec1[2]*vec2[1], vec1[2]*vec2[0] - vec1[0]*vec2[2], vec1[0]*vec2[1] - vec1[1]*vec2[0]]

def length(vec):
    return (vec[0] ** 2 + vec[1] ** 2 + vec[2] ** 2) ** 0.5

def normalize(vec):
    l = length(vec)
    return [vec[0]/l, vec[1]/l, vec[2]/l]
```

Save it !

### 4.2 window.py

Ask help to [ChatGPT](https://documentation.metapiping.com/Python/chatGPT.html) :

![Image](../../Images/PythonSample7_10.jpg)

After some research and multiple tests :

```python
import wx
import os

class Frame(wx.Frame):
    def __init__(self, parent, id, title, app):
        wx.Frame.__init__(self, parent, id, title, size=(300, 310))
        self.app = app
        
        panel = wx.Panel(self)
        panel.BackgroundColour = 'white'
                
        png = wx.Image(os.path.join(os.path.dirname(__file__), 'illustration256x165.png'), wx.BITMAP_TYPE_PNG).ConvertToBitmap()
        sb = wx.StaticBitmap(panel, -1, png, (0, 0), (png.GetWidth(), png.GetHeight()))
        
        text = wx.StaticText(panel, -1, "L =", pos = (10, 183))
        text.SetSize(text.GetBestSize())
        
        self.edit = wx.TextCtrl(panel, -1, "1", size=(100, -1), pos = (50, 180))
        self.edit.SetInsertionPoint(0)
        
        text2 = wx.StaticText(panel, -1, "R =", pos = (10, 213))
        text2.SetSize(text2.GetBestSize())
        
        self.edit2 = wx.TextCtrl(panel, -1, "0.1", size=(100, -1), pos = (50, 210))
        self.edit2.SetInsertionPoint(0)
        
        btn = wx.Button(panel, -1, "Run", size=(100, 20), pos = (100, 240))
        self.Bind(wx.EVT_BUTTON, self.OnRun, btn)

        self.CenterOnScreen(wx.BOTH)

    def OnRun(self, evt):
        self.app.SetLValue(self.edit.GetValue())
        self.app.SetRValue(self.edit2.GetValue())
        self.Close()


class App(wx.App):
    def __init__(self):
        wx.App.__init__(self)
        self.Lvalue = ""
        self.Rvalue = ""
        self.frame = Frame(None, wx.ID_ANY, "Loop definition", self)
        self.SetTopWindow(self.frame)
        self.frame.Show(True)
        
    def SetRValue(self, value):
        self.Rvalue = value
        
    def GetRValue(self):
        return self.Rvalue

    def SetLValue(self, value):
        self.Lvalue = value
        
    def GetLValue(self):
        return self.Lvalue

```

Save it !

## 5. Script properties

In this kind of script, user has to define the **button** :

![Image](../../Images/PythonSample7_2.jpg)

The location will be **Design** so that the button appears at the end of the ribbon with its name, icon and description :

![Image](../../Images/PythonSample7_5.jpg)

## 6. main.py

Select the file.

Copy/paste this code in the Editor :

```python
from window import App
from trigonometry import cross, normalize
from Cwantic.MetaPiping.Core import CurrentPipingValues, CurrentTeeValues
   
# Inspect selection
n = len(design.selectedList)
res = "Select a pipe !"

if n==1:
    # Check the type of selected
    if design.isType(design.selectedList[0], "Pipe"):
        pipe = design.selectedList[0]
        p1 = pipe.Node1.Coor
        p2 = pipe.Node2.Coor
        
        # Get the current model
        model = design.getMetal()
        
        # Get the scene vertical vector
        verticalvec = design.getVerticalVector()
        
        # Get the piping values (section, material,...) of the selected pipe
        currentPipingValues = CurrentPipingValues.CreateCurrentPipingValuesFromPiping(model, pipe)
        
        # Create empty Tee values (not important for the loop but mandatory for the pipe command)
        currentTeeValues = CurrentTeeValues()
        
        # Get the pipe direction vector
        vec1 = (pipe.DL.X, pipe.DL.Y, pipe.DL.Z)
        
        # Compute the cross product to determine the loope direction
        dir = cross(vec1, verticalvec)
        dir = normalize(dir)

        # Create a new USER command
        cmd = design.createCommand("AddLoop")
        
        # 1 : Remove the selected pipe
        
        # 1.1 : Create params for command "RemoveElementCommand" (see Help)
        params = []
        params.append(design.selectedList)
        
        # 1.2 : Add sub command to user command cmd
        valid = cmd.addSubCommand("RemoveElementCommand", params)
        
        if valid:
            # 2 : Create new pipe perpendicular to selected pipe from node1
            
            # Remark : the bends are automatically made by the "AddPipeCommand"
            
            # 2.0 : Launch window to get loop's size and bend radius
            app = App()
            app.MainLoop()
            
            size = float(app.GetLValue())
            currentPipingValues.BendRadius = float(app.GetRValue())
            currentPipingValues.ReducerLength = 0.0
            
            # 2.1 : Create params for command "AddPipeCommand" (see Help)
            params = []
            params.append(p1.X)
            params.append(p1.Y)
            params.append(p1.Z)
            params.append(p1.X + size*dir[0])
            params.append(p1.Y + size*dir[1])
            params.append(p1.Z + size*dir[2])
            params.append(0.0)
            params.append(0.0)
            params.append(0.0)
            params.append(currentTeeValues)
            params.append(currentPipingValues)
            
            # 2.2 : Add sub command
            valid = cmd.addSubCommand("AddPipeCommand", params)
        
            if valid:
                # 3 : Create new pipe parallel to selected pipe
             
                # 3.1 : Create params for command "AddPipeCommand" (see Help)
                params = []
                params.append(p1.X + size*dir[0])
                params.append(p1.Y + size*dir[1])
                params.append(p1.Z + size*dir[2])
                params.append(p2.X + size*dir[0])
                params.append(p2.Y + size*dir[1])
                params.append(p2.Z + size*dir[2])
                params.append(0.0)
                params.append(0.0)
                params.append(0.0)
                params.append(currentTeeValues)
                params.append(currentPipingValues)

                # 3.2 : Add sub command
                valid = cmd.addSubCommand("AddPipeCommand", params)
                
                if valid:
                    # 4 : Create new pipe to close the loop
                    
                    # 4.1 : Create params for command "AddPipeCommand" (see Help)
                    params = []
                    params.append(p2.X + size*dir[0])
                    params.append(p2.Y + size*dir[1])
                    params.append(p2.Z + size*dir[2])
                    params.append(p2.X)
                    params.append(p2.Y)
                    params.append(p2.Z)
                    params.append(0.0)
                    params.append(0.0)
                    params.append(0.0)
                    params.append(currentTeeValues)
                    params.append(currentPipingValues)
                
                    # 4.2 : Add sub command
                    valid = cmd.addSubCommand("AddPipeCommand", params)
                    
        # Execute command
        if valid:
            design.executeCommand(cmd)
            res = ""
        else:
            res = "Incorrect params"
    else:
        res = "The selected element is not a pipe"
    
# Show a message (if res != "")
design.result = res
```

Save it !

## 7. Result

In **Design mode**, select a pipe that you want to replace by an expansion loop :

![Image](../../Images/PythonSample7_6.jpg)

Click on the new button **Add loop** :

![Image](../../Images/PythonSample7_7.jpg)

Complete **L**, **R** and press **Run** :

![Image](../../Images/PythonSample7_8.jpg)

The expansion loop appears !

You can undo/redo your COMMAND !