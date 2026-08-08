# Profiles

A **profile** groups a set of applications together with their settings.<br>
Create as many as you have use cases (online IFR flying, VFR, A320, A380…) and switch from one to another with a single click.

![Profiles](assets/profiles.png)

!!! info "The active profile is the one that drives the sequence"
    The profile **shown** is the one MFSAppsControl runs for the sequence.<br>
    The profile in use while the simulator is running is marked with a **:material-lock:{ style="color:#3ecf8e" }**.

## Creating a profile

Click the **:material-plus-circle-outline:** button to the right of the tabs.<br>
A new empty profile is created and asks you to name it.

![Creating a profile](assets/profiles-create.gif)

!!! note "Unique name and canceling"
    Two profiles cannot have the **same name**.<br>
    As long as the name you type is already in use, the field turns <span style="color:red;">**red**</span> and confirmation is blocked.<br>
    To **cancel**, click the **:material-close-circle:** cross or press **Esc**.

## Context menu

A menu is available on every profile badge, through **:material-dots-horizontal:** or a **right-click**.
It lets you **rename**, **delete** or **duplicate** the profile.

![Profile context menu](assets/profiles-menu.png)

### Duplicating a profile

To start from an existing profile without reconfiguring everything.
A copy is created with **all its applications and their settings**, named "*profile name* (copy)", ready to be renamed to a unique name.

![Duplicating a profile](assets/profiles-duplicate.gif)

### Renaming a profile

When renaming, the name has to be **unique**; confirmation stays blocked until it is.

![Renaming or deleting a profile](assets/profiles-rename.gif)
    

### Deleting a profile

Deleting a profile is **irreversible** and removes **all the applications and settings** it contains.<br>
The last remaining profile cannot be deleted.

![Deleting a profile](assets/profiles-delete.gif)

### Reordering

**Drag and drop** the badges to change their order.
This is purely visual, so you can find your favorite profiles more easily.

![Reordering profiles](assets/profiles-reorder.gif)

## Automatic locking

Profiles become **locked** (a :material-lock:{ style="color:#3ecf8e" } appears on the active profile) to prevent any change while the sequence is running.
