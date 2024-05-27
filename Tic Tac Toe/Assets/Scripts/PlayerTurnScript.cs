using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] images;
    public bool isPlayed = false;
    GameObject game;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = null;
        id = int.Parse(gameObject.name.Substring(5));
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        game = GameObject.Find("GameBoard");
    }

    private void OnMouseDown()
    {
        if (!isPlayed)
        {
            int index = game.GetComponent<GameScript>().PlayerTurn();
            spriteRenderer.sprite = images[index];
            game.GetComponent<GameScript>().board[id - 1] = index;
            isPlayed = true;
            game.GetComponent<GameScript>().CheckWinner();
        }
    }
}
