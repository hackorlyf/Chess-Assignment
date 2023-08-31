using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    private ChessTile[,] chessboard;
    private ChessPiece selectedPiece;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Cast a ray to detect the clicked tile/piece
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                ChessPiece clickedPiece = hit.collider.gameObject.GetComponent<ChessPiece>();
                
                if (clickedPiece != null) {
                    DeselectPiece(); // Clear previous highlights and deselect
                    selectedPiece = clickedPiece;
                    HighlightPossibleMoves(selectedPiece);
                }
            } else {
                DeselectPiece(); // Clear previous highlights and deselect
            }
        }
    }

    void HighlightPossibleMoves(ChessPiece piece) {
        List<Vector2Int> possibleMoves = piece.CalculatePossibleMoves();
        foreach (Vector2Int move in possibleMoves) {
            ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
        }
    }

    void ClearHighlights() {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
    }

    void DeselectPiece() {
        if (selectedPiece != null) {
            ClearHighlights();
            selectedPiece = null;
        }
    }
}

