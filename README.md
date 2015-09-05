# TrueCryptSimpleGUI

With TrueCrypt you can mount an encrypted file to a new drive. Usually method that used by all file/folder encryption tools. TrueCrypt is freeware, the original GUI has too many options. I would like to open an application, write my password and mount, thats why SimpleGUI created.


How to create a container/partition :

http://www.afterdawn.com/guides/archive/create_hidden_encrypted_volume_within_a_file_using_truecrypt.cfm


####Tray Icon
---------
Shift + Right Click = Opens Application

Shift + Left Click  = Closes Application, doesnt unount.

####Command Line Arguments
----------------------

```javascript
//try to mount file 1002.dat which is near exe
-a "1002.dat"

//try to mount a file in a specified location
-a "c:\pipiscrew\1002.dat"

//open explorer (truecrypt command line)
-e
```
