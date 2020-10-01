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


        [Export]
        public float ProjectileSpeed {get;set;}

        [Export]
        public Vector2 ProjectileTargetDirection {get;set;} = new Vector2(0f,-1f);

        [Export]
        public Allegiance ProjectileAllegiance {get;set;}

        private Node projectileTargetNode; 

        private Node getOrCreateProjectileTargetNode(){
            var projectileTargetNodeName = "projectileTargetNode";
            var candidate = GetNode($"/root/{projectileTargetNodeName}");
            if(candidate == null){
                candidate = new Node();
                var rootNode = GetNode("/root");
                candidate.Name = projectileTargetNodeName;
                rootNode.AddChild(candidate);
            }
            return candidate;
        }


        public override void _Ready(){
            projectile =  GD.Load<PackedScene>(ProjectileSceneName);
            if(projectile == null){
                throw new System.Exception($"projectile could not be initialized: {ProjectileSceneName}");
            }
            
            projectileTargetNode = getOrCreateProjectileTargetNode();          
        }
        
        public void ToggleSpawning(bool spawningEnabled){
            this.spawningEnabled = spawningEnabled;
        }

        //private readonly Vector2 thing = new Vector2(0f, -1f);
        public override void _Process(float delta) {
            currentCoolDown = Mathf.Max(0f,currentCoolDown - delta);
            if(spawningEnabled && currentCoolDown <=0){
                currentCoolDown = SpawnCoolDown;
                var currentProjectile = projectile.Instance() as Projectile;
                currentProjectile.Speed = ProjectileSpeed;
                currentProjectile.Trajectory = ProjectileTargetDirection;
                currentProjectile.Allegiance =ProjectileAllegiance;
                currentProjectile.Damage = ProjectileDamage;
                currentProjectile.Ttl = Ttl;
                
                projectileTargetNode.AddChild(currentProjectile);
                currentProjectile.GlobalPosition = GlobalPosition;
                currentProjectile.Rotation += ProjectileTargetDirection.Angle();
            }
        }

        public void updateProjectileTarget(Vector2 target){
            ProjectileTargetDirection = GlobalPosition.DirectionTo(target);
        }

        public override string _GetConfigurationWarning(){
            var file = new File();
            var err = "";
            if(string.IsNullOrEmpty(ProjectileSceneName)){
                err = $"file {ProjectileSceneName} is either null or empty";
            }
            return err;
        }
    }

}