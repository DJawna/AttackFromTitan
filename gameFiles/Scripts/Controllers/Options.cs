using Godot;
using System.Collections.Generic;

namespace AttackFromTitan.Controllers {
    class Options : Node {

        [Export]
        public bool NewMissionVisible { get; set; } = true;

        [Export]
        public bool LoadMissionVisible { get; set; } = true;

        [Export]
        public bool SettingsVisible { get; set; } = true;

        [Export]
        public bool RestartLevelVissible { get; set; } = true;

        [Export]
        public bool QuitGameVisible { get; set; } = true;

        [Signal]
        public 

        public override void _Ready() {
            var children = new Dictionary<string, CanvasItem>();
            foreach (var child in GetChildren()) {
                var childNode = (CanvasItem)child;
                children.Add(childNode.Name, childNode);
                switch (childNode.Name) {
                    case "NewMission":
                        childNode.Visible = NewMissionVisible;
                        break;

                    case "LoadMission":
                        childNode.Visible = LoadMissionVisible;
                        break;

                    case "Settings":
                        childNode.Visible = SettingsVisible;
                        break;

                    case "RestartLevel":
                        childNode.Visible = RestartLevelVissible;
                        break;

                    case "QuitGame":
                        childNode.Visible = QuitGameVisible;
                        break;
                }
            }
        }


        private void StartNewMission() {
            EmitSignal()
            var tree = GetTree();
            tree.ChangeScene("res://Levels/LevelHolder.tscn");
            if (tree.Paused) {
                tree.Paused = false;
            }
        }

        private void QuitGame() {
            GetTree().Quit();
        }


        private void OpenSettings() {
            var tree = GetTree();
            tree.ChangeScene("res://UI/OptionsController.tscn");
        }
    }
}