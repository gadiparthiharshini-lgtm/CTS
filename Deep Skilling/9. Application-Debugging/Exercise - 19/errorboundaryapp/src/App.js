import React from "react";
import BuggyCounter from "./BuggyCounter";
import ErrorBoundary from "./ErrorBoundary";

function Counter() {
  return (
    <div style={{ padding: "20px" }}>
      <h1>Error Boundary Demo</h1>

      <p>Counter 1</p>
      <ErrorBoundary>
        <BuggyCounter />
      </ErrorBoundary>

      <hr />

      <p>Counter 2</p>
      <ErrorBoundary>
        <BuggyCounter />
      </ErrorBoundary>
    </div>
  );
}

export default Counter;