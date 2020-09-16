using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttackFromTitan.Core {
    public class ProjectileSpawner : Node2D {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        [Export]
        public string ProjectileSceneName {get;set;}


        [Export]
        public uint NumberOfProjectiles {get;set;} = 10;

        [Export]
        public float SpawnCooldown {get;set;} = 0.5f;
        private float currentCooldown;

        private PackedScene packedScene; 
        public override void _Ready() {
            packedScene = GD.Load<PackedScene>(ProjectileSceneName);
         }

        
        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        
        public override void _Process(float delta)
        {
            if(currentCooldown > 0){
                currentCooldown -= delta;
            }
        }

        public override string _GetConfigurationWarning() {
            if(string.IsNullOrEmpty( ProjectileSceneName)){
                return "Please set a scenename!";
            }
            return "";
        }

        public void Spawn(){
            if(currentCooldown <=0){
                AddChild(packedScene.Instance());
                currentCooldown = SpawnCooldown;
            }
        }
    }
}
