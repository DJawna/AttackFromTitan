using Godot;

namespace AttackFromTitan.Controllers {
    class UIMenu :Control{

        [Signal]
        public delegate void OnGoingBack();

        public void GoingBackButtonPressed(){
            EmitSignal(nameof(OnGoingBack));
        }

    }
}