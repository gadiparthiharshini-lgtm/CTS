namespace SingletonPatternExample;

/// <summary>
/// A thread-safe logging utility implemented as a Singleton.
/// Only one <see cref="Logger"/> instance can ever exist for the lifetime
/// of the application, guaranteeing that every part of the program writes
/// to the same logger.
/// </summary>
/// <remarks>
/// The Singleton is realised with <see cref="System.Lazy{T}"/>:
/// <list type="bullet">
///   <item><description>It is fully thread-safe by default
///   (<see cref="System.Threading.LazyThreadSafetyMode.ExecutionAndPublication"/>),
///   so no manual locking or double-checked locking is required.</description></item>
///   <item><description>It is lazy — the instance is only created the first time
///   <see cref="Instance"/> is accessed, not at type load.</description></item>
///   <item><description>It is far less error-prone than hand-written
///   double-checked locking (no risk of forgetting <c>volatile</c> or mis-ordering checks).</description></item>
/// </list>
/// </remarks>
public sealed class Logger
{
    /// <summary>
    /// Backing lazy holder. The factory delegate runs at most once, and the
    /// CLR guarantees thread-safe publication of the result.
    /// </summary>
    private static readonly Lazy<Logger> _lazyInstance =
        new Lazy<Logger>(() => new Logger());

    /// <summary>
    /// Counts how many times the constructor actually runs. For a correctly
    /// implemented Singleton this must never exceed 1.
    /// </summary>
    private static int _instanceCount;

    /// <summary>
    /// A unique id assigned to this instance, used in tests to prove that the
    /// same object is handed out everywhere.
    /// </summary>
    public int InstanceId { get; }

    /// <summary>
    /// Private constructor — prevents any external code from using <c>new Logger()</c>.
    /// This is the cornerstone of the Singleton pattern.
    /// </summary>
    private Logger()
    {
        InstanceId = System.Threading.Interlocked.Increment(ref _instanceCount);
        Log($"Logger instance created (InstanceId = {InstanceId}).");
    }

    /// <summary>
    /// The single, globally accessible point of access to the <see cref="Logger"/>.
    /// </summary>
    public static Logger Instance => _lazyInstance.Value;

    /// <summary>
    /// Writes a log message to the console in the format
    /// <c>[timestamp] [LOG] message</c>.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[{timestamp}] [LOG] {message}");
    }
}
