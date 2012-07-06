UnixTimestamp
=============

UnixTimestamp is a small struct with one, an only one, purpose: To convert to/from UnixTimestamp in various situations.

#Usage examples of the struct
```csharp
// UnixTimestamp support implicit convertion to System.DateTime
DateTime asDateTime = new UnixTimestamp(367731240);

// UnixTimestamp supports explicit convertion from System.DateTime
// Explicit conversion due to data loss in form of milliseconds being removed
UnixTimestamp timestamp = (UnixTimestamp)DateTime.Now;

// UnixTimestamp support TryParse operation from System.String
UnixTimestamp timestamp;
if (!UnixTimestamp.TryParse("367731240", out timestamp))
    throw new Exception("Not a valid timestamp");

// UnixTimestamp support implicit convertion to string
string timestamp = new UnixTimestamp(367731240);
```

Contribute
----------
UnixTimestamp is open source, and pull requests are welcome.
When developing for UnixTimestamp, please respect the coding style already present. Look around in the source code to get a feel for it. Also, please follow the [Open Source Contribution Etiquette](http://tirania.org/blog/archive/2010/Dec-31.html).

UnixTimestamp was developed entirely using TDD. Pull requests without test coverage will be politely declined.

UnixTimestamp has Code Analysis enabled on (almost) all rules and all warning are set as errors. No Code Analyis warnings should be suppressed unless the documented conditions for suppression are satisfied.