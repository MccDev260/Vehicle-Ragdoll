# Vehicle Ragdoll Mod by MccDev260 v1.0.1

## Description:
GTA-V script built with Script Hook V Dot Net API which lets you launch any vehicle you're driving in whichever direction you want at insane speeds!

---

## Requirements:
- Grand Theft Auto V (PC)
- ScriptHookV
- ScriptHookVDotNet

---

## Installation:
1. Navigate to your GTA V folder.
2. Copy the VehicleRagdoll script into your scripts folder.

---

## Known issues:

- Failure to compile due to issues with GTA.UI.Notification.

There are two fixes to this problem:
### **Fix one:**
Remove ScriptHookVDotNet2.dll from your game files.

If this isn't appropriate for you because of other mods dependency on DotNet2, then the second fix below should work for you:

### **Fix Two:**
Change every occurrence of:

        ...

        GTA.UI.Notification.Show(//message);

        ...

to

        ...

        GTA.UI.Notify(//message);

        ...


---

## Default Keybinding:
**Num Pad 7**: Toggle Activating / Deactivating script.

**Num Pad 8**: Accelerate at the speed of yeet.

**Num Pad 2**: Reverse at Mach 10.

**Num Pad 4**: Propel to the left.

**Num Pad 6**: Go very fast right.

**Num Pad 9**: Launch into the stratosphere.

**Num Pad 3**: Slam into the ground.

---

## Editing the script:
*You can either edit the script directly using an editor (notepad++, Visual Studio Code etc) or you can clone the entire project repo from [here](https://github.com/MccDev260/Vehicle-Ragdoll) and open it in Visual Studio.*

### Change the force applied to the vehicle:
Find and edit the float variables below in the script to alter the force applied to the vehicle on the relevant axis. (Higher the number, the more force is applied)

        . . .

        // Set force for forward, back, left and right
        float force_x_y = 100f;

        // Set force for up and down
        float force_z = 50f;

        . . .

### Editing the Keybindings:
Find the switch statement near the bottom of the script:

        . . .

        switch (e.KeyCode)
        {
            // Forward
            case Keys.NumPad8:
                player_vehicle.ApplyForceRelative(new Vector3(0f, force_x_y, 0f));
                break;
            // Reverse
            case Keys.NumPad2:
                player_vehicle.ApplyForceRelative(new Vector3(0f, -force_x_y, 0f));
                break;
        . . .

Choose the direction you would like to bind to a different key and edit it by changing the case expression to your desired key:

        . . .

        switch (e.KeyCode)
        {
            // Forward
            case Keys.I:
                player_vehicle.ApplyForceRelative(new Vector3(0f, force_x_y, 0f));
                break;
            // Reverse
            case Keys.K:
                player_vehicle.ApplyForceRelative(new Vector3(0f, -force_x_y, 0f));
                break;
        . . .


---

## Licence:

Feel free to use and edit how ever you would like. If you publish anything using this script as a base or reference, please credit!
