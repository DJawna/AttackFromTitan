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

        private bool toggleAttackingFromLastFrame =false; 

        public override void _Process(float delta){

            while(newCandidates.TryDequeue(out var newTarget)){
                targets.Add(newTarget);
            }

            while(candidatesToRemove.TryDequeue(out var toRemove)){
                targets.Remove(toRemove);
            }          

            var toggleOnAttack = false;
            foreach(var candidate in targets){
                if(!candidate.IsAlive){
                    candidatesToRemove.Enqueue(candidate);
                }
                else{
                    toggleOnAttack = true;
                    EmitSignal(nameof(BroadcastCurrentEnemyLocation),candidate.GlobalPosition);
                    break;
                }
            }

            if(toggleOnAttack != toggleAttackingFromLastFrame){
                EmitSignal(nameof(ToggleAttacking), toggleOnAttack);
                toggleAttackingFromLastFrame = toggleOnAttack;
            }
        }
    }
}