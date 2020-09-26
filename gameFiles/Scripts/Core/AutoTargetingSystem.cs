using Godot;
using System.Collections.Concurrent;


namespace AttackFromTitan.Core {
    class AutoTargetingSystem: Area2D{
        private readonly ConcurrentBag<Targetable> currentTargets = new ConcurrentBag<Targetable>();
        void TargetingCandidateEntering(Area2D enteringObject){
            var targetCandidate = enteringObject as Targetable;
            if(targetCandidate != null){
                currentTargets.Add(targetCandidate);
            }            
        }


        void TargetingCandidateLeaving(Area2D leavingObject){
            var targetCandidate = leavingObject as Targetable;
            if(targetCandidate != null){
                //currentTargets

            }            
        }

        [Signal]
        public delegate void BroadcastCurrentEnemyLocation(Vector2 currentEnemyLocation);

        public override void _Process(float delta){
            var targetFound = false;
            while(!targetFound){
                if(currentTargets.TryTake(out var toAttack) && toAttack.IsAlive){
                    targetFound = true;
                    EmitSignal(nameof(BroadcastCurrentEnemyLocation), toAttack.Position);
                    currentTargets.Add(toAttack);
                }
            }
        }


    }
}