@echo off

del /q /s clean.log >NUL 2>NUL

rem IDE files----------------------------------------------
rem del /q /s /ah *.suo  >>clean.log 2>NUL
del /q /s *.ncb  >>clean.log 2>NUL
del /q /s *.user >>clean.log 2>NUL

rem Directories-------------------------------------
for /f %%R in ('dir /s /b /ad') do call :bin %%R
goto :eof

:bin
if not exist %1\bin goto obj
rmdir /q /s %1\bin
echo Removing %1\bin>>clean.log

:obj
if not exist %1\obj goto end
rmdir /q /s %1\obj
echo Removing %1\obj>>clean.log

:end