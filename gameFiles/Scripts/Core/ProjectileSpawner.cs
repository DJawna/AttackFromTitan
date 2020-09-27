using Godot;

namespace AttackFromTitan.Core {
    class ProjectileSpawner : Node2D{

        [Export]
        public string ProjectileSceneName{get;set;}
        private PackedScene projectile;

        [Export]
        public float SpawnCoolDown{get;set;}

        [Export]
        public uint ProjectileDamage {get;set;}
        private float currentCoolDown {get;set;}
        private bool spawningEnabled;
        private Vector2 projectileTargetDirection = new Vector2(0f,1f);


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
                currentProjectile.Damage = ProjectileDamage;
                EmitSignal(nameof(EmitProjectile),currentProjectile);
            }
        }

        public void updateProjectileTarget(Vector2 target){
            projectileTargetDirection = Position.DirectionTo(target);
        }

    }

}