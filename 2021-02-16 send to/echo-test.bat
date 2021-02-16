@echo off
set args=%1
:start
if [%1] == [] goto done
echo %args%
shift
set args=%1
goto start
:done
pause
