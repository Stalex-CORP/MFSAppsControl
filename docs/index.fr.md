# MFSAppsControl

## Description

**MFSAppsControl** est une application permettant de **lancer et/ou arrêter** des applications tierces en surveillant l'état de Microsoft Flight Simulator 2024/2020.<br>
Plus besoin de lancer vos applications une par une avant chaque vol : configurez-les une fois, MFSAppsControl s'occupe de tout.

![L'écran principal de MFSAppsControl](assets/main-screen.png)

## Comment ça marche

MFSAppsControl suit votre vol de bout en bout, en **trois temps** :

::timeline::

- title: Lancement du simulateur
  content: Les applications configurées sur **Démarrage sim** démarrent dès le lancement du simulateur, en suivant leur délai défini.
  icon: ' :material-numeric-1: '

- title: Ecran "Prêt à voler"
  content: Les applications configurées sur **Prêt à voler** démarrent dès l'apparition du bouton \"Prêt à voler\", en suivant leur délai défini.
  icon: ' :material-numeric-2: '

- title: Arrêt du simulateur
  content: Les applications configurées sur **Arrêt auto** se ferment proprement à la fermeture du simulateur.
  icon: ' :material-numeric-3: '

::/timeline::


**La différence entre les deux types de démarrage est au cœur de l'application :**<br>
Certaines applications peuvent :

- Être démarrées **dès le démarrage** du simulateur (ex: Navigraph, Volanta…)
- Avoir des restrictions/ne ne sont utiles que **durant un vol** (ex: Rex Atmos, FS2Crew…)

Vous devez choisir ce qui correspond le mieux à l'application. → [Applications & séquence](applications.md#les-deux-declencheurs-de-demarrage)

## Les fonctionnalités

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Séquence automatique**</span><br>
  Chaque application démarre selon son déclencheur après son délai défini, visualisé directement sur la timeline pour l'ordre de lancement.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Profils**</span><br>
  Regroupez vos applications par usage (A320, VFR, Cargo…) et basculez en un clic. Le profil affiché est le profil actif.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Discret**</span><br>
  Peut être réduit dans la zone de notification, et se lancer avec Windows pour être prêt à tout instant sur vos prochains vols sans y penser.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Interface complète multilingue**</span><br>
  Traduit entièrement en Français, Anglais, Allemand, Espagnol, Italien et Portugais avec changement en direct et persistance dans la configuration.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Applications administrateur**</span><br>
  Détectées automatiquement lors de l'ajout, avec une invite Windows. Seuls les applications nécessitant des privilèges administratifs utiliseront le mode administrateur.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Mode test**</span><br>
  Jouez toute la séquence (déclencheur « prêt à voler » compris) sans lancer le simulateur afin de vérifier vos profils.

</div>

## Par où commencer ?

1. [**Installation**](installation.md) — télécharger et installer l'application.
2. [**Prise en main**](getting-started.md) — configurez votre première séquence.
3. [**Applications & séquence**](applications.md) — le détail des différentes parties de l'application.
4. [**Profils**](profiles.md) et [**Options**](options.md) — gérez vos profils et réglages.
5. [**FAQ**](faq.md) — les questions les plus fréquentes.
6. [**Support**](support.md) — pour les besoins d'assistance.
