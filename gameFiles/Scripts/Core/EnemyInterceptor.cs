using Godot;

namespace AttackFromTitan.Core {

    class EnemyInterceptor : Area2D{
        private PackedScene projectile;

        [Export]
        public string ProjectileSceneName {get;set;}

        [Export]
        public float AttackCooldown {get;set;}

        private float currentCoolDown  {get;set;}

        public override void _Ready() {
            projectile =  GD.Load<PackedScene>(ProjectileSceneName);
            
        } 

        public override void _Process(float delta) {
            

        }

        private void OnDeath(){
            QueueFree();
        }

    }
}