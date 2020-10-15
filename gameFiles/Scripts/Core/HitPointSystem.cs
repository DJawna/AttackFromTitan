using Godot;

namespace AttackFromTitan.Core {
    class HitPointSystem : Node {

        [Export]
        public uint Hitpoints { get; set; }


        private Allegiance vulnerability { get; set; }

        [Export]
        public bool VulnerableToHumans {
            get => vulnerability == Allegiance.humans;
            set {
                vulnerability |= Allegiance.humans;
            }
        }

        [Export]
        public bool VulnerableToTitanians {
            get => vulnerability == Allegiance.titanians;
            set {
                vulnerability |= Allegiance.titanians;
            }
        }

        [Export]
        public bool VulnerableToNeutrals {
            get => vulnerability == Allegiance.neutral;
            set {
                vulnerability |= Allegiance.neutral;
            }
        }

        [Signal]
        public delegate void OnDeath();

        [Signal]
        public delegate void OnTakingDamage();



        public void OnArea2dEntered(Area2D entered) {
            var doesDamage = entered as DoesDamage;
            if (doesDamage != null &&
                this.vulnerability ==doesDamage.Allegiance) {
                Hitpoints -= doesDamage.Damage;
                doesDamage.DamageHasBeenReceived = true;
                EmitSignal(nameof(OnTakingDamage));
            }
            if(Hitpoints <= 0){
                EmitSignal(nameof(OnDeath));
            }
        }

    }



    interface DoesDamage {
        uint Damage { get; set; }
        Allegiance Allegiance { get;set;}

        bool DamageHasBeenReceived{get;set;}
    }

}