using Godot;

namespace BoulderDash.Utils
{
    [Tool]
    public class Grid : Node2D
    {
        private Vector2 _cellSize = new Vector2(64, 64);
        private Vector2 _cellSpacing = Vector2.Zero;

        [Export]
        public Vector2 CellSize
        {
            get => _cellSize;
            set
            {
                _cellSize = value;
                Update();
            }
        }

        [Export]
        public Vector2 CellSpacing
        {
            get => _cellSpacing;
            set
            {
                _cellSpacing = value;
                Update();
            }
        }

        public Vector2 GetCellLocalPosition(Vector2Int cellPosition)
        {
            return new Vector2(
                cellPosition.X * (_cellSize.x + _cellSpacing.x),
                cellPosition.Y * (_cellSize.y + _cellSpacing.y));
        }

        public Vector2 GetCellWorldPosition(Vector2Int cellPosition)
        {
            return ToGlobal(GetCellLocalPosition(cellPosition));
        }

        public Vector2 GetCellCenterLocalPosition(Vector2Int cellPosition)
        {
            return GetCellLocalPosition(cellPosition) + _cellSize * 0.5f;
        }

        public Vector2 GetCellCenterWorldPosition(Vector2Int cellPosition)
        {
            return ToGlobal(GetCellCenterLocalPosition(cellPosition));
        }

        public override void _Draw()
        {
            base._Draw();

            DrawGrid();
        }

        private void DrawGrid()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    DrawCircle(GetCellCenterLocalPosition(new Vector2Int(x, y)), 1f, Colors.Lime);
                }
            }
        }
    }
}