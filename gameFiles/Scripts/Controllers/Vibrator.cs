using Godot;

namespace AttackFromTitan.Controllers {
    class Vibrator: Node{
        
        void VibrateGently(){
            Input.StartJoyVibration(device: 0,weakMagnitude: 0.8f, strongMagnitude: 0f,duration: 0.5f);
        }
    }
}