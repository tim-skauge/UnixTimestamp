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