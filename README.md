# Railloader Example Mod

This repository contains an example setup of how to make mods with Railloader for Railroader. It is setup as a Visual Studio solution that can contain one or more mods, with each mod having a minimal setup. The base setup itself is technically game-agnostic, i.e. could be used for other games as well (and in fact, has been used by me for other games. It's my go-to template, basically.)

## Project Setup

In order to get going with this template, follow the following steps:

1. Get a copy of this repository using your favorite approach (clone, download, copying the code by hand, ...)
2. Copy the `Paths.user.example` to `Paths.user`, open the new `Paths.user` and set the `<GameDir>` to your game's directory.
3. Open the Solution
4. You're ready!

## Facts & Behaviours

- Builds will always land directly in the correct folder (i.e. GameDirectory/Mods/_AssemblyName_).
- You can reference assemblies in the game directory (i.e. Railroader_Data/Managed) directly and conveniently by using `<GameAssembly Include="" />`.
- Unless you specify an `<AssemblyVersion>` yourself, it will automatically generate a version based on `<MajorVersion>` (default 1), `<MinorVersion>` (default 0), and the current year, day of year, and time.
- Comes with a [Harmony analyzer](https://github.com/BUTR/BUTR.Harmony.Analyzer/tree/master) pre-added, so patching is less of a trial-and-error thing.
- This solution is multi-project/multi-mod-able; i.e. you can have multiple projects inside the solution, which then all produce individual mods.

## How To Use

For a general guide on how Railloader works, its current functionalities and APIs, please check the [probably still not complete documentation](https://railroader.stelltis.ch/railloader/).

### During Development
Make sure you're using the _Debug_ configuration. Every time you build your project, the files will be copied to your Mods folder and you can immediately start the game to test it.

### Publishing
Make sure you're using the _Release_ configuration. The build pipeline will then automatically do a few things:

1. Makes sure it's a proper release build without debug symbols
1. Replaces `$(AssemblyVersion)` in the `Definition.json` with the actual assembly version.
1. Copies all build outputs into a zip file inside `bin` with a ready-to-extract structure inside, named like the project they belonged to and the version of it.