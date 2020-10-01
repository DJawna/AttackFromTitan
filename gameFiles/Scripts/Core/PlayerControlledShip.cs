using System;
using Godot;

namespace AttackFromTitan.Core {
    public class PlayerControlledShip : KinematicBody2D {
        private Vector2 velocity = new Vector2(0, 0);

        [Export]
        public float Deceleration { get; set; } = 5f;

        [Export]
        public float Acceleration { get; set; } = 10f;


        [Signal]
        public delegate void OnDeath();

        [Signal]
        public delegate void ToggleFire(bool toggle);

        public void EmitDeath(){
            QueueFree();
            EmitSignal(nameof(OnDeath));
        }

        private PackedScene projectileScene;
        public override void _Ready() {
        }

        public override void _Process(float delta) {
            if (Input.IsActionPressed("primary_fire")) {
                EmitSignal(nameof(ToggleFire), true);
            }

            if (Input.IsActionJustReleased("primary_fire")){
                EmitSignal(nameof(ToggleFire), false);
            }
        }

        public override void _PhysicsProcess(float delta) {
            var direction = new Vector2(0f, 0f);
            var currentStrength = 0f;
            if (Input.IsActionPressed("ui_up")) {
                direction.x = Vector2.Up.x;
                direction.y = Vector2.Up.y;

                currentStrength = Input.GetActionStrength("ui_up");
            }
            if (Input.IsActionPressed("ui_down")) {
                direction.x += Vector2.Down.x;
                direction.y += Vector2.Down.y;

                currentStrength = Input.GetActionStrength("ui_down");
            }
            if (Input.IsActionPressed("ui_right")) {
                direction.x += Vector2.Right.x;
                direction.y += Vector2.Right.y;

                currentStrength = Input.GetActionStrength("ui_right");
            }
            if (Input.IsActionPressed("ui_left")) {
                direction.x += Vector2.Left.x;
                direction.y += Vector2.Left.y;

                currentStrength = Input.GetActionStrength("ui_left");
            }

            // accelerate according to input
            velocity.x += direction.x * currentStrength * Acceleration;
            velocity.y += direction.y * currentStrength * Acceleration;



            // decelerate according to "friction"
            velocity.x += Mathf.Sign(velocity.x) * -1 * Mathf.Abs(velocity.x) * delta * Deceleration;
            velocity.y += Mathf.Sign(velocity.y) * -1 * Mathf.Abs(velocity.y) * delta * Deceleration;

            MoveAndSlide(velocity);
        }
    }

}

