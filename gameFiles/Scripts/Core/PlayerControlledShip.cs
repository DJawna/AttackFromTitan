using Godot;
using System;

namespace AttackFromTitan.Core {
    public class PlayerControlledShip : KinematicBody2D {
        private Vector2 velocity = new Vector2(0, 0);


        [Export]
        public float Deceleration { get; set; } = 5f;


        [Export]
        public float Acceleration { get; set; } = 10f;

        [Export]
        public string ProjectileSceneName { get; set; }

        [Export]
        public uint Damage {get;set;}

        [Export]
        public float ProjectileCooldown { get; set; } = 0.5f;
        private float currentProjectileCooldown;

        [Signal]
        public delegate void OnDeath();

        public void EmitDeath(){
            EmitSignal(nameof(OnDeath));
        }

        private PackedScene projectileScene;
        public override void _Ready() {
            projectileScene = GD.Load<PackedScene>(ProjectileSceneName);
            if(projectileScene == null){
                throw new Exception($"Scene could not be instanced: {ProjectileSceneName}");
            }
        }

        public override void _Process(float delta) {
            currentProjectileCooldown = Math.Max(0, currentProjectileCooldown - delta);
            if (Input.IsActionPressed("primary_fire") && currentProjectileCooldown <= 0) {
                var newProjectile =(Projectile) projectileScene.Instance();
                newProjectile.Position = this.Position;
                newProjectile.Damage = Damage;
                newProjectile.Speed = 1000f;
                newProjectile.Allegiance = Allegiance.humans;
                GetParent().AddChild(newProjectile);
                currentProjectileCooldown = ProjectileCooldown;
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
            velocity.x += Math.Sign(velocity.x) * -1 * Math.Abs(velocity.x) * delta * Deceleration;
            velocity.y += Math.Sign(velocity.y) * -1 * Math.Abs(velocity.y) * delta * Deceleration;

            MoveAndSlide(velocity);
        }
    
        public override string _GetConfigurationWarning(){
            var errorString = "";
            if(string.IsNullOrEmpty(ProjectileSceneName)){
                errorString = "You need to add a projectille scene name";
            }
            return errorString;
        }
    }

}

