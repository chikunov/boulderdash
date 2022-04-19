using Godot;

namespace BoulderDash.Entities.Level
{
    public class Level : Node2D
    {
        [Export] private NodePath _boardPath;

        private Board _board;

        public override void _Ready()
        {
            base._Ready();

            _board = GetNode<Board>(_boardPath);
        }
    }
}