tools\nuget\nuget.exe restore RequestLoggerModule.sln

set MSBUILD="C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

rd /S /Q .\src\RequestLoggerModule\bin\Debug
rd /S /Q .\src\RequestLoggerModule\bin\Release

%MSBUILD% RequestLoggerModule.sln /p:Configuration="Debug"
if %errorlevel% neq 0 exit /b %errorlevel%

%MSBUILD% RequestLoggerModule.sln /p:Configuration="Release"
if %errorlevel% neq 0 exit /b %errorlevel%