using Godot;
using System;

namespace AttackFromTitan.Core
{
    public class QuitOptionNode : Button
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {

        }

        private void _on_QuitOptionNode_button_down() {
            // Replace with function body.
            GetTree().Quit();
        }
    }
}