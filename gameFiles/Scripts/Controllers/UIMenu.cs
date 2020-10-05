using Godot;

namespace AttackFromTitan.Controllers {
    class UIMenu :Node{

        [Signal]
        public delegate void OnGoingBack();

        public void GoingBackButtonPressed(){
            EmitSignal(nameof(OnGoingBack));
        }

    }
}