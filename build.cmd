@SETLOCAL

@SET SRC=%~dp0\src
@SET ARTIFACTS=%~dp0\artifacts
@SET NUGET_COMMAND=%SRC%\.nuget\nuget.exe
@SET PACKAGE_VERSION=%APPVEYOR_BUILD_VERSION%

IF "%PACKAGE_VERSION%"=="" (
	SET PACKAGE_VERSION=0.0.1
)

@SET NUGET_PACKAGE_ID=CategoryTraits.xUnit2
@SET SOLUTION=%SRC%\CategoryTraits.xUnit2.sln
@SET PROJECT_FOLDER=%SRC%\%NUGET_PACKAGE_ID%
@SET MSBUILDARGS=/target:Rebuild /fileLogger /verbosity:minimal /ToolsVersion:14.0
@SET NUGET_PACKAGE_FOLDER=%ARTIFACTS%\%NUGET_PACKAGE_ID%
@SET DOTNET_FRAMEWORK=portable-net45+win+wpa81+wp80
@SET NUGET_PORTABLE_FRAMEWORK_FOLDER=%NUGET_PACKAGE_FOLDER%\lib\%DOTNET_FRAMEWORK%

RMDIR /Q /S "%ARTIFACTS%"
%NUGET_COMMAND% restore "%SOLUTION%"  -Verbosity quiet ||  GOTO BuildFailed
MSBuild "%SOLUTION%" %MSBUILDARGS% ||  GOTO BuildFailed
MSBuild "%SOLUTION%" %MSBUILDARGS% /property:Configuration=Release ||  GOTO BuildFailed
MKDIR "%NUGET_PORTABLE_FRAMEWORK_FOLDER%" ||  GOTO BuildFailed
COPY "%PROJECT_FOLDER%\bin\Release\%NUGET_PACKAGE_ID%.??l" "%NUGET_PACKAGE_FOLDER%\lib\%DOTNET_FRAMEWORK%\" ||  GOTO BuildFailed
COPY "%PROJECT_FOLDER%\bin\Release\%NUGET_PACKAGE_ID%.nuspec" "%NUGET_PACKAGE_FOLDER%\" ||  GOTO BuildFailed
%NUGET_COMMAND% pack "%NUGET_PACKAGE_FOLDER%\%NUGET_PACKAGE_ID%.nuspec" -Version %PACKAGE_VERSION% -NonInteractive -OutputDirectory %ARTIFACTS% -Properties version=%PACKAGE_VERSION%||  GOTO BuildFailed

@ECHO.
@ECHO **** BUILD SUCCESSFUL ****
GOTO:EOF

:BuildFailed
@ECHO.
@ECHO *** BUILD FAILED ***
EXIT /B -1