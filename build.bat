tools\nuget\nuget.exe restore RequestLoggerModule.sln

set MSBUILD="C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe"

rd /S /Q .\src\QbXml\bin\Debug
rd /S /Q .\src\QbXml\bin\Release

%MSBUILD% RequestLoggerModule.sln /p:Configuration="Debug"
if %errorlevel% neq 0 exit /b %errorlevel%

%MSBUILD% RequestLoggerModule.sln /p:Configuration="Release"
if %errorlevel% neq 0 exit /b %errorlevel%