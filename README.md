# Csharp Minecraft Launcher

----------------------------------------------------

**USE [CmlLib.Core](https://github.com/AlphaBs/CmlLib.Core)**  

----------------------------------------------------

## Modification

Next to .exe application

Minecraft
├── .minecraft
|   ├── mods
|   |    └── *mod*.jar
|   ├── versions
|   |    └── *minecraftversion*
|   |         └── *minecraftversion*.json
|   ├── launcher_profiles.json
|   └── servers.dat
└── .minecraft

$ ./tree-md .
# Project tree

.
 * [tree-md](./tree-md)
 * [dir2](./dir2)
   * [file21.ext](./dir2/file21.ext)
   * [file22.ext](./dir2/file22.ext)
   * [file23.ext](./dir2/file23.ext)
 * [dir1](./dir1)
   * [file11.ext](./dir1/file11.ext)
   * [file12.ext](./dir1/file12.ext)
 * [file_in_root.ext](./file_in_root.ext)
 * [README.md](./README.md)
 * [dir3](./dir3)

### mods 
Your mod list 

### versions 
Version minecraft you want to use
Call this version with le launcher

### server.dat 
Ip list of your servers

### Runtime 
is located in C:\Program Files (x86)\Minecraft Launcher
Contain java.exe used by the launcher

