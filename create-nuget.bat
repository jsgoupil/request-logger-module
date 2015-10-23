rd /S /Q .\publish

call build.bat
if %errorlevel% neq 0 exit /b %errorlevel%

md .\publish

tools\nuget\nuget.exe pack .\src\RequestLoggerModule\RequestLoggerModule.csproj -OutputDirectory .\publish -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%
