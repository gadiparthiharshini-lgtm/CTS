# Exercise 1 — Implementing the Singleton Pattern

## Scenario / Goal
Ensure a **logging utility class** has only one instance throughout the
application lifecycle, so that every part of the program logs in a consistent
way through the same object.

We build a `Logger` class with:
- a private static instance of itself,
- a private constructor,
- a public static accessor to get the instance,

and a small test driver that proves only one instance is ever created and
shared across the application.

## Concept — The Singleton Pattern

**Problem it solves:** Sometimes you need *exactly one* object of a class —
a logger, a configuration holder, a connection pool — and you want a single
global access point to it. If everyone could just `new` it, you would get
multiple inconsistent instances.

**Idea:** Make the constructor private so nobody outside the class can create
instances, keep one private static instance inside the class, and expose it
through a public static property/method.

**UML-ish structure (text):**

```
+----------------------------------+
|             Logger               |
+----------------------------------+
| - static instance : Logger       |   <- the one and only instance
| - InstanceId : int               |
+----------------------------------+
| - Logger()           (private)   |   <- cannot be called from outside
| + static Instance : Logger       |   <- global access point
| + Log(message : string) : void   |
+----------------------------------+
```

**When to use it:**
- Logging, configuration, caches, ID generators.
- Any time a *single shared resource* must be coordinated across the app.
- Avoid overusing it — it is essentially controlled global state.

### Why `Lazy<T>` here?
I used `System.Lazy<Logger>` instead of hand-written double-checked locking:
- It is **thread-safe by default** (`ExecutionAndPublication` mode), so two
  threads racing on first access still only create one instance.
- It is **lazy** — the instance is created only on first use.
- It avoids the classic bugs of manual double-checked locking (forgetting
  `volatile`, getting the lock/check order wrong). Less code, fewer mistakes.

## Project Structure

```
Exercise1-SingletonPattern/
├── Logger.cs                       # The Singleton logging utility
├── Program.cs                      # Test/demo driver (top-level statements)
├── SingletonPatternExample.csproj  # net8.0 console app
└── README.md                       # This file
```

## How to Run

Requires the **.NET SDK (8.0 or later)**.

```bash
cd Exercise1-SingletonPattern
dotnet run
```

## Expected Output

(Timestamps will reflect the moment you run it.)

```
=== Singleton Pattern Demo: Logger ===

[2026-06-24 10:00:00] [LOG] Logger instance created (InstanceId = 1).
[2026-06-24 10:00:00] [LOG] Application started.
[2026-06-24 10:00:00] [LOG] Processing user request.
[2026-06-24 10:00:00] [LOG] Background job finished.

--- Verification ---
logger1.InstanceId = 1
logger2.InstanceId = 1
logger3.InstanceId = 1
ReferenceEquals(logger1, logger2) = True
ReferenceEquals(logger2, logger3) = True

SUCCESS: All references point to ONE single Logger instance.
```

The key proof: all three `InstanceId` values are `1`, and `ReferenceEquals`
returns `True` — confirming a single shared instance.

## Key Takeaways
- A Singleton guarantees **one instance** with a **global access point**.
- The **private constructor** is what blocks external instantiation.
- `Lazy<T>` gives **thread-safe, lazy** initialization with almost no code.
- `sealed` prevents subclassing that could break the single-instance guarantee.
- `ReferenceEquals` is the cleanest way to prove two references are the same
  object (it ignores any overridden `==`/`Equals`).
