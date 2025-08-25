#define appName "MFS Apps Control"
#define appVersion "1.2"
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
PrivilegesRequired=lowest
OutputBaseFilename=MFSAppsControl-Installer
SetupIconFile="..\mfsappscontrol.ico"
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
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
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[CustomMessages]
english.AutoStartWithWindows=Start %1 with Windows
brazilianportuguese.AutoStartWithWindows=Iniciar %1 com o Windows
bulgarian.AutoStartWithWindows=Стартиране на %1 с Windows
catalan.AutoStartWithWindows=Iniciar %1 amb Windows
czech.AutoStartWithWindows=Spustit %1 s Windows
danish.AutoStartWithWindows=Start %1 med Windows
dutch.AutoStartWithWindows=%1 starten met Windows
finnish.AutoStartWithWindows=Käynnistä %1 Windowsin kanssa
french.AutoStartWithWindows=Démarrer %1 avec Windows
german.AutoStartWithWindows=%1 mit Windows starten
hungarian.AutoStartWithWindows=Indítsa el a(z) %1-t Windows-szal
italian.AutoStartWithWindows=Avvia %1 con Windows
japanese.AutoStartWithWindows=Windowsで%1を起動する
korean.AutoStartWithWindows=Windows와 함께 %1 시작
norwegian.AutoStartWithWindows=Start %1 med Windows
polish.AutoStartWithWindows=Uruchom %1 z systemem Windows
portuguese.AutoStartWithWindows=Iniciar %1 com o Windows
russian.AutoStartWithWindows=Запустить %1 с Windows
slovak.AutoStartWithWindows=Spustiť %1 s Windows
slovenian.AutoStartWithWindows=Zaženi %1 z Windows
spanish.AutoStartWithWindows=Iniciar %1 con Windows
swedish.AutoStartWithWindows=Starta %1 med Windows
turkish.AutoStartWithWindows=%1'i Windows ile başlat
ukrainian.AutoStartWithWindows=Запустить %1 вместе с Windows

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkedonce
Name: "startwithwindows"; Description: "{cm:AutoStartWithWindows,{#appName}}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "bin\Publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#appName}"; Filename: "{app}\{#appExeName}"
Name: "{group}\Open Flightsim.to App page"; Filename: "{#appPublishedLink}"
Name: "{group}\Open GitHub Repository"; Filename: "{#appSourceLink}"
Name: "{group}\Open a Bug Request"; Filename: "{#appSourceLink}/issues/new?template=bug-report.yml"
Name: "{group}\Open a Feature Request"; Filename: "{#appSourceLink}/issues/new?template=feature-request.yml"
Name: "{group}\{cm:UninstallProgram,{#appName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#appName}"; Filename: "{app}\{#appExeName}"; Tasks: desktopicon
Name: "{autostartup}\{#appName}"; Filename: "{app}\{#appExeName}"; Tasks: startwithwindows

[Run]
Filename: "{app}\{#appExeName}"; Description: "{cm:LaunchProgram,{#StringChange(appName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}"
