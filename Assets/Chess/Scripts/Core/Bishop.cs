using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece {
    public Bishop(Vector2Int position, Color color) : base(position, color) { }

    public override List<Vector2Int> CalculatePossibleMoves() {
        List<Vector2Int> moves = new List<Vector2Int>();
        // Calculate possible moves for the king
        DiagonalMoves(moves);
        return moves;
    }
    
    void DiagonalMoves(List<Vector2Int> moves) {
        Vector2Int[] directions = { new Vector2Int(1, 1), new Vector2Int(-1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1) };
        
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
