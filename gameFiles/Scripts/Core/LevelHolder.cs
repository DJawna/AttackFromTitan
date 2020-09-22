using System;
using Godot;

namespace AttackFromTitan.Core {
    class LevelHolder: Node{

        
        private PackedScene level;
        private Node levelInstance;

        [Export]
        public string LevelName{get;set;}

        public override void _Ready() {
            level = GD.Load<PackedScene>($"res://Levels/{LevelName}.tscn");
            if(level == null){
                throw new Exception($"Scene could not be instanced: {LevelName}");
            }
            ResetLevel();
        }


        public void ResetLevel(){
            if(levelInstance != null){
                levelInstance.QueueFree();
            }
            levelInstance = level.Instance();
            levelInstance.Connect("OnGameOver",this,"ResetLevel");
            AddChild(levelInstance);

        }


    }
}