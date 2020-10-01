using Godot;

namespace AttackFromTitan.Core {
    class MainMenuController : MarginContainer {
        private void StartNewCampaign() {
            var tree = GetTree();
            tree.ChangeScene("res://Levels/LevelHolder.tscn");
            if(tree.Paused){
                tree.Paused = false;
            }
        }

    }

}