set MAJOR=1
set MINOR=1
set BUILD=1
set REVISION=0
set SHVDNC_VERSION=%MAJOR%.%MINOR%.%BUILD%.%REVISION%
set SHVDNC_VERSION_NUM=%MAJOR%,%MINOR%,%BUILD%,%REVISION%
msbuild ScriptHookVDotNetCore.sln /property:Configuration=Release