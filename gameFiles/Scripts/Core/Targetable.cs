using Godot;

namespace AttackFromTitan.Core {

    interface Targetable{
        Allegiance TargetAllegiance{get;}

        Vector2 GlobalPosition{get;}

        bool IsAlive {get;}
    }
}