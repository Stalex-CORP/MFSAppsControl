# Installation

## Requirements

- **Windows 10 or 11 (64-bit)**
- **Microsoft Flight Simulator 2024 and/or 2020** (installed)
- **WebView2** — already present on Windows 11 and up-to-date Windows 10. If needed, the installer downloads it automatically.
- **SimConnect (shipped with the simulator)** — the "ready to fly" detection uses SimConnect to know whether the simulator is ready to receive the applications.

## Download

MFSAppsControl is available on:

- [:material-download: **Flightsim.to**](https://fr.flightsim.to/addon/96593/mfs-apps-control)

## Install

1. Run the downloaded installer.
2. If Windows SmartScreen shows a "Windows protected your PC" warning,<br>
  click **More info** then **Run anyway**.<br>
  This is normal preventive behavior for a recent application, which needs a number of installations before Microsoft recognizes it.
3. Follow the wizard step by step to complete the installation.

!!! tip "Updates"
    Once installed, the application **tells you when a new version is available** (badge and notification).<br>
    You can download and install it straight from the application by clicking the badge, or from the options.

## Updating from 2.0

Your profiles and settings are converted automatically at the first start of 2.1.<br>
A copy of the previous file is kept in `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl`, named `settings.v2.1.0.<date>.json`: keep it if you might go back to 2.0, which cannot read the converted file.

Right after the update, MFSAppsControl also offers to [group into Shared](profiles.md#grouping-into-shared) the applications all your profiles have in common.

!!! info "Administrator rights"
    If any of your profiles holds an application that requires administrator rights, the Windows prompt now comes at startup, whichever profile is active.

## First launch

On first start, MFSAppsControl opens on an **empty profile** by default.<br>
Follow the [**Getting started**](getting-started.md) guide to add your first applications.

## Uninstall

Go to<br>
**Windows Settings → Apps → Installed apps → MFSAppsControl → Uninstall**.


!!! tip "Complete cleanup"
    Your configuration **is not deleted** unless you tick the data removal option: your profiles are therefore kept if you reinstall.
