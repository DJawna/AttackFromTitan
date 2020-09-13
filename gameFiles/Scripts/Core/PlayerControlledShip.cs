using Godot;
using System;

namespace AttackFromTitan.Core
{
    public class PlayerControlledShip : Area2D
    {
        private Vector2 velocity = new Vector2(0, 0);


        /// <summary>
        /// MaxSpeed the ship can have   
        /// </summary>
        /// <value>m*s^2 min value: 0</value>
        [Export]
        public float MaxSpeed { get; set; } = 666f;

        


        private float currentAcceleration;

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.

        public override void _Process(float delta) {
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
            velocity.x += direction.x * currentStrength * 5;
            velocity.y += direction.y * currentStrength * 5;

            // decelerate according to "friction"
            velocity.x += Math.Sign(velocity.x) * -1 * Math.Abs(velocity.x) * 0.8f * delta;
            velocity.y += Math.Sign(velocity.y) * -1 * Math.Abs(velocity.y) * 0.8f * delta;

/*
            if(currentStrength == 0f){
                accelerate(directionVector,delta,currentStrength,currentAcceleration );
            }else{
                accelerate(currentDirection, delta,currentStrength, currentAcceleration);
            }
*/
            // multiply by -1 in order to invert the direction of the movement:
            //velocity.x = Math.Max(0, velocity.x + (velocity.x * -1 * Deceleration * delta));
            //velocity.y = Math.Max(0, velocity.y + (velocity.y * -1 * Deceleration * delta));
            
            var newPosition = new Vector2();
            newPosition.x = Position.x + (velocity.x * delta);
            newPosition.y = Position.y + (velocity.y * delta);
            this.Position = newPosition;
        }
    }

}

