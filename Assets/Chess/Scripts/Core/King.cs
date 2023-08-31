using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece {
    public King(Vector2Int position, Color color) : base(position, color) { }

    public override List<Vector2Int> CalculatePossibleMoves() {
        List<Vector2Int> moves = new List<Vector2Int>();
        // Calculate possible moves for the king
        Vector2Int[] moveDirections = {
            new Vector2Int(1, 0), new Vector2Int(-1, 0),
            new Vector2Int(0, 1), new Vector2Int(0, -1),
            new Vector2Int(1, 1), new Vector2Int(-1, 1),
            new Vector2Int(1, -1), new Vector2Int(-1, -1)
        };

        foreach (Vector2Int direction in moveDirections) {
            Vector2Int potentialMove = Position + direction;
            if (IsMoveValid(potentialMove)) {
                moves.Add(potentialMove);
            }
        }

        return moves;        
    }

    // bool IsMoveValid(Vector2Int position) {
    //     // Implement logic to check if the move is within bounds and not obstructed by other pieces
    //     return true;
    // }

}
