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
    3. Have you already flown in this session? The "ready to fly" applications only launch **once per simulator session** — they don't relaunch between two flights, unless you change profile.

    They launch as soon as the "Ready to fly" screen appears, after loading. To launch one later, add a **delay** on its card.

    To check everything again without flying, use the **Test** button: it simulates SimConnect after 10 seconds.

??? question "The application asks for administrator rights (UAC)"
    Some applications (Active Sky, REX Atmos…) require administrator. To launch
    them — and to **stop** them — MFSAppsControl has to be elevated. When such an
    add-on is in Shared or in **any** of your profiles, the application restarts as
    administrator at startup (**a single** UAC prompt), so that changing profile never
    needs a restart mid-session.

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

??? question "Nothing launches or stops with the simulator any more"
    The **automatic sequence** is probably switched off: the **Auto sequence** switch above **Test** is gray, and the notification area icon shows a **red** dot.<br>
    Turn it back on from the switch or from the icon's menu. While it is off, nothing is launched or stopped with the simulator, and no profile is activated by an aircraft.

??? question "My profile does not switch with the aircraft"
    - Check that the aircraft is **linked** to the profile: its name in the banner shows a green link icon.
    - The switch happens **when the flight loads**, not while you browse aircraft at the main menu.
    - The **automatic sequence** must be on.
    - The simulator sometimes loads a flight **without the aircraft**: reload the flight, and the switch happens at that load.

??? question "A 'While MSFS is closed' application does not close or launch"
    - The **automatic sequence** must be on.
    - Check that **Close at start** or **Launch at exit** is on, on its card.
    - It closes when MSFS **starts** while MFSAppsControl is already running: nothing is closed for a simulator that was already running.
    - It launches once MSFS has **closed** and the session's applications have stopped, then after its delay: its card counts down meanwhile.

## Data and maintenance

??? question "How do I really quit the application when it is in the notification area?"
    If the **Closing minimizes to system tray** option is enabled, the cross hides the window instead of quitting.<br>
    **Right-click the icon** in the notification area → **Quit**.<br>
    Otherwise, just use the window's close button to quit the application.

??? question "Where are the logs?"
    In `%LOCALAPPDATA%\Stalex CORP\MFSAppsControl\logs`. (One file per day, kept for **7 days**.)<br>
    **To send them to support:**<br>
    **Options → Debugging → Export logs**, which produces a complete `.zip` (logs + configuration). → [Support](support.md)

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
