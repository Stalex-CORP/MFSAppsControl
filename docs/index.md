# MFSAppsControl

## Description

**MFSAppsControl** is an application that **starts and/or stops** third-party applications by monitoring the state of Microsoft Flight Simulator 2024/2020.<br>
No more launching your applications one by one before every flight: set them up once, and MFSAppsControl takes care of everything.

![The MFSAppsControl main screen](assets/main-screen.png)

## How it works

MFSAppsControl follows your flight from end to end, in **three stages**:

::timeline::

- title: Simulator launch
  content: Applications set to **Sim start** launch as soon as the simulator starts, following their defined delay.
  icon: ' :material-numeric-1: '

- title: The "Ready to fly" screen
  content: Applications set to **Ready to fly** launch as soon as the \"Ready to fly\" button appears, following their defined delay.
  icon: ' :material-numeric-2: '

- title: Simulator shutdown
  content: Applications set to **Auto stop** close cleanly when the simulator quits.
  icon: ' :material-numeric-3: '

::/timeline::


**The difference between the two start types is at the heart of the application:**<br>
Some applications can:

- Be started **as soon as** the simulator starts (e.g. Navigraph, Volanta…)
- Have constraints, or only be useful **during a flight** (e.g. REX Atmos, FS2Crew…)

You choose whichever suits the application best. → [Applications & sequence](applications.md#the-two-start-triggers)

## Features

<div class="grid cards" markdown>

- <span style="color: var(--md-accent-fg-color)">:material-rocket-launch: **Automatic sequence**</span><br>
  Each application starts on its trigger after its defined delay, shown directly on the timeline so you can follow the launch order.

- <span style="color: var(--md-accent-fg-color)">:material-folder-multiple: **Profiles**</span><br>
  Group your applications by use case (A320, VFR, cargo…) and switch with one click. The profile shown is the active one.

- <span style="color: var(--md-accent-fg-color)">:material-tray-arrow-down: **Unobtrusive**</span><br>
  Can be minimized to the notification area and launched with Windows, so it is ready at any time for your next flights without a second thought.

- <span style="color: var(--md-accent-fg-color)">:material-translate: **Fully multilingual interface**</span><br>
  Fully translated into French, English, German, Spanish, Italian and Portuguese, with live switching and persistence in the configuration.

- <span style="color: var(--md-accent-fg-color)">:material-shield-check: **Administrator applications**</span><br>
  Detected automatically when added, with a Windows prompt. Only the applications that require administrator privileges will use administrator mode.

- <span style="color: var(--md-accent-fg-color)">:material-flask: **Test mode**</span><br>
  Play the whole sequence (including the "ready to fly" trigger) without launching the simulator, to check your profiles.

</div>

## Where to start?

1. [**Installation**](installation.md) — download and install the application.
2. [**Getting started**](getting-started.md) — set up your first sequence.
3. [**Applications & sequence**](applications.md) — the details of every part of the application.
4. [**Profiles**](profiles.md) and [**Options**](options.md) — manage your profiles and settings.
5. [**FAQ**](faq.md) — the most frequently asked questions.
6. [**Support**](support.md) — when you need help.
