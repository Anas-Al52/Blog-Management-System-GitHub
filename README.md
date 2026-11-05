# Blog Management System (C# Console Application)

A Swedish-language console application for managing blog posts. Developed as a programming assignment to demonstrate fundamental C# programming concepts, data structures, and algorithms.

## Features

- Create a blog post with a title, message, and automatic creation timestamp.
- View all stored posts.
- Search posts by exact title using binary search.
- Edit a post by its displayed index.
- Delete a post by its displayed index.
- Sort posts by title using insertion sort.
- Exit using a menu-driven console interface.

## Technologies and concepts

- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **IDE:** Visual Studio (Windows)
- **Data structure:** `List<string[]>`
- **Algorithms:** Binary search, insertion sort
- **Other concepts:** Methods, loops, selection statements, input validation, `DateTime`

## Getting started

1. On Windows, install Visual Studio with the **.NET desktop development** workload and the **.NET Framework 4.7.2 targeting pack** (if not already installed).
2. Open `ConsoleApp1.sln` in Visual Studio.
3. Build and run the project (`Ctrl+F5`).
4. Select a numbered menu option (1–7) in the console.

## Project structure

- `ConsoleApp1/Program.cs` — source code and menu operations.
- `ConsoleApp1/ConsoleApp1.csproj` — C# project configuration.
- `ConsoleApp1.sln` — Visual Studio solution.
- `Aktivitetsdiagram.png` — activity diagram.
- `DFD Bolggen.drawio` — editable data-flow diagram.
- Supporting course documents: Swedish functional overview and FAQ.

## Limitations and possible improvements

- Posts are stored only in memory; they are lost when the application exits.
- This is a console application, not a deployed website.
- Search requires an exact title, rather than searching full post content.
- The insertion sort and binary search use different string comparison rules, which can lead to incorrect search results for certain titles. Aligning their comparers is a future improvement.
- Future extensions could add file/database persistence, automated tests, and a richer data model.

## Language

The application menu and user-facing prompts are in Swedish.

## Project status

Educational portfolio project. Original application logic has been preserved.
