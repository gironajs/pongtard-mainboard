using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Manager : MonoBehaviour
{
    public SocketIOComponent socket;
    public Pala padL;
    public Pala padR;
    public Text player1Name, player2Name;

    private string player1, player2;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        socket.On("start", SetName);
        socket.On("up", MoveUp);
        socket.On("down", MoveDown);
        socket.On("stop", StopMove);
    }

    private void SetName(SocketIOEvent ev)
    {
        JSONObject json = ev.data;

        if (json["id"].n == 0)
        {
            player1 = json["nick"].str;
            player1Name.text = player1;
        }
        else if (json["id"].n == 1)
        {
            player2 = json["nick"].str;
            player2Name.text = player2;
        }
    }

    public void registerBoard()
    {
        StartCoroutine(checkConnection());        
    }

    private void MoveUp(SocketIOEvent ev)
    {
        JSONObject json = ev.data;

        if (json["id"].n == 0)
            padL.MoveUp();
        else if (json["id"].n == 1)
            padR.MoveUp();
    }

    private void MoveDown(SocketIOEvent ev)
    {
        Debug.Log(ev);
        JSONObject json = ev.data;

        if (json["id"].n == 0)
            padL.MoveDown();
        else if (json["id"].n == 1)
            padR.MoveDown();
    }

    private void StopMove(SocketIOEvent ev)
    {
        JSONObject json = ev.data;

        if (json["id"].n == 0)
            padL.StopMove();
        else if (json["id"].n == 1)
            padR.StopMove();
    }

    private IEnumerator checkConnection()
    {
        yield return new WaitForSeconds(1f);
        JSONObject json = new JSONObject();
        string nick = "mainboard";
        json.AddField("nick", nick);
        socket.Emit("register", json);
    }
}
