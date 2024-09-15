# Serial Port API

![.NET](https://img.shields.io/badge/.NET-4.8-blue) ![License](https://img.shields.io/badge/license-MIT-green)

## Overview

**Serial Port API** is an ASP.NET Web API built with **.NET Framework 4.8**, designed to communicate with serial ports on a machine. This API can be installed on an IIS server and allows external applications to interact with the host machine's serial port through HTTP endpoints. It provides functionality to read from, write to, and retrieve available serial ports, enabling easy serial communication over the network.

---

## Features

- **Serial Port Communication**: Endpoints for reading from and writing to serial ports.
- **Available Serial Ports**: An endpoint to retrieve a list of available serial ports on the host machine.
- **IIS Integration**: Can be deployed on an IIS server for easy network access to serial port communication.

---

## Technology Stack

- **Backend**:
  - .NET Framework 4.8
  - ASP.NET Web API
- **Serial Communication**: 
  - System.IO.Ports for managing serial ports
- **Hosting**:
  - IIS (Internet Information Services)

---

## Prerequisites

Ensure you have the following installed:

- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- IIS (Internet Information Services) enabled on your server

---

## Installation and Setup

### Steps to Install

1. **Clone the repository**:
    ```bash
    git clone https://github.com/ilia-public-projects/serial-port-api.git
    cd serial-port-api
    ```

2. **Build the Project**:
   Open the solution in Visual Studio and build the project.

3. **Configure IIS**:
   - Add a new website in IIS.
   - Point the website's physical path to the built output directory of the project.
   - Ensure that your IIS server has permissions to access the serial port on the machine.

4. **Run the API**:
   Once configured, the API will be available via the IIS server, and you can start interacting with the serial ports over HTTP.

---

