#!/bin/bash
sudo git pull
sudo dotnet build /home/bih_datasus/SIASG/SIASG/SIASG_DOWNLOAD/SIASG_DOWNLOAD.vbproj --os linux
sudo dotnet build /home/bih_datasus/SIASG/SIASG/SIASG_IMPORT/SIASG_IMPORT.vbproj --os linux