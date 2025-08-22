<!-- Badges -->
<p align="center">
  <img src="https://img.shields.io/badge/license-MIT-green" alt="License" />
  <img src="https://img.shields.io/badge/compatibility-Windows%20(64bits)-blue" alt="Windows (64bits)" />
  <img src="https://img.shields.io/badge/.NET-9.0-blueviolet" alt=".NET 9.0" />
  <img src="https://img.shields.io/badge/WPF-WPF%20UI-orange" alt="WPF UI" />
</p>
<p align="center">
  <img alt="GitHub forks" src="https://img.shields.io/github/forks/Stalex-CORP/MFSAppsControl?style=flat&color=white">
  <img alt="GitHub Repo stars" src="https://img.shields.io/github/stars/Stalex-CORP/MFSAppsControl?style=flat&color=white">  
  <img alt="GitHub watchers" src="https://img.shields.io/github/watchers/Stalex-CORP/MFSAppsControl?style=flat&color=white">
</p>
<p align="center">
  <img alt="GitHub Tag" src="https://img.shields.io/github/v/tag/Stalex-CORP/MFSAppsControl">
  <img alt="GitHub Actions Workflow Status" src="https://img.shields.io/github/actions/workflow/status/Stalex-CORP/MFSAppsControl/release.yml">
  <img src="https://img.shields.io/badge/Pull%20Requests-open-green" alt="PRs Welcome" />
</p>

<img src="../MFSAppsControl_banner.png" width="50%" />

_MFS Apps Control est une application Windows avec une interface graphique permettant de définir une liste d'application à lancer et/ou arrêter en même temps de Microsoft Flight Simulator et tout cela dans une interface moderne._\
_Bien qu'il soit possible de démarrer des applications via le exe.xml, mais la plupart resteront ouverte à la fermeture de MFS car ils ne suivent pas l'état de MFS. C'est pourquoi, cette utilitaire le fera automatiquement et de manière plus optimisée et plus facile à configurer._

