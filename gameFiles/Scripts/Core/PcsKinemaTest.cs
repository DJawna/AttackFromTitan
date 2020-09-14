using Godot;
using System;

namespace AttackFromTitan.Core {
    public class PcsKinemaTest : KinematicBody2D {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {

        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        private Vector2 velocity = new Vector2(0,0);
        private Vector2 currentDirection = new Vector2(0,0);
        public override void _PhysicsProcess(float delta) {
            
            if(Input.IsActionPressed("ui_up")){
                currentDirection = Vector2.Up;
                velocity.y += currentDirection.y * Input.GetActionStrength("ui_up") * 10;
            }

            velocity.y +=  1f;
            velocity.y = Math.Min(0,velocity.y);

            MoveAndCollide(velocity);

        }
    }
}
