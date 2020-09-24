using Godot;

namespace AttackFromTitan.Core {
    class ProjectileSpawner : Node2D{

        [Export]
        public string ProjectileSceneName{get;set;}
        private PackedScene projectile;

        [Export]
        public float SpawnCoolDown{get;set;}
        private float currentCoolDown {get;set;}
        private bool spawningEnabled;
        private Vector2 projectileTargetDirection;


        [Export]
        public float ProjectileSpeed {get;set;}

        [Signal]
        public delegate void EmitProjectile(Projectile theProjectile);

        public override void _Ready(){
            projectile =  GD.Load<PackedScene>(ProjectileSceneName);

        }
        
        public void toggleSpawning(bool spawningEnabled){
            this.spawningEnabled = spawningEnabled;
        }

        public override void _Process(float delta) {
            currentCoolDown = Mathf.Max(0f,currentCoolDown - delta);
            if(spawningEnabled && currentCoolDown <=0){
                currentCoolDown = SpawnCoolDown;
                var currentProjectile = projectile.Instance() as Projectile;
                currentProjectile.Speed = ProjectileSpeed;
                currentProjectile.Trajectory = projectileTargetDirection;
                currentProjectile.Position = Position;
                EmitSignal(nameof(EmitProjectile),currentProjectile);
            }
        }

        public void updateProjectileTarget(float x, float y){
            projectileTargetDirection = Position.DirectionTo(new Vector2(x,y));
        }

    }

}