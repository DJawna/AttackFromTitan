using Godot;
using System;

namespace AttackFromTitan.Core{
    public class NewMissionButton : Button
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {

        }

        private void _on_NewMissionButton_button_down() {
            GetTree().ChangeScene("res://Levels/Level1.tscn");
        }
    }
}

