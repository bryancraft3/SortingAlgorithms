# SortingAlgorithms
*A collection of sorting algorithm implementations with visualizations, unit tests, and documentation.*

## Overview
SortingAlgorithms is a C# project that demonstrates classic sorting algorithms in a clear, structured, and test-driven way. It includes:

- Implementations of common sorting algorithms
- Console-based visualizations
- A dedicated test project with full coverage
- Documentation to help users understand the structure and purpose of the project

This repository is ideal for learning, teaching, or experimenting with algorithm behavior.

---

## Features
- **Bubble Sort** (currently implemented)
- **Additional sorting algorithms planned** (e.g., Insertion Sort, Selection Sort, Merge Sort, Quick Sort)
- **Console animations** to visualize how each algorithm processes data
- **Unit tests** using xUnit to ensure correctness and robustness
- **Clean architecture** with separation between logic, visualization, and testing

---

## Project Structure
```
SortingAlgorithms/
 ├─ SortingAlgorithms/           # Main project with algorithm implementations
 │   ├─ SortAlgorithms.cs
 │   ├─ SortVisualizer.cs
 │   └─ ...
 ├─ SortingAlgorithms.Tests/     # Unit tests for all algorithms
 ├─ SortingAlgorithms.sln        # Solution file
 └─ README.md                    # This documentation
```

---

## Running Tests
From the solution root:

```bash
dotnet test
```

All tests are located in the `SortingAlgorithms.Tests` project.

---

## Running the Application
From the solution root:

```bash
dotnet run --project SortingAlgorithms
```

Or run it directly from inside the project folder:

```bash
cd SortingAlgorithms
dotnet run
```

---

## Requirements
- .NET SDK (e.g., .NET 8.0)
- A terminal that supports ANSI colors (for visualizations)

---

## License
```
Copyright (c) 2026 Bryan Franke

All rights reserved.

This project and its contents may not be copied, modified, distributed, or used
without explicit written permission from the copyright holder.
```