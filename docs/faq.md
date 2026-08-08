# Troubleshooting (FAQ)

## Simulator detection

??? question "MSFS is not detected"
    MFSAppsControl monitors the `FlightSimulator2024.exe` (MSFS 2024)
    and `FlightSimulator.exe` (MSFS 2020) processes. Make sure the simulator is actually running.<br>
    The switch to "running" takes a few seconds after MSFS starts.

??? question "I started MFSAppsControl while MSFS was already running, and nothing happens"
    This is **intentional**. If the simulator is already there when the
    application starts, the sequence is not fired: otherwise, opening
    MFSAppsControl mid-flight would relaunch applications you don't want.

    It arms itself automatically at the next launch. In the meantime, you
    can launch an application by hand from the **⋯** menu on its card.

??? question "The SimConnect dot stays gray while MSFS is running"
    MFSAppsControl only attempts the connection **once the simulator is running**,
    then retries regularly. A few seconds' wait is normal when MSFS starts.

    If it stays gray for a long time:

    - check that the simulator has finished starting (SimConnect is only available
      once the simulator is really initialized, and during the loading screen);
    - check that no antivirus or firewall is blocking MFSAppsControl;

    After a long time with no connection while MSFS is running, the dot turns
    **red** ("SimConnect unavailable") to flag the problem.

    Without SimConnect, the "ready to fly" trigger does not work.

## Launching applications

??? question "An application doesn't launch"
    - Check that its card is not in **error** (hover the badge to read the error message).
    - Check that a **trigger** is active (:material-play: or :material-airplane:). If neither is lit, the application is never launched automatically.
    - If the trigger is **Ready to fly**, the application will only start from the "Ready to fly" screen — and only if **SimConnect is connected**.
    - If the application shows a **shield** :material-shield-alert:, it requires administrator rights (see below).
    - Use **Test** to replay the sequence without launching MSFS and watch the status of each card.

??? question "The 'ready to fly' applications never launch"
    
    In order:

    1. Is the **SimConnect connected** dot green during the flight?
    2. Is the :material-airplane: button active on the card (and not :material-play:)?
    3. Have you already flown in this session? The "ready to fly" applications only launch **once per simulator session** — they don't relaunch between two flights.

    To check everything again without flying, use the **Test** button: it simulates SimConnect after 10 seconds.

??? question "My 'ready to fly' applications start too early"
    This is the expected behavior. The trigger fires as soon as the "Ready to fly" screen appears, after loading.

    Add a **delay** on the card to push its launch back by that many seconds after this moment.

??? question "The application asks for administrator rights (UAC)"
    Some applications (Active Sky, REX Atmos…) require administrator. To launch
    them — and to **stop** them — MFSAppsControl has to be elevated. When such an
    add-on is in the active profile, the application automatically restarts as
    administrator (**a single** UAC prompt).

    **Other applications do not inherit those rights**: each one starts with what its
    own executable asks for. vPilot or Navigraph run as a normal user even when
    MFSAppsControl is elevated.

    If you decline the prompt, everything else keeps working, but those applications
    will fail with the "MFSAppsControl must be run as administrator" error.

??? question "An application launches in front of the simulator"
    Enable **Start minimized** :material-arrow-collapse: on its card: it will be
    launched in a minimized window, without coming in front of MSFS. MFSAppsControl
    also follows the windows of the application's **child processes** (some, like
    FS2Crew, open their interface through another process).

    A few rare programs with a custom window still force their window to the
    foreground. Sometimes this is an option in the application itself, sometimes an internal behavior of the application that cannot be worked around.

??? question "My applications don't close when I quit MSFS"
    Check that the **Auto stop** :material-square: button is active on their
    card — it is **independent** of auto start — and that MSFS has really closed (Task Manager).

    MFSAppsControl first asks for a **clean close**, then **force-stops** the
    processes that are still active — including some applications that keep running in the background after closing their window.

    If the application requires administrator rights, MFSAppsControl also has to be elevated to stop it (see above).

??? question "An application shows as 'RUNNING' even though I didn't launch it from MFSAppsControl"
    This is normal: MFSAppsControl regularly checks which processes are actually
    running, and **adopts** those that match your configured applications. This keeps the display accurate, whether you launch your
    applications from MFSAppsControl or by hand.

    Hover the badge to see the **PID** of the process in question.

## Interface

??? question "Why is the delay grayed out?"
    Because no **auto start** is chosen for this application. Enable :material-play: or :material-airplane: and it becomes adjustable again.

??? question "Why the padlock and the grayed-out buttons during a flight?"
    As soon as the simulator is detected, the cards' configuration and the profiles are **locked**: changing a sequence while it is running
    (or switching profiles mid-flight) would be complex to handle.

    The **⋯** menu stays available to launch or stop an application by hand.

??? question "Why can't I turn off auto stop on a 'ready to fly' application?"
    An application launched for the flight has no reason to outlive the simulator: auto stop is therefore **locked in the active position** for this trigger.<br>
    Switch the card back to **Sim start** if you want to keep it open after the flight.

??? question "How do I really quit the application when it is in the notification area?"
    If the **Closing minimizes to system tray** option is enabled, the cross hides the window instead of quitting.<br>
    **Right-click the icon** in the notification area → **Quit**.<br>
    Otherwise, just use the window's close button to quit the application.

??? question "The window opened off-screen / too small"
    MFSAppsControl remembers the window position. In case of a display issue (for example after a monitor change), move or resize the window: the new position will be remembered.<br><br>
    **Handy tip**<br>
    Use "++windows++ + left arrow" or "++windows++ + right arrow" to move it across your screens.

## Data and maintenance

??? question "Where are my profiles and settings stored?"
    In a single file:
    `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\settings.json`<br>
    (that is, `C:\Users\<you>\AppData\Local\Stalex CORP\MFSAppsControl\`).

    This file is **encrypted**: it cannot be edited directly. To back it up,
    copy it as-is.
    → [Back up your profiles](profiles.md)

??? question "Where are the logs?"
    In `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (One file per day, kept for **7 days**.)<br>
    **To send them to support:**<br>
    **Options → Debugging → Export logs**, which produces a complete `.zip` (logs + configuration). → [Support](support.md)

??? question "How do I start over from scratch?"
    **Options → Debugging → Reset the application** erases everything and returns the application to its freshly installed state.<br>
    **This action is irreversible** — copy your `settings.json` first if needed.

??? question "Can I use MFSAppsControl with MSFS 2020?"
    Yes, both versions (2024 and 2020) are supported, including the
    "ready to fly" detection. The same profile works whichever version you use.

??? question "How do I update the application?"
    When an update is available, a **badge** appears in the title
    bar. Click it to download and install the new version.<br>
    Your profiles and settings are kept.

!!! info "Still stuck?"
    Ask your question on the [**Discord**](support.md), in the dedicated
    **#mfsappscontrol** channel — attaching your exported zip.
