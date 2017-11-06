
IF "%~1"=="" GOTO BuildAll
IF "%~1"=="VersionBump" GOTO VersionBump

:VersionBump
msbuild /t:IncrementVersions  Solution.build
set BUILD_STATUS=%ERRORLEVEL% 
if not %BUILD_STATUS%==0 goto fail 
 
:BuildAll
msbuild /t:BuildAll  Solution.build
set BUILD_STATUS=%ERRORLEVEL% 
if not %BUILD_STATUS%==0 goto fail 

:BuildRelease
msbuild /t:Build /property:Configuration=Release Solution.build
 set BUILD_STATUS=%ERRORLEVEL% 
if %BUILD_STATUS%==0 goto end 
if not %BUILD_STATUS%==0 goto fail  
 
:fail 
pause 
exit /b 1

:End

git add --all

git submodule foreach "git add --all"
set GIT_STATUS=%ERRORLEVEL% 
if not %GIT_STATUS%==0 goto eof 

git submodule foreach "git commit -m'Auto Update SubModules'"


git commit -m"Auto Version Update"
set GIT_STATUS=%ERRORLEVEL% 
if not %GIT_STATUS%==0 goto eof 

git push --recurse-submodules=on-demand
set GIT_STATUS=%ERRORLEVEL% 
if not %GIT_STATUS%==0 goto eof

:pull
git request-pull master https://github.com/StarShip-Avalon-Projects/Furcadia-Diagnostics.git

:eof
exit /b 0