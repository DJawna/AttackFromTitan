using Godot;
using System;

namespace AttackFromTitan.Core
{
    public class PlayerControlledShip : KinematicBody2D
    {
        private Vector2 velocity = new Vector2(0, 0);


        [Export]
        public float Deceleration { get; set; } = 5f;


        [Export]
        public float Acceleration { get; set; } = 10f;

        

        


        //  // Called every frame. 'delta' is the elapsed time since the previous frame.

        public override void _PhysicsProcess(float delta) {
            var direction = new Vector2(0f,0f);
            var currentStrength =0f;            
            if (Input.IsActionPressed("ui_up"))
            {
                direction.x = Vector2.Up.x;
                direction.y = Vector2.Up.y;

                currentStrength = Input.GetActionStrength("ui_up");
            }
            if (Input.IsActionPressed("ui_down"))
            {
                direction.x = Vector2.Down.x;
                direction.y = Vector2.Down.y;

                currentStrength = Input.GetActionStrength("ui_down");
            }
            if (Input.IsActionPressed("ui_right"))
            {
                direction.x = Vector2.Right.x;
                direction.y = Vector2.Right.y;

                currentStrength = Input.GetActionStrength("ui_right");
            }
            if (Input.IsActionPressed("ui_left"))
            {
                direction.x = Vector2.Left.x;
                direction.y = Vector2.Left.y;

                currentStrength = Input.GetActionStrength("ui_left");
            }

            // accelerate according to input
            velocity.x += direction.x * currentStrength * Acceleration;
            velocity.y += direction.y * currentStrength * Acceleration;



            // decelerate according to "friction"
            velocity.x += Math.Sign(velocity.x) * -1 * Math.Abs(velocity.x) * delta * Deceleration;
            velocity.y += Math.Sign(velocity.y) * -1 * Math.Abs(velocity.y) * delta * Deceleration;

            
            MoveAndCollide(velocity * delta);
        }
    }

}

