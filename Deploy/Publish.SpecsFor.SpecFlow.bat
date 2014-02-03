@echo off
powershell -NoProfile -ExecutionPolicy unrestricted -Command "& {.\publish.ps1 -PackageName 'SpecsFor.SpecFlow'; exit $error.Count}"
pause