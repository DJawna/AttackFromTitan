using Godot;

namespace AttackFromTitan.Core {
    class GameSceneRoot : Node2D{

        [Signal]
        public delegate void OnGameOver();

        public void EmitGameOver(){
            EmitSignal(nameof(OnGameOver));
        }

    }
}