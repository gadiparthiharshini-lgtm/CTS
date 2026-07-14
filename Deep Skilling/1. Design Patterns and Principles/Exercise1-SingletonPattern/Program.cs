using SingletonPatternExample;

// ---------------------------------------------------------------------------
// Test / demonstration "class" for the Singleton pattern.
//
// We obtain the Logger from several different places in the application and
// verify that every reference points to the exact same object.
// ---------------------------------------------------------------------------

Console.WriteLine("=== Singleton Pattern Demo: Logger ===\n");

// First access from the "main" flow.
Logger logger1 = Logger.Instance;
logger1.Log("Application started.");

// Simulate another, unrelated part of the application asking for a logger.
Logger logger2 = GetLoggerFromAnotherModule();
logger2.Log("Processing user request.");

// A third access, e.g. from a background task.
Logger logger3 = Logger.Instance;
logger3.Log("Background job finished.");

Console.WriteLine();
Console.WriteLine("--- Verification ---");
Console.WriteLine($"logger1.InstanceId = {logger1.InstanceId}");
Console.WriteLine($"logger2.InstanceId = {logger2.InstanceId}");
Console.WriteLine($"logger3.InstanceId = {logger3.InstanceId}");

bool sameInstance =
    ReferenceEquals(logger1, logger2) &&
    ReferenceEquals(logger2, logger3);

Console.WriteLine($"ReferenceEquals(logger1, logger2) = {ReferenceEquals(logger1, logger2)}");
Console.WriteLine($"ReferenceEquals(logger2, logger3) = {ReferenceEquals(logger2, logger3)}");
Console.WriteLine();
Console.WriteLine(sameInstance
    ? "SUCCESS: All references point to ONE single Logger instance."
    : "FAILURE: More than one Logger instance was created!");

// Helper that mimics a separate module requesting the logger.
static Logger GetLoggerFromAnotherModule() => Logger.Instance;
