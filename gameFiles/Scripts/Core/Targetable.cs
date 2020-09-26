using Godot;

namespace AttackFromTitan.Core {

    interface Targetable{
        Allegiance TargetAllegiance{get;}

        Vector2 Position{get;}

        bool IsAlive {get;}
    }
}