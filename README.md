

# Remote Monitor

Remote Monitor is a desktop and Android application combination that allows users to monitor their Computer's performance, including CPU, GPU, Disk, and RAM usage remotely. It achieves this by establishing a connection between the desktop and Android apps using specified IP address, port, and keyword.

## Table of Contents

1.  [Features](#features)
2.  [Installation](#installation)
    -   [Desktop App](#desktop-app)
    -   [Android App](#android-app)
3.  [Usage](#usage)
    -   [Connecting Desktop and Android Apps](#connecting-desktop-and-android-apps)]
4.  [Issues](#issues)
5. [License](#license)

----------

## Features

-   Monitor PC statistics remotely (CPU, GPU, Disk, and RAM).
-   Establish a connection between desktop and Android apps using IP address, port, and keyword.
-   Simple and intuitive user interface.

----------

## Installation

### Desktop App

1.  Download the latest release of the Desktop App from the [Releases page](https://github.com/km/remotemonitor/releases).
2.  Run the Jar using `java -jar RemoteMonitor.jar`
### Android App

1.  Download the latest release of the Android App from the [Releases page](https://github.com/km/remotemonitor/releases).
2.  Install and run the application on your Android device.

----------

## Usage

### Connecting Desktop and Android Apps

1.  Launch the Jar on your PC.
2.  Note down the IP address, port, and keyword displayed on the application window.
3.  Launch the Android App on your device.
4.  Enter the IP address, port, and keyword from the Desktop App and tap "Connect".
<img src="https://i.imgur.com/X0ysuxO.jpg" width="60%" /> 
<img src="https://i.imgur.com/7hscrcm.jpg" width="30%" /> <img src="https://i.imgur.com/UhdtwzF.jpg" width="30%" />



## Issues

If you encounter any issues while using Remote Monitor, please consider the following troubleshooting steps:

1.  **Connection Problems:** If you experience connection problems, try restarting the application.
    
2.  **Firewall Settings:** Ensure that your firewall is not blocking the application. Adjust your firewall settings if necessary.
    
3.  **Network Limitations:** Currently, the application functions within LAN networks. To use it outside your local network, you can either set up port forwarding or employ a VPN service like [TailScale](https://tailscale.com/).

4. **Variable Statistics:** Keep in mind that not all statistics may be available on every computer. For example, integrated GPUs may not report temperature information.

5. **Single Component Display:** The application currently supports displaying a single instance of each component type (e.g., one CPU or one disk). If your system has multiple components of the same type, only one instance will be shown.

	It's highly recommended to run the desktop application as administrator to avoid any conflicts.
----------

## License

This project is licensed under the MIT License
