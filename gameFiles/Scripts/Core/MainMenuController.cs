using Godot;

namespace AttackFromTitan.Core {
    class MainMenuController : MarginContainer {
        private void StartNewCampaign() {
            GetTree().ChangeScene("res://Levels/LevelHolder.tscn");
        }

    }

}