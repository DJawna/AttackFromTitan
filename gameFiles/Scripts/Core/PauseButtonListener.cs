using Godot;

namespace AttackFromTitan.Core {
    public class PauseButtonListener : Node2D {
        public override void _Ready() {

        }

        public override void _Input(InputEvent inputEvent) {
            if (inputEvent.IsActionPressed("pause")) {
                if (GetTree().Paused) {
                    Unpause();
                } else {
                    GetTree().Paused = true;
                    this.Show();
                }
            }
        }

        public void Unpause() {
            this.Hide();
            GetTree().Paused = false;
        }
    }
}
