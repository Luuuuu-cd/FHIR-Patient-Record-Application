# FHIR-ARVisualizationTool
An android application that displays FHIR patient records in an AR environment

To test the application, download the apk file and send it to a mobile device, then install the apk file. To open this project, you will need Unity with Android development and AR Foundation package.

How to instll Unity with Android development and open the project
1. Download Unity hub in the Unity website
2. Install Unity under Installs tab in Unity Hub by clicking ADD: The unity version this project is using is 2019.2.13f1. (Might need to visit Unity download archives to download this version)
3. Add modules for Android development
5. Open Unity Hub and go to Projects, click ADD and navigate to the location of the project folder named “AR Visualisation Tool” and click select folder. Then click the project name to open it.
6. Once the project is opened, connect Android device, select build and run, store the apk file in an appropriate address, it will then be sent to the device.

Note: The authentication credentials need to be filled into the script "GetData".

Implementation
I use AR Foundation to build the AR environment of this application. The application allows user to track a plane using their phone and display patient records in a card style in the AR environment. The user can change the size of the information card to suit the environment and is also able to go to the next record or return to the previous record by clicking buttons.
