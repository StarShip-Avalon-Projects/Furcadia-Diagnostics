
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
git request-pull master https://github.com/StarShip-Avalon-Projects/FAN.git

:eof
exit /b 0