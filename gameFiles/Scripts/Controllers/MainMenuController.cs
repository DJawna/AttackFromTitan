using Godot;

namespace AttackFromTitan.Controllers {
    class MainMenuController : MarginContainer {
        private void StartNewCampaign() {
            var tree = GetTree();
            tree.ChangeScene("res://Levels/LevelHolder.tscn");
            if(tree.Paused){
                tree.Paused = false;
            }
        }

        private void QuitGame() {
            GetTree().Quit();
        }


        private void openSettings(){
            var tree = GetTree();
            tree.ChangeScene("res://UI/OptionsController.tscn");
        }

    }

}