@echo off
setlocal
set pack=%~n0
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\%pack%.nuspec" "Portable\%pack:~0,-3%"
popd
echo.
echo Done.
