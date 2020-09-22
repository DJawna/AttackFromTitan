using Godot;
using System;

namespace AttackFromTitan.Core {
    public class Projectile : Area2D, DoesDamage {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public override void _Ready() {

        }

        float ttl = 1f;


        public uint Damage { get; set; }
        public Allegiance Allegiance { get; set; }

        public override void _PhysicsProcess(float delta){
            var newPos = new Vector2(Position.x, Position.y - 10);
            Position = newPos;

            ttl -= delta;
            if(ttl <0){
                QueueFree();
            }
        }
    }
}
