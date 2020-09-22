using Godot;

namespace AttackFromTitan.Core {

    class EnemyInterceptor : Area2D{

        private void OnDeath(){
            QueueFree();
        }

    }
}