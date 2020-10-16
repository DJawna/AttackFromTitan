using Godot;
using AttackFromTitan.Controllers;
using AttackFromTitan.Extensions;

namespace AttackFromTitan.Core {
    public class Projectile : Area2D, DoesDamage {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        // Called when the node enters the scene tree for the first time.
        public PackedScene PopAnimationScene {get;set;} 


        public override void _Ready() {
            if(this.TryGetFirstChild<CanvasItem>(out var projectileSprite, i => i.Name == "ProjectileSprite" )){
                var shaderMaterial = projectileSprite.Material as ShaderMaterial;
                    if(shaderMaterial == null){
                        throw new System.Exception($"Wrong material in the Sprite Subnode: {projectileSprite.Name} of {nameof(Projectile)} expected material is: {nameof(ShaderMaterial)}");
                    }
                    shaderMaterial.SetShaderParam("replacementColor", ProjectileColor);
            }
        }

        public float Ttl {get;set;} = 1f;


        public uint Damage { get; set; }
        public Allegiance Allegiance { get; set; }

        public float Speed{get;set;} = 10f;

        [Export]
        public Vector3 ProjectileColor {get;set;} = new Vector3(1f,0f, 0f);

        public Vector2 Trajectory {get;set;} = new Vector2(0f,-1f);

        public bool DamageHasBeenReceived{get;set;}

        public override void _Process(float delta){
            var newPos = GlobalPosition + (Trajectory * Speed * delta);
            GlobalPosition = newPos;

            Ttl -= delta;
            if(DamageHasBeenReceived && PopAnimationScene != null){
                var pop =(PopAnimation) PopAnimationScene.Instance();
                pop.GlobalPosition = this.GlobalPosition;
                this.GetParent().AddChild(pop);
                pop.Playing = true;
            }

            if(Ttl <0 || DamageHasBeenReceived){
                QueueFree();
            }

            
        }
    }
}
