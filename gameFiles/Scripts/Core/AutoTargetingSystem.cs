using Godot;
using System.Collections.Generic;
using System.Collections.Concurrent;


namespace AttackFromTitan.Core {
    class AutoTargetingSystem: Area2D{

        private readonly List<Targetable> targets = new List<Targetable>();
        private readonly ConcurrentQueue<Targetable> newCandidates = new ConcurrentQueue<Targetable>();
        private readonly ConcurrentQueue<Targetable> candidatesToRemove = new ConcurrentQueue<Targetable>();
        void TargetingCandidateEntering(Area2D enteringObject){
            var targetCandidate = enteringObject as Targetable;
            if(targetCandidate != null && targetCandidate.IsAlive){
                newCandidates.Enqueue(targetCandidate);
            }            
        }

        void TargetingCandidateLeaving(Area2D leavingObject){
            var targetCandidate = leavingObject as Targetable;
            if(targetCandidate != null){
                candidatesToRemove.Enqueue(targetCandidate);
            }            
        }

        [Signal]
        public delegate void BroadcastCurrentEnemyLocation(Vector2 currentEnemyLocation);

        [Signal]
        public delegate void ToggleAttacking(bool toggleAttack);

        public override void _Process(float delta){
            
            foreach(var candidate in newCandidates){
                targets.Add(candidate);
            }

            foreach(var candidate in candidatesToRemove){
                targets.Remove(candidate);
            }
            EmitSignal(nameof(ToggleAttacking),false);

            foreach(var candidate in targets){
                if(!candidate.IsAlive){
                    candidatesToRemove.Enqueue(candidate);
                }
                else{
                    EmitSignal(nameof(ToggleAttacking),true);
                    EmitSignal(nameof(BroadcastCurrentEnemyLocation),candidate.GlobalPosition);
                    break;
                }
            }
        }
    }
}