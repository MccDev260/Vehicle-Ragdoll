using System;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.UI;

namespace VehicleRagdoll
{
    public class VehicleRagdoll : Script
    {
        private bool first_time = true;
        private bool mod_active = false;
        private float forward_force, reverse_force, left_force, right_force, up_force, down_force;
        private Keys forward_key, reverse_key, left_key, right_key, up_key, down_key, mod_toggle_key;

        public VehicleRagdoll()
        {
            this.Tick += onTick;
            this.KeyDown += onKeyDown;

            // Get users values from ini
            ScriptSettings config = ScriptSettings.Load("scripts\\VehicleRagdoll.ini");
            // Force:
            forward_force = config.GetValue<float>("Force Strength Settings", "Forward", 100f);
            reverse_force = config.GetValue<float>("Force Strength Settings", "Reverse", 100f);
            left_force = config.GetValue<float>("Force Strength Settings", "Left", 100f);
            right_force = config.GetValue<float>("Force Strength Settings", "Right", 100f);
            up_force = config.GetValue<float>("Force Strength Settings", "Up", 50f);
            down_force = config.GetValue<float>("Force Strength Settings", "Down", 50f);
            // Keys:
            mod_toggle_key = config.GetValue<Keys>("Key Binding", "Mod_Toggle_key", Keys.NumPad7);
            forward_key = config.GetValue<Keys>("Key Binding", "Forward_key", Keys.NumPad8);
            reverse_key = config.GetValue<Keys>("Key Binding", "Reverse_key", Keys.NumPad2);
            left_key = config.GetValue<Keys>("Key Binding", "Left_key", Keys.NumPad4);
            right_key = config.GetValue<Keys>("Key Binding", "Right_key", Keys.NumPad6);
            up_key = config.GetValue<Keys>("Key Binding", "Up_key", Keys.NumPad9);
            down_key = config.GetValue<Keys>("Key Binding", "Down_key", Keys.NumPad3);
        }

        private void onTick(object sender, EventArgs e)
        {
            string mod_name = "Vehicle Ragdoll";
            string developer = "MccDev260";

            if (first_time)
            {
                Notification.Show(mod_name + " by " + developer + " Loaded");
                first_time = false;
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == mod_toggle_key)
            {
                mod_active = !mod_active;

                if (mod_active)
                {
                    Notification.Show("Vehicle Ragdoll Activated!!", true);
                }

                else if (!mod_active)
                {
                    Notification.Show("Vehicle Ragdoll De-activated!!", true);
                }
            }

            if (mod_active)
            {
                try
                {
                    Vehicle player_vehicle = Game.Player.Character.CurrentVehicle;

                    if(e.KeyCode == forward_key)
                    {
                        player_vehicle.ApplyForceRelative(new Vector3(0f, forward_force, 0f));
                    }
                    if(e.KeyCode == reverse_key)
                    {
                        player_vehicle.ApplyForceRelative(new Vector3(0f, -reverse_force, 0f));
                    }
                    if(e.KeyCode == left_key)
                    {
                        player_vehicle.ApplyForceRelative(new Vector3(-left_force, 0f, 0f));
                    }
                    if(e.KeyCode == right_key)
                    {
                        player_vehicle.ApplyForceRelative(new Vector3(right_force, 0f, 0f));
                    }
                    if(e.KeyCode == up_key)
                    {
                        player_vehicle.ApplyForce(new Vector3(0f, 0f, up_force));
                    }
                    if(e.KeyCode == down_key)
                    {
                        player_vehicle.ApplyForce(new Vector3(0f, 0f, -down_force));
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
        }
    }
}