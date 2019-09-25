RapidIoC for Unity v1.1

Full api documentation: https://github.com/cpgames/RapidIoC/wiki
Latest version of for Unity: https://github.com/cpgames/RapidIoCUnity
Latest version of RapidIoC for C#: https://github.com/cpgames/RapidIoC

---
This directory contains the following:

README.txt
This readme.

scripts
The actual RapidIoC code. This is the only bit you actually require in order to use RapidIoC. 
    cpGames/coreRapidIoC/api – folder which contains RapidIoC api that your code interacts with
    cpGames/coreRapidIoC/impl – folder which contains RapidIoC backend
    cpGames/coreRapidIoC/unity – unity extensions that integrate RapidIoC with Unity.


examples
RapidIoC implementation examples. Each example contains a pdf info with details. Feel free to delete these once you’ve got an idea how RapidIoC works. 
If you are new to RapidIoC, I recommend examining them in the following order:
    1. GettingStartedExample
    2. SceneManagementExample
    3. SpaceShipExample

---
Version history
v1.0 - Initial public release

v1.1
- Reorganizing and simplifying file structure
- Improvements to scene management code
- Added GetBinding command
- Added comment coverage to Signal