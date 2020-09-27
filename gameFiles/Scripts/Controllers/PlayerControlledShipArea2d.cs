using AttackFromTitan.Core;
using Godot;

namespace AttackFromTitan.Controllers {
    class PlayerControlledShipArea2d : Area2D,Targetable {
        public Allegiance TargetAllegiance => Allegiance.humans;
        public bool IsAlive {get; private set;} = true;

        public void OnDead(){
            IsAlive = false;
        }
    }
}