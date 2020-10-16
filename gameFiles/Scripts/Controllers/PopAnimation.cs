using Godot;

namespace AttackFromTitan.Controllers {
class PopAnimation: AnimatedSprite{

    [Export]
    public Vector3 ExplosionColor {get;set;} = new Vector3(1f, 0f,0f);

        public override void _Ready() {
            var sm = this.Material as ShaderMaterial;
            if(sm == null){
                throw new System.Exception($"PopAnimation has a wrong material assigned, required Material: {nameof(ShaderMaterial)}");
            }

            sm.SetShaderParam("replacementColor", ExplosionColor);
        }

    
     
    void WhenFinished(){
        QueueFree();
    }

}
}