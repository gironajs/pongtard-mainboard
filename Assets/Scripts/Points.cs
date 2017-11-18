using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text player1, player2;
    private int p1punts, p2punts;

    private void Awake()
    {
        p1punts = p2punts = 0;
    }
     
	public void Player1up()
    {
        p1punts++;
        player1.text = p1punts.ToString();
    }

    public void Player2up()
    {
        p2punts++;
        player2.text = p2punts.ToString();
    }
}
