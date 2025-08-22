#define appName "MFS Apps Control"
#define appVersion "1.1"
#define appPublisher "Stalex"
#define appCompany "Stalex CORP"
#define appLink "https://github.com/stalex-CORP/"
#define appSourceLink "https://github.com/Stalex-CORP/MFSAppsControl"
#define appPublishedLink "https://fr.flightsim.to/file/96593/mfs-apps-control"
#define appExeName "MFSAppsControl.exe"
#define outputPath "Output"

[Setup]
AppId={{7A811871-E944-4647-B754-0C5081F9AD33}}
AppName={#appName}
AppVersion={#appVersion}
VersionInfoVersion={#appVersion}
AppPublisher={#appPublisher}
AppPublisherURL={#appLink}
AppSupportURL="{#appSourceLink}/issues"
AppUpdatesURL={#appPublishedLink}
VersionInfoCompany={#appCompany}
VersionInfoCopyright={#appCompany}
DefaultDirName={autopf64}\{#appName}
AllowUNCPath=no
AllowNetworkDrive=no
UninstallDisplayIcon={app}\{#appExeName}
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
DefaultGroupName=Stalex\MFS Apps Control
DisableProgramGroupPage=yes
LicenseFile={#outputPath}\LICENSE.txt
InfoBeforeFile={#outputPath}\RELEASENOTE.txt
PrivilegesRequiredOverridesAllowed=dialog
OutputBaseFilename=MFSAppsControlInstaller.win-x64
SetupIconFile="..\mfsappscontrol.ico"
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "armenian"; MessagesFile: "compiler:Languages\Armenian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "korean"; MessagesFile: "compiler:Languages\Korean.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "swedish"; MessagesFile: "compiler:Languages\Swedish.isl"
Name: "tamil"; MessagesFile: "compiler:Languages\Tamil.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce

[Files]
Source: "Output\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#appName}"; Filename: "{app}\{#appExeName}"
Name: "{group}\Open Flightsim.to App page"; Filename: "{#appPublishedLink}"
Name: "{group}\Open GitHub Repository"; Filename: "{#appSourceLink}"
Name: "{group}\Open a Bug Request"; Filename: "{#appSourceLink}/issues/new?template=bug-report.yml"
Name: "{group}\Open a Feature Request"; Filename: "{#appSourceLink}/issues/new?template=feature-request.yml"
Name: "{group}\{cm:UninstallProgram,{#appName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#appName}"; Filename: "{app}\{#appExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#appExeName}"; Description: "{cm:LaunchProgram,{#StringChange(appName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\Stalex\MFSAppsControl"
Type: filesandordirs; Name: "{localappdata}\Stalex\MFSAppsControl"
Type: filesandordirs; Name: "{app}"