- [Installation \& Utilisation](#installation--utilisation)
  - [Compatibilité](#compatibilité)
  - [Installation](#installation)
  - [Lancement](#lancement)
  - [Utilisation](#utilisation)
- [Développeurs](#développeurs)
  - [Prérequis](#prérequis)
  - [Stack](#stack)
  - [Structure du projet](#structure-du-projet)
  - [Initialiser l'environnement](#initialiser-lenvironnement)
    - [1. Fork \& Clone](#1-fork--clone)
    - [2. Création d'une branche dédiée](#2-création-dune-branche-dédiée)
    - [3. Conventions](#3-conventions)
    - [4. Ecrire et Exécuter les tests unitaires](#4-ecrire-et-exécuter-les-tests-unitaires)
    - [5. Soumettre une Merge Request](#5-soumettre-une-merge-request)
- [Licence](#licence)
- [Contact](#contact)

## Installation & Utilisation

### Compatibilité

- Windows 10/11 64 Bits (à jour)
- Microsoft Flight Simulator 2020/2024

### Installation

- Télécharger la dernière [Release](https://github.com/Stalex-CORP/MFSAppsControl/releases)
- Lancer le setup présent dans l'archive
  > [!Note]
  > En tant que développeur occasionnel, je ne dispose pas d'un certificat pour signer l'installeur (qui est coûteux et nécessite une cotisation annuelle), ce qui vous avertira qu'il ne provient pas d'un éditeur fiable. Microsoft a confirmé qu'il ne contient aucun virus et que l'installeur et l'application devraient désormais être ajoutés à la liste blanche sans détection de faux positif le 20/08/2025, mais il est nécessaire d'avoir votre Windows Defender à jour.
  >
  > Tout le code source est visible ici avec le fichier utilisé pour générer l'application & l'installeur par un workflow automatisé Github.

### Lancement

Une fois installée, l'application sera présente dans votre menu démarrer dans le dossier **Stalex** sous le nom **MFS Apps Control**.

### Utilisation

Une fois lancée:

1. Accéder à la page d'ajout application en cliquant sur <img src="./images/button_add.png" height="24">.

   La liste est générée à partir des applications installées sur votre système avec des exclusions connues (Microsoft, NVidia, etc...),

   mais vous pouvez ajouter une application ou un script (powershell, python, cmd) en cliquant sur <img src="./images/button_browse.png" height="24">

2. Renseigner des arguments au lancement de l'application/script si nécessaire et cliquer sur <img src="./images/button_addselected.png" height="24">
3. Configurer les options de l'application ajoutée pour définir du lancement et/ou arrêt automatique avec MFS.

   Un mode simulation est diisponible pour simuler le lancement & arrêt de MFS sans devoir le lancer avec <img src="./images/button_start.png" height="24"> & <img src="./images/button_stop.png" height="24">.

4. Minimiser la fenêtre qui laissera l'application dans les icones de barre de notification.
   > [!Tip]
   > L'application fonctionnera en arrière plan pour réaliser ses tâches de lancement/arrêt.
   >
   > Même si vous avez lancé une application en dehors de l'application, elle sera capable de la fermer si vous avez défini l'option.

## Développeurs

Merci de votre intérêt de vouloir contribuer !

> [!CAUTION]
> Je ne suis pas un développeur professionnel, mais j'ai créé ce projet pour pratiquer C# et WPF avec du vibe coding et parce que j'en avais besoin.
>
> Il nécessite des améliorations et des refactorisations, mais il fonctionne.
>
> Si vous souhaitez aider à optimiser et réorganiser, n'hésitez pas à fork le projet et à soumettre une pull request.

### Prérequis

- [.NET SDK X64 9.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio Desktop Development](https://visualstudio.microsoft.com/fr/)
- Windows 10/11 64 Bits à jour (Incompatible Linux)
- **De bonnes connaissances en C#, MVVM, WPF à minima**

### Stack

- **C#** (.NET 9.0)
- **WPF**
- **WPF UI** (https://wpfui.lepo.co/)
- **log4net** (https://logging.apache.org/log4net/)
- **Inno Setup** (https://jrsoftware.org/isinfo.php)
- **Microsoft.Toolkit.Uwp.Notifications**
- **Automatic Versions 2 VS Tools** (https://marketplace.visualstudio.com/items?itemName=PrecisionInfinity.AutomaticVersions)

### Structure du projet

```
.github/                                           # Dossier pour la configuration GitHub (workflows, templates, etc.)

Docs/
│
├── images/                                         # images pour les fichiers readme
│   └── ...png
├── MFSAppsControl_UserManual.pdf                   # PDF Manuel Utilisateur de l'application
├── README-english.md                               # Documentation détaillée (anglais)
└── README-french.md                                # Documentation détaillée (français)

MFSAppsControl/
│
├── Converters/                                     # Utilitaires de conversion pour le binding WPF
│   ├── CollectionLogConverter.cs                   # Convertit un objet en une chaîne de log
│   └── ExeIconToImageSourceConverter.cs            # Convertit une icône d'exécutable en ImageSource pour l'affichage
│
├── Models/                                         # Modèles de données utilisés dans l'application
│   └── ApplicationModel.cs                         # Représente une application avec ses propriétés (nom, chemin, arguments, etc.)
│   └── AppConfigModel.cs                           # Représente une collection des applications configurées
│
├── Services/                                       # Services applicatifs (logique métier, accès système, etc.)
│   ├── AppConfigService.cs                         # Service pour gérer la configuration de l'application
│   ├── ConfigurationService.cs                     # Service pour gérer la configuration json de l'application
│   ├── LanguageService.cs                          # Gestion de la langue et des traductions
│   ├── LoggerService.cs                            # Service de log pour l'application
│   ├── MFSEventWatcher.cs                          # Service pour surveiller les événements de Microsoft Flight Simulator
│   └── NotificationService.cs                      # Service pour les notifications système de l'application
│
├── ViewModels/                                     # Logique applicative MVVM (ViewModels)
│   ├── Pages/
│   │   ├── ConfigAppsViewModel.cs                  # Code appli pour la gestion de la liste des applications
│   │   └── AddAppViewModel.cs                      # Code appli pour l'ajout d'une nouvelle application
│   └── Windows/
│       └── MainWindowViewModel.cs                  # Code appli principal de la fenêtre principale
│
├── Views/                                          # Vues XAML (UI)
│   ├── Pages/
│   │   ├── ConfigAppsPage.xaml                     # Page affichant la liste des applications avec leur configuration
│   │   ├── ConfigAppsPage.xaml.cs                  # Code vue de ConfigAppsPage.xaml
│   │   ├── AddAppPage.xaml                         # Page pour ajouter une nouvelle application
│   │   └── AddAppPage.xaml.cs                      # Code vue de AddAppPage.xaml
│   └── Windows/
│       ├── MainWindow.xaml                         # Fenêtre principale de l'application
│       └── MainWindow.xaml.cs                      # Code vue de MainWindow.xaml
│
├── App.xaml                                        # Définition racine de l'application WPF (ressources globales)
├── App.xaml.cs                                     # Logique d'initialisation de l'application
├── AssemblyInfo.cs                                 # Informations d'assemblage .NET
├── ExcludedVendors.json                            # Liste des applications à exclure de la détection automatique
├── log4net.config                                  # Configuration du logger log4net
├── MFSAppsControl.csproj                           # Fichier projet App .NET (configuration du build)
├── mfsappscontrol.iss                              # Script Inno Setup pour générer l'installeur Windows
└── Usings.cs                                       # Imports globaux pour simplifier les fichiers C#

MFSAppsControlTests/
│
├── Mocks/
│   ├── MockLoggerService.cs                        # Mock de Logger Service pour créer les view models dans les tests
│   └── MockSnakbarService.cs                       # Mock de Snackbar Service pour créer les view models dans les tests
│
├── AddAppViewModelTests.cs                         # Tests unitaires de AddAppViewModel
├── ConfigAppsViewModelTests.cs                     # Tests unitaires de ConfigAppsViewModel
├── MFSAppsControlTests.csproj                      # Fichier projet Test .NET (configuration du build)
└── MSTestSettings.cs                               # .NET project settings

.gitignore
CHANGELOG.md                                        # Changelog détaillé des versions
LICENSE.txt                                         # Licence du projet (MIT)
mfsappscontrol.ico                                  # Icône de l'application, de l'installeur et du readme
MFSAppsControl.sln                                  # Solution Visual Studio (regroupe tous les projets)
preview-en.png                                      # Preview english capture of app for readme
preview-fr.png                                      # Preview french capture of app for readme
README.md                                           # Documentation principale (redirection vers les sous versions)
```

### Initialiser l'environnement

#### 1. Fork & Clone

```bash
git fork https://github.com/votre-utilisateur/mfsapplinker.git
git clone https://github.com/votre-utilisateur/mfsapplinker.git
```

#### 2. Création d'une branche dédiée

- Nouvelle Feature

  ```bash
  git checkout -b feature/nom
  ```

- Correction de bug
  ```bash
  git checkout -b fix/nom
  ```

#### 3. Conventions

- Respecter la structure du projet (hors refactorisation nécessaire).
- Toujours documenter le code.
- Tester que l'application s'éxecute bien sans erreurs/warnings.
- Suivre les règles du linter pour respecter les standards.
- Utilisation de MVVM, DataContext, RelayCommands, etc...
- Respecter les conventions des commits:
- Utilisez des noms de branches explicites : **feature/** ou **fix/**
- Commits clairs et concis (en anglais) en respectant au possible les conventions:
  - Un commit par changement (éviter les gros commits)
  - Un emoji lié au type de changements au début du commit suivi d'un espace (voir le bloc Tip)
  - Un message clair du changement avec verbe et sujet (voir le bloc Tip)
    > [!TIP]
    > Convention git message: https://www.conventionalcommits.org/en/v1.0.0/#summary
    >
    > Extension emoji recommandée: https://marketplace.visualstudio.com/items?itemName=seatonjiang.gitmoji-vscode

#### 4. Ecrire et Exécuter les tests unitaires

- Si nouvelle fonctionnalité, il faut créer le test au possible
- Ils doivent tous être vert, sinon c'est qu'il y a une régression.

#### 5. Soumettre une Merge Request

- Décrire précisément les changements.
- Lier les issues concernées si besoin.
- Vérifier que le build passe sans erreur.

## Licence

Ce projet est sous licence MIT. Voir [LICENSE](LICENSE).

## Contact

Pour toute question ou suggestion :

Issues GitHub https://github.com/Stalex-CORP/MFSAppsControl/issues
