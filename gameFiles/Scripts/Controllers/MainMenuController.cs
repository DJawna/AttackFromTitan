using Godot;

namespace AttackFromTitan.Controllers {
    class MainMenuController : Node {
        private SceneTree tree;
        private CanvasItem topContainer;
        private CanvasItem middleContainer;
        private CanvasItem bottomContainer;
        private CanvasItem settingsMenu;

        public override void _Ready() {
            tree = GetTree();
            foreach (var child in GetParent().GetChildren()) {
                var canvasChild = child as CanvasItem;
                if (canvasChild != null) {
                    switch (canvasChild.Name) {
                        case "TopContainer":
                            topContainer = canvasChild;
                            break;
                        case "MiddleContainer":
                            middleContainer = canvasChild;
                            break;
                        case "BottomContainer":
                            bottomContainer = canvasChild;
                            break;
                        case "SettingsMenu":
                            settingsMenu = canvasChild;
                            break;
                    }
                }
            }
        }
        private void NewMission() {
            tree.ChangeScene("res://Levels/LevelHolder.tscn");
            if (tree.Paused) {
                tree.Paused = false;
            }
        }

        private void ToggleSettingsMenu(bool settingsVisible){
            topContainer.Visible =
            middleContainer.Visible =
            bottomContainer.Visible = !settingsVisible;
            settingsMenu.Visible = settingsVisible;

        }

        private void OpenSettings() =>
            ToggleSettingsMenu(settingsVisible: true);
        

        private void CloseSettings() =>
            ToggleSettingsMenu(settingsVisible: false);
    }
}