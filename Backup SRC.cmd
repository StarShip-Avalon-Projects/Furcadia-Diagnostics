call UpdateSrc.cmd

<<<<<<< HEAD
=======
git pull
git submodule update -f --merge
>>>>>>> 97b9aad04c4c5e3b66bd4d56913d497d315f7622
IF "%~1"=="" GOTO BuildAll
IF "%~1"=="VersionBump" GOTO VersionBump

:VersionBump
msbuild /t:IncrementVersions;BuildAll  Solution.build
set BUILD_STATUS=%ERRORLEVEL% 
<<<<<<< HEAD
if %BUILD_STATUS%==0 goto BuildRelease 
=======
if %BUILD_STATUS%==0 goto end 
>>>>>>> 97b9aad04c4c5e3b66bd4d56913d497d315f7622
if not %BUILD_STATUS%==0 goto fail 
 
:BuildAll
msbuild /t:BuildAll  Solution.build
set BUILD_STATUS=%ERRORLEVEL% 
<<<<<<< HEAD
if %BUILD_STATUS%==0 goto BuildRelease 
if not %BUILD_STATUS%==0 goto fail 

:BuildRelease
 msbuild /t:Build /property:Configuration=Release Solution.build
 set BUILD_STATUS=%ERRORLEVEL% 
=======
>>>>>>> 97b9aad04c4c5e3b66bd4d56913d497d315f7622
if %BUILD_STATUS%==0 goto end 
if not %BUILD_STATUS%==0 goto fail 
 
:fail 
pause 
exit /b 1

:End

git add --all
<<<<<<< HEAD
set GIT_STATUS=%ERRORLEVEL% 
if not %GIT_STATUS%==0 goto eof 

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
=======
git commit -m"Update docs" --all

git submodule foreach "git add --all"
git submodule foreach "git commit -m'Auto Update SubModules'-a"
git submodule foreach "git push -f origin HEAD:master"
git push -f --all --recurse-submodules=on-demand

git request-pull master https://github.com/StarShip-Avalon-Projects/Furcadia-Diagnostics.git
>>>>>>> 97b9aad04c4c5e3b66bd4d56913d497d315f7622
