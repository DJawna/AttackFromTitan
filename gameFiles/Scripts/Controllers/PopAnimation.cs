using Godot;

namespace AttackFromTitan.Controllers {
class PopAnimation: AnimatedSprite{
     
    void WhenFinished(){
        QueueFree();
    }

}
}