using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public TMPro.TMP_Text player;
    public int[] board;
    public GameObject[] tokens;
    int spriteIndex = -1;

    private void Awake()
    {
        board = new int[9];
    }
    private void Start()
    {
        player.text = $"{MenuScript.p1Name}'s Turn!";

        resetBoard();
    }

    private void resetBoard()
    {
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = -1;
        }
    }

    public int PlayerTurn()
    {
        spriteIndex++;
        int turn = spriteIndex % 2;
        
        if(turn == 0)
            player.text = $"{MenuScript.p2Name}'s Turn!";
        else
            player.text = $"{MenuScript.p1Name}'s Turn!";
        return turn;
    }

    public void CheckWinner()
    {
        bool winner = false;

        if (board[0] != -1 && board[0] == board[1] && board[0] == board[2])
            winner = true;
        if (board[3] != -1 && board[3] == board[4] && board[3] == board[5])
            winner = true;
        if (board[6] != -1 && board[6] == board[7] && board[6] == board[8])
            winner = true;
        if (board[0] != -1 && board[0] == board[3] && board[0] == board[6])
            winner = true;
        if (board[1] != -1 && board[1] == board[4] && board[1] == board[7])
            winner = true;
        if (board[2] != -1 && board[2] == board[5] && board[2] == board[8])
            winner = true;
        if (board[0] != -1 && board[0] == board[4] && board[0] == board[8])
            winner = true;
        if (board[2] != -1 && board[2] == board[4] && board[2] == board[6])
            winner = true;
        
        if(winner)
        {
            int turn = spriteIndex % 2;
            if (turn == 0)
                player.text = $"{MenuScript.p1Name} Won!!";
            else
                player.text = $"{MenuScript.p2Name} Won!!";
            
            foreach(GameObject token in tokens)
            {
                token.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void Restart()
    {
        Start();
        spriteIndex = -1;

        foreach(GameObject token in tokens)
        {
            token.GetComponent<SpriteRenderer>().sprite = null;
            token.GetComponent<BoxCollider2D>().enabled = true;
            token.GetComponent<PlayerTurnScript>().isPlayed = false;
        }
    }
}
