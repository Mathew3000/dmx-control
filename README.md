# dmx-control
A small tool for your arduino to control a DMX-System

<h2>Hardware:</h2>
-Arduino (any should do)
<br/>-DMX-Shield (I build one following http://danlin.de/projekte/arduino-dmx/)


<h2>Software:</h2>
<b>Arduino:</b>
<br/>-A program that selects a channel with serial input XXXc and value with XXXv and takes r to reset all
<br/>      (Such a program can be found at http://danlin.de/projekte/arduino-dmx/)
<br/>Note: If you are using the code from the link above and want to use DMX-Channels above 15 you have to change the line: '#define DMX_MAXCHANNEL 15' to the highest value you want to use. It is advised to set this number to the lowest possible for your DMX-Universe to increase performance.
<br/><b>PC:</b>
<br/>-Arduino Drivers (simply install the Arduino environment)
<br/>-This tool

<br/>For help with the usage of this tool, please consult the manual.
