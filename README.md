# Request Logger Module

This package allows you to easily save into a database all requests and responses that your server emit.

## Installation ##

Install the package from NuGet.

```
Install-Package NoiseBakery.RequestLogger
```

This package will:

 * Install the necessary DLLs
 * Create a file called `MyRequestLoggerModule.cs`
 * Register the module in your web.config

If you want to change the file name, don't forget to change the registration in your web.config!

## Configuration ##

Add some code in `MyRequestLoggerModule.cs` in order to save the log entry to your database.

```C#
public class MyRequestLoggerModule : RequestLoggerModule
{
  protected override void SaveLogEntry(LogEntry logEntry, HttpRequest request, HttpResponse response)
  {
    // Add some code in order to save to your database.
    var db = new ApplicationDbContext();
    db.Log.Add(logEntry);
    db.SaveChanges();
  }
}
```

## Extra data ##

If you want to add extra data to a log entry, such as the current logged in user, do the following:

```C#
public ActionResult Index()
{
  if (Request.IsAuthenticated)
  {
    var loggedInUser = Request.RequestContext.HttpContext.User.Identity.Name;
    NoiseBakery.RequestLogger.SaveLogEntry("LoggedIn", loggedInUser);
  }
} 
```

The data will be available in the `LogEntry` instance under the property name `Extra`.

## Contributing

Contributions are welcome. Code or documentation!

1. Fork this project
2. Create a feature/bug fix branch
3. Push your branch up to your fork
4. Submit a pull request

## License

Request Logger Module is under the MIT license.
