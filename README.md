# layup

Layup is a modding platform meant to facilitate modding for the hit game [Hoop Land](https://store.steampowered.com/app/2453660/Hoop_Land). The idea is to give a consistent platform with extensive APIs and a built-in mod manager.

**NOTE:** Currently, I'm only developing this for Windows _but_ will do my best to make implementations agnostic.

## REQUIREMENTS

- [just](https://just.systems/)
- dotnet 6.0+ - You can install this using `winget install Microsoft.DotNet.SDK.<VERSION>`
    * Only .NET 6 / .NET 7 are supported w/ MelonLoader

## INSTALLATION

To build and install this mod, run the command `just run <INSTALLATION_PATH>`.

## THANKS TO

* [MelonLoader](https://github.com/LavaGang/MelonLoader) for providing tooling to help make injection for CPP2IL easier.
