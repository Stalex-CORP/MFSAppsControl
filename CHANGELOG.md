# Changelog

## v1.1 - 25-08-22

###  ! IMPORTANT TO READ ! 
This setup will not detect your previous installation.
You have to uninstall the previous version to avoid conflicts and future setup will be able to update your existing one.

### Changed

- Update target update link from github release page to flightsimto page.
- Update target framework to the right framework used.
- Update readme documentations

### Fixed

- Fix language initialisation which break app starting when system is not in English/French to fallback to English default. (Tested and validated by @Tobias-1)
- Add missing trim on current version to string to match github pattern which was causing an issue to check latest update.
- Fix initialisation log dev debug generated everytime in app dir even on release.
- Fix log4net config path for default user log to target localappdata app dir.

## v1.0 - 2025-08-20

### Added

- Initial application with WPF and WPF UI.
- Application model for defining app objects.
- Views and ViewModels (MVVM) for UI:
  - Configuration view for managing apps/scripts to be controlled with a simulation mode option to test without MFS and to remove unwanted app.
  - Add View for adding apps installed or standlone with args and auto-configuration of script execution.
- Microsoft Flight Simulator status watcher service using Windows ManagementEventWatcher.
- Localization service (English/French, default to system language).
- WPF converters (icon to image, collection to string for logging).
- Theme service to follow Windows light/dark mode.
- Vendor exclusion to hide system apps (Microsoft, Nvidia, etc.).
- App configuration file to store apps added and their configuration state.
- Logging service with log4net:
  - Daily file logger (`app.log`) at WARN level under `%localappdata%\Stalex\MFSAppsControl\`.
  - Daily debug file logger (`app-debug.log`) at DEBUG level (VS debugger mode only).
  - Console logger at INFO level (VS debugger mode only).
- System notification service to alert new update and background running when minimized.
- Setup Tray system to minimize app in notification apps.
- Standalone packaging using `dotnet publish` with embedded .NET runtime.
- Inno Setup configuration for create Windows installer.
- CI/CD workflows for automated build and release on GitHub.
- GitHub templates for issues and pull requests.
- All required files and assets: README (EN/FR), log4net config, icons, etc.

### Fixed

- Add configuration values null checking initialisation after test detection on null language
- Fix version number
- Fix wrong variables naming
