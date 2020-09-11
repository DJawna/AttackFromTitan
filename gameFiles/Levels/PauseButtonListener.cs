using Godot;
using System;

public class PauseButtonListener : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("pause"))
        {
            if (GetTree().Paused){
                this.Hide();
                GetTree().Paused = false;
            }else{
                
                GetTree().Paused = true;
                this.Show();
            }
            
            
        }
    }
}
