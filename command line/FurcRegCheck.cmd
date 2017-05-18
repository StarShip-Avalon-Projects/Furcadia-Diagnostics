@echo off
del /y "c:\FurcReg.txt"

whoami > "c:\FurcReg.txt"
date /T >> "c:\FurcReg.txt"
time /T >> "c:\FurcReg.txt"
ver >> "c:\FurcReg.txt"
echo . >> "c:\FurcReg.txt"

reg query "HKLM\SOFTWARE\Dragon's Eye Productions\Furcadia" /s  /reg:32 >> "c:\FurcReg.txt"
reg query "HKCU\SOFTWARE\Dragon's Eye Productions\Furcadia" /s  /reg:32 >> "c:\FurcReg.txt"
explorer c:\