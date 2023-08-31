using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece {
    public Rook(Vector2Int position, Color color) : base(position, color) { }

    public override List<Vector2Int> CalculatePossibleMoves() {
        List<Vector2Int> moves = new List<Vector2Int>();
        // Calculate possible moves for the king
        HorizontalVerticalMoves(moves);
        return moves;
    }
    
    void HorizontalVerticalMoves(List<Vector2Int> moves) {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        
        foreach (Vector2Int direction in directions) {
            Vector2Int nextPosition = Position + direction;
            while (IsMoveValid(nextPosition)) {
                moves.Add(nextPosition);
                if (ChessBoardPlacementHandler.Instance.GetTile(nextPosition.x, nextPosition.y).Piece != null) {
                    break;
                }
                nextPosition += direction;
            }
        }
    }
}
