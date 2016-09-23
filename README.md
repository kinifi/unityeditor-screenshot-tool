# unityeditor-screenshot-tool

take screenshots in the editor with this tool

![alt tag](http://i.imgur.com/A6l6xjs.png)

Installing: 

1. Download the Zip from here: [Download Project](https://github.com/kinifi/unityeditor-screenshot-tool/archive/master.zip)
2. Import the Unity Package into your Project. You can move this folder anywhere you want as long as you leave the folder structure.
3. Select Window-> and if Screenshot Tool is in the list then it was installed correctly


Steps to Take Screenshots in Editor Window: 

1. Open the Tool from Window->Screenshot Tool or Control+l on your keyboard
2. Dock the window if needed
3. Select a camera from your scene and drag it into the camera object field
4. Enter a name for the screenshot
5. Select a size. This will depict how long it takes to write to disk. 1 = normal
6. Select "Select Save Location" and go to the directory you wish to save the screenshot
7. Select Capture Screenshot
8. View and do whatever you want with your screenshot

Steps to Take Screenshots in Playmode in Editor: 
1. Attach the CaptureScreenshotPlaymode.cs to your main camera
2. Enter Playmode. The component will give you instructions on what is needed
3. Follow exactly the steps done for taking screenshots in the Editor Window.


Note: There is a bug in Unity on mac that gives an error when taking playmode screenshots but the screenshot is taken just fine. 






