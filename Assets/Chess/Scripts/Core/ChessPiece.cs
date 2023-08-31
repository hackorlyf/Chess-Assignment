using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece {
    public Vector2Int Position { get; protected set; }
    public Color Color { get; protected set; }

    public ChessPiece(Vector2Int position, Color color) {
        Position = position;
        Color = color;
    }

    public virtual List<Vector2Int> CalculatePossibleMoves() {
        return new List<Vector2Int>();
    }

    protected ChessTile GetTileAtPosition(Vector2Int position) {
        return ChessBoardPlacementHandler.Instance.GetTile(position.x, position.y);
    }

    protected bool IsMoveValid(Vector2Int position) {
        ChessTile tile = GetTileAtPosition(position);
        return tile != null && (tile.Piece == null || tile.Piece.Color != Color);
    }

    
}
