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

        public float Ttl {get;set;} = 1f;


        public uint Damage { get; set; }
        public Allegiance Allegiance { get; set; }

        public float Speed{get;set;} = 10f;

        public Vector2 Trajectory {get;set;} = new Vector2(0f,-1f);

        public override void _Process(float delta){
            var newPos = Position + (Trajectory * Speed * delta);
            Position = newPos;

            Ttl -= delta;
            if(Ttl <0){
                QueueFree();
            }
        }
    }
}
