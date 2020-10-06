using Godot;

namespace AttackFromTitan.Controllers {
    class MainMenuController : Node {
        private void NewMission() {
            var tree = GetTree();
            tree.ChangeScene("res://Levels/LevelHolder.tscn");
            if(tree.Paused){
                tree.Paused = false;
            }
        }


        private void openSettings(){
            var tree = GetTree();
            tree.ChangeScene("res://UI/OptionsController.tscn");
        }

    }

}