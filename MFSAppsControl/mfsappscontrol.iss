[Setup]
AppName=MFS Apps Control
AppVersion=
VersionInfoVersion=
AppPublisher=Stalex
VersionInfoCompany=Stalex CORP
VersionInfoCopyright=Stalex
DefaultDirName={autopf}\MFS Apps Control
SetupIconFile="..\MFSAppsControl.ico"
UninstallDisplayIcon={app}\MFSAppsControl.exe
OutputBaseFilename=MFSAppsControlInstaller.win-x64
AllowUNCPath=no
AllowNetworkDrive=no
ArchitecturesAllowed=win64
LicenseFile=..\LICENSE.txt
DefaultGroupName=Stalex\MFS Apps Control
PrivilegesRequired=lowest

[Files]
Source: "bin\Release\net9.0-windows10.0.22621.0\win-x64\publish\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
Name: "{autoprograms}\Stalex\MFS Apps Control"; Filename: "{app}\MFSAppsControl.exe"
Name: "{autodesktop}\MFS Apps Control"; Filename: "{app}\MFSAppsControl.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Ajouter un raccourci sur le bureau"; GroupDescription: "Raccourcis :"

[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\Stalex\MFSAppsControl"
Type: filesandordirs; Name: "{localappdata}\Stalex\MFSAppsControl"
