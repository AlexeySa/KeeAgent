<img align="right" width="128" src="doc/images/logo.png" alt="KeeAgent">

# KeeAgent mod

**English** | [Русский](README.ru.md)

KeeAgent is a plugin for KeePass 2.x that makes SSH keys stored in a KeePass
database available to PuTTY, OpenSSH, and other SSH clients. It can run as a
standalone SSH agent (**Agent mode**) or connect to an existing agent
(**Client mode**).

This repository is a modified version of the
[original KeeAgent](https://github.com/dlech/KeeAgent). The general upstream
documentation is available at
[keeagent.readthedocs.io](https://keeagent.readthedocs.io/en/latest/). Features
specific to this fork are documented below.

## Features

- Store private SSH keys in a KeePass database or external files.
- Load keys automatically when a database is opened and remove them when it is
  locked.
- Support for PuTTY/Pageant, OpenSSH, Cygwin, MSYS, and WSL1.
- Confirmation, lifetime, and destination constraints.
- Select which keys are returned to a requesting client.
- Dedicated per-entry agent endpoints on Windows and Linux.
- Grant additional operating-system users access to supported endpoints.
- Conditionally auto-load keys based on the computer name.

## Changes in this fork

Changes relative to upstream, starting with commit
[`f604120`](https://github.com/AlexeySa/KeeAgent/commit/f604120b9e6b0ac62f7b740ed974513fd97a5481):

- migrated to .NET Framework 4.8;
- added an option to preserve permissions inherited by Cygwin/MSYS/WSL1 socket
  files from their parent directories;
- added configurable access for additional users to Pageant, Windows OpenSSH
  named pipes, and Linux Unix sockets;
- added the requesting process, user, and endpoint details to the key selection
  dialog;
- added the `IfDevice` field for loading keys only on selected computers;
- added restricted per-entry endpoints configured through `KeeAgentPipe`;
- extended `KeeAgentPipe` from Windows OpenSSH pipes to Linux Unix sockets;
- improved the load mode and endpoint display in KeeAgent Manager;
- added `KeeAgent.plgx` and `KeeAgent.dll` artifacts to GitHub Releases.

## Requirements

- KeePass 2.x;
- .NET Framework 4.8 on Windows or a compatible Mono version on Linux;
- Agent mode for features that use sockets or pipes created by KeeAgent.

## Installation

1. Download `KeeAgent.plgx` from the
   [latest release](https://github.com/AlexeySa/KeeAgent/releases/latest).
2. Copy it to the `Plugins` directory of your KeePass 2.x installation:
   - Windows: usually `C:\Program Files\KeePass Password Safe 2\Plugins`;
   - Linux: usually `/usr/lib/keepass2/Plugins`.
3. Restart KeePass.
4. Verify that the **KeeAgent** tab appears under **Tools → Options**.

Releases also include `KeeAgent.dll`, but PLGX is recommended for normal
installation. See the
[upstream installation guide](https://keeagent.readthedocs.io/en/latest/installation.html)
for details about Windows, Linux, and macOS.

> Do not install the PLGX and DLL variants at the same time.

When upgrading from `v0.13.8-mod.3`, the old
`KeeAgent.UsePerEntryWindowsOpenSshPipes` and Windows allowed-user settings are
not migrated automatically. Re-enable per-entry endpoints and fill in
**Give users access** if required.

## Quick start

1. Create or open a KeePass entry and put the private key passphrase in the
   **Password** field. Leave it empty if the key is not encrypted.
2. Attach the private key on the **Advanced** tab, or select an external file
   on the **KeeAgent** tab.
3. Enable **Allow KeeAgent to use this entry** on the **KeeAgent** tab.
4. Save the entry and select **Load SSH Key** from its context menu.
5. Open **Tools → KeeAgent** to view the loaded keys.

Full usage documentation:

- [Quick Start](https://keeagent.readthedocs.io/en/latest/usage/quick-start.html)
- [Options and Settings](https://keeagent.readthedocs.io/en/latest/usage/options.html)
- [KeeAgent Manager](https://keeagent.readthedocs.io/en/latest/usage/keeagent-manager.html)
- [Tips and Tricks](https://keeagent.readthedocs.io/en/latest/usage/tips-and-tricks.html)

## Per-entry agent endpoints

This feature lets an SSH client access only the keys assigned to a particular
alias instead of every key loaded in the agent.

1. Open **Tools → Options → KeeAgent** and enable
   **Enable per-entry SSH agent endpoints (Windows pipes / Linux sockets)**.
2. Open the KeePass entry, select **Advanced**, and add a string field named
   `KeeAgentPipe`.
3. Set its value to an alias such as `github-work`.
4. Load the key into KeeAgent.

An alias must contain 1–64 ASCII characters, start with a letter or digit, and
may contain letters, digits, `.`, `_`, and `-`.

| Platform | Endpoint for alias `github-work` |
| --- | --- |
| Windows | `\\.\pipe\keeagent-github-work` |
| Linux | `<main socket path>.github-work` |

For example, if the main Linux socket is `/run/user/1000/keeagent.sock`:

```bash
SSH_AUTH_SOCK=/run/user/1000/keeagent.sock.github-work ssh git@github.com
```

Entries with the same alias share an endpoint. Only their loaded keys are
available through it. The endpoint is removed after the last associated key is
unloaded.

## Access for additional users

The **Give users access** field is located under **Tools → Options → KeeAgent**.
Separate user names with semicolons. The user running KeePass always retains
access, and unknown users are silently ignored.

### Linux

The setting applies to KeeAgent's main and per-entry Unix sockets:

- when the field is empty, sockets use mode `0600` and only the KeePass owner
  is allowed;
- when the field is not empty, sockets use mode `0666`; after a connection is
  made, KeeAgent verifies the client's UID and accepts only the KeePass owner
  or one of the listed users.

Example:

```text
alice; bob
```

### Windows

The setting applies to Pageant and Windows OpenSSH named pipes. It does not
apply to Cygwin, MSYSGit, or WSL1 sockets. Only users are supported, not groups.

Example:

```text
.\bob; CONTOSO\carol
```

`.\bob` means the local user `bob` on the current computer. An unqualified name
such as `alice` is ambiguous and is resolved according to the Windows account
lookup rules, so prefer `.\alice` or `DOMAIN\alice`.

## Conditional key loading with `IfDevice`

To prevent a key from being loaded automatically on every computer, add an
`IfDevice` string field to the entry on the **Advanced** tab. It is matched
against `Environment.MachineName` and does not affect manual key loading.

Comma-separated patterns are supported:

- `workstation` — exact computer name;
- `laptop-*` — `*` and `?` wildcards;
- `office-pc, home-pc` — multiple allowed names;
- `!public-pc` — load everywhere except `public-pc`;
- `//^(work|home)-\d+$//` — a regular expression enclosed in `//`.

Matching is case-insensitive. If at least one `!` pattern is present, the list
acts as an exclusion list: the key is loaded on every computer that is not
explicitly excluded. This behavior is compatible with KeeAutoExec's
`IfDevice` field.

## Building

Clone the repository with its submodules and build the required configuration:

```powershell
git clone --recursive https://github.com/AlexeySa/KeeAgent.git
cd KeeAgent
msbuild KeeAgent.sln /t:Restore
msbuild KeeAgent.sln /t:Build /p:Configuration=ReleasePlgx
msbuild KeeAgent.sln /t:Build /p:Configuration=ReleaseDll
```

The artifacts are written to `KeeAgent/bin/ReleasePlgx` and
`KeeAgent/bin/ReleaseDll`. See [HACKING.md](HACKING.md) for additional developer
information.

## License and credits

This project is distributed under the [GNU GPL v2](GPL2.txt). The original
KeeAgent was created by David Lechner and project contributors. Changes made in
this fork are available in the
[commit history](https://github.com/AlexeySa/KeeAgent/commits/main/).
