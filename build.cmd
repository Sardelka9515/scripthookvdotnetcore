set MAJOR=1
set MINOR=2
set BUILD=2
set REVISION=0
set SHVDNC_VERSION=%MAJOR%.%MINOR%.%BUILD%.%REVISION%
set SHVDNC_VERSION_NUM=%MAJOR%,%MINOR%,%BUILD%,%REVISION%
set CORE_RES_PATH=src\core\core.rc

:: Backup resource script
copy "%CORE_RES_PATH%" "%CORE_RES_PATH%.tmp" /y

:: Replace version(because macros doesn't work for some reason)
powershell -Command "((gc %CORE_RES_PATH%) -replace 'SHVDNC_VERSION_NUM', '%SHVDNC_VERSION_NUM%') -replace 'SHVDNC_VERSION', '\"%SHVDNC_VERSION%\"' | Out-File -encoding ASCII  %CORE_RES_PATH%"

:: Build
msbuild ScriptHookVDotNetCore.sln /property:Configuration=Release

:: Restore
copy "%CORE_RES_PATH%.tmp" "%CORE_RES_PATH%" /y
del "%CORE_RES_PATH%.tmp" /q