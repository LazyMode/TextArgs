@echo off
pushd Release
powershell -ExecutionPolicy Bypass -File "..\package.ps1" "..\%~n0.nuspec" Portable\%~n0
popd
echo.
echo Done.
