# Changelog
## [1.0] - 2025-08-12

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

### Changed

### Fixed

### Removed