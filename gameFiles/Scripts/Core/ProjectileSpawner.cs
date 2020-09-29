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

        [Export]
        public float Ttl {get;set;}=0.5f;
        private float currentCoolDown {get;set;}
        private bool spawningEnabled;
        private Vector2 projectileTargetDirection = new Vector2(0f,1f);


        [Export]
        public float ProjectileSpeed {get;set;}


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
                
                currentProjectile.Damage = ProjectileDamage;
                currentProjectile.Ttl = Ttl;
                AddChild(currentProjectile);
                currentProjectile.GlobalPosition = GlobalPosition;
            }
        }

        public void updateProjectileTarget(Vector2 target){
            projectileTargetDirection = GlobalPosition.DirectionTo(target);
        }

    }

}