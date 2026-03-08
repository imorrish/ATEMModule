# ATEMModule – Copilot Instructions

## Project Overview

ATEMModule is a **binary PowerShell module** (compiled C# DLL) that wraps the [LibAtem](https://github.com/LibAtem/LibAtem) C# library to expose Blackmagic ATEM video switcher control as PowerShell cmdlets. It supports connecting to multiple ATEM devices simultaneously and provides cmdlets for Mix Effects, Downstream Keyers, Upstream Keyers, transitions, auxiliary outputs, streaming, recording, media pool, macros, timecode, and color generators.

- **Language:** C# (.NET 8.0) targeting `net8.0`
- **Module type:** Binary PowerShell module (output is a `.dll` loaded by `Import-Module`)
- **License:** LGPLv3
- **Platforms:** Windows, macOS, Linux (including Raspberry Pi)

---

## Repository Layout

```
ATEMModule/
├── .github/
│   └── copilot-instructions.md     # This file
├── .vscode/
│   └── settings.json               # VSCode PowerShell formatting settings
├── .gitmodules                     # LibAtem referenced as a git submodule
├── build.ps1                       # PowerShell build & packaging script
├── LICENSE
├── README.md
├── LibAtem/                        # Git submodule – must be initialised before building
└── src/
│   ├── ATEMModule.csproj           # .NET 8.0 project; references LibAtem submodule
│   ├── ATEMModule.psd1             # PowerShell module manifest
│   ├── ATEMModule.psm1             # Thin PowerShell loader (loads the DLL)
│   ├── ATEMConnectionCommand.cs    # Add-ATEMSwitch + Get-ATEMModuleVersion cmdlets
│   ├── Utils/
│   │   └── Easing.cs               # Easing helper (static methods for smooth animation)
│   ├── DSK/                        # Downstream Keyer cmdlets (7 files)
│   ├── ME/
│   │   ├── Key/                    # Upstream Keyer cmdlets (15 files)
│   │   ├── Transition/             # Transition cmdlets (8 files)
│   │   └── *.cs                    # Core Mix Effect cmdlets (Cut, Auto, FTB, Program, Preview…)
│   ├── Macro/                      # Macro cmdlets (2 files)
│   ├── Media/                      # Media pool cmdlets (5 files)
│   ├── Recording/                  # Recording settings cmdlet
│   └── Settings/                   # Input/settings cmdlets
└── Tests/
    └── test.ps1                    # Manual integration test script (requires live ATEM hardware)
```

---

## Prerequisites

| Requirement | Details |
|-------------|---------|
| **.NET 8.0 SDK** | Build and run: <https://dotnet.microsoft.com/download> |
| **PowerShell 7+** | Recommended for running the module and tests |
| **Git submodule** | LibAtem must be initialised (see below) |
| **ATEM hardware** | Only needed for running `Tests/test.ps1` |

### Initialise the LibAtem submodule (required before first build)

```bash
git submodule update --init --recursive
```

**Error encountered if skipped:** `dotnet build` fails with  
`error MSB3202: The project file '...\LibAtem\LibAtem.csproj' was not found.`

---

## Building

```powershell
# From the repository root (PowerShell):
.\build.ps1
```

`build.ps1` does two things:
1. Runs `dotnet build .\src -o .\output\ATEMModule\bin`
2. Copies `src/ATEMModule.psd1` and `src/ATEMModule.psm1` into `output/ATEMModule/`

**Equivalent bare dotnet command (cross-platform):**
```bash
dotnet build src -o output/ATEMModule/bin
```

Build output lands in `output/ATEMModule/`. The usable module root for `Import-Module` is `output/ATEMModule/ATEMModule.psd1` (or directly `output/ATEMModule/bin/ATEMModule.dll`).

---

## Loading the Module

```powershell
# After a successful build:
Import-Module ".\output\ATEMModule\bin\ATEMModule.dll"

# Verify:
Get-ATEMModuleVersion
```

---

## Testing

There is **no automated test suite**. `Tests/test.ps1` is a manual integration script that requires live ATEM devices on the local network. Hardcoded IP addresses in the script (`192.168.1.8`, `192.168.1.10`, etc.) must be changed to match the local environment.

```powershell
# Edit Tests/test.ps1 to set correct IP addresses, then:
.\Tests\test.ps1
```

There are no Pester unit tests (commented-out `Invoke-Pester` in `build.ps1`). When adding new functionality, manual testing against real hardware is the only available verification path.

---

## Adding a New Cmdlet

Every public cmdlet follows the same pattern. Study any existing file (e.g. `src/ME/Set-ATEMMEProgramSource.cs`) to copy the structure:

1. **Create a new `.cs` file** in the appropriate subfolder (`ME/`, `DSK/`, `Macro/`, etc.).
2. Decorate the class with `[Cmdlet(VerbsCommon.Set, "ATEMXxx")]` (or another approved verb).
3. Inherit from `PSCmdlet`.
4. Declare parameters with `[Parameter(Mandatory = true, Position = N, ...)]`.
5. The first parameter is always `ATEMref` of type `LibAtem.Net.AtemClient`.
6. In `ProcessRecord()`, construct the relevant `LibAtem.Commands.*SetCommand`, populate its properties, and call `ATEMref.SendCommand(cmd)`.
7. No changes to `.csproj`, `.psd1`, or `.psm1` are required for a new cmdlet – the binary module loader discovers all `PSCmdlet` subclasses automatically.

Minimal example skeleton:

```csharp
using System.Management.Automation;
using LibAtem.Commands.SomeArea;
using LibAtem.Net;

namespace ATEMModule
{
    [Cmdlet(VerbsCommon.Set, "ATEMNewFeature")]
    public class SetATEMNewFeature : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public AtemClient ATEMref { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        public int MEID { get; set; }

        protected override void ProcessRecord()
        {
            var cmd = new SomeFeatureSetCommand
            {
                Index = MEID,
                // set other properties
            };
            ATEMref.SendCommand(cmd);
        }
    }
}
```

---

## Key Architectural Notes

- **`AtemClient`** (from LibAtem) is the connection handle. It is created by `Add-ATEMSwitch` and passed as `ATEMref` to every other cmdlet.
- **Commands** are plain C# objects from LibAtem's `LibAtem.Commands.*` namespace. Each command has a `Mask` bitmask to indicate which fields to update – set the relevant `Mask` flags before calling `SendCommand`.
- **`Easing.cs`** exposes `ATEMModule.Easing.EaseInOut(double step, string type)` for smooth animation loops in PowerShell scripts.
- The module targets `PowerShellStandard.Library 5.1.0-preview-06` (not the full PowerShell SDK) to remain cross-platform and compatible with PowerShell 7+.
- `SixLabors.ImageSharp` is included for media pool / still-capture image processing.

---

## Common Errors and Workarounds

| Error | Cause | Fix |
|-------|-------|-----|
| `MSB3202: project file not found` for LibAtem.csproj | Git submodule not initialised | `git submodule update --init --recursive` |
| `Import-Module` succeeds but cmdlets are missing | Wrong DLL path or stale build | Rebuild and point `Import-Module` at the `bin/` output directory |
| Tests fail / no output | ATEM device unreachable | Update IP addresses in `Tests/test.ps1`; verify network connectivity |
| `FunctionsToExport` in `psd1` is empty | Known issue in manifest | This is intentional for a binary module – cmdlets are exported by virtue of being `PSCmdlet` subclasses in the DLL |
| No cmdlet help available | No XML doc / help files | Consider [XmlDoc2CmdletDoc](https://github.com/red-gate/XmlDoc2CmdletDoc) (referenced in `build.ps1` comments) |
| Build targets wrong framework | Old `net6.0` path in `test.ps1` | Always build against `net8.0`; ignore commented-out `net6.0` / `netstandard2.0` import lines in `test.ps1` |

---

## Linting / Code Style

There is no automated linter or formatter configured. Follow the existing code style (C# standard conventions, no extra blank lines, consistent `[Parameter]` attribute ordering). Running `dotnet format src` can auto-format the code if needed but is not enforced by the build.

---

## No CI/CD

There are no GitHub Actions workflows in this repository. All builds and tests are run locally. If CI is added in future, the required steps are:

```yaml
- name: Checkout with submodules
  uses: actions/checkout@v4
  with:
    submodules: recursive

- name: Setup .NET
  uses: actions/setup-dotnet@v4
  with:
    dotnet-version: '8.0.x'

- name: Build
  run: dotnet build src -o output/ATEMModule/bin
```
