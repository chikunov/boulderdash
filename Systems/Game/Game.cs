using BoulderDash.UI;
using Godot;

namespace BoulderDash.Systems
{
    public class Game : Node2D
    {
        [Export] private NodePath _mainMenuPath;

        private MainMenu _mainMenu;
        
        public override void _Ready()
        {
            base._Ready();

            _mainMenu = GetNode<MainMenu>(_mainMenuPath);
        }

        public override void _Notification(int what)
        {
            base._Notification(what);

            if (what == MainLoop.NotificationWmQuitRequest)
            {
                GetTree().Quit();
            }
        }
    }
}