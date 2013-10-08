Unity Face Tracking
=================

Unity face tracking is an easy way to use head position in your interactive projects.


Requirements
----------
To use Unity Face Tracking, you need to download and install [OpenTrack](https://github.com/opentrack/opentrack). This software is used to capture the head via your webcam.
This project works with Unity free and pro.

Getting Started
--------


 1. Launch Opentrack. 
* Select `FaceAPI` in Tracker Source.
* Use `Flight Gear` as Game Protocol (use the port 5550, by default)
* Press Start

2. Open the Unity project.
* Run the game in Unity. You are done !


How does it works
------------------
[FaceAPI](http://www.seeingmachines.com/product/faceapi/) is a powerfull real time 2D tracker. This software track the head-position in 3D providing X,Y,Z position and orientation coordinates per frame of video.
Opentrack allow us to send this via the [UDP](http://fr.wikipedia.org/wiki/User_Datagram_Protocol) protocol, on the local server. The head position data is stored in the ram. With unity 3D, the script UDPRecieve read the bytes, and decode it from hexa to float.

The UDPRecieve `c#` script is located in the Standard Assets folder, to be compiled before the `javascript` script. Buy doing this, we can make a gap between `c#` and `javascript`.

### To do

* Complete documentation

Credits
-------
* [Stanisław Halik](https://github.com/sthalik) (Opentrack team) for his help with byte decoding.
