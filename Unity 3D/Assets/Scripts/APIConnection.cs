using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIConnection : MonoBehaviour
{
    public Text playerName;
    public Text highScoreText;
    public Text successState;

    private string apiUrl = "http://localhost:8080/highScore/getScore";
    private HighScoreStruct highScoreStruct;

    public void CallAPI()
    {
        StartCoroutine(GetRequest(apiUrl, LoadJsonDataCallBack));
    }

    private IEnumerator GetRequest(string url, Action<string> callback)
    {
        string response;

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.isHttpError)
        {
            response = null;
        }
        else if (www.isNetworkError)
        {
            response = null;
        }
        else
        {
            response = www.downloadHandler.text;

        }

        callback(response);
    }

    private void LoadJsonDataCallBack(string res)
    {
        if (res != null)
        {
            highScoreStruct = JsonUtility.FromJson<HighScoreStruct>(res);

            playerName.text = highScoreStruct.playerName;
            highScoreText.text = highScoreStruct.highScore.ToString();

            successState.color = Color.green;
            successState.text = "Success!";
        }
        else
        {
            successState.color = Color.red;
            successState.text = "Fail!";
        }
    }

    [Serializable]
    private struct HighScoreStruct
    {
        public string playerName;
        public int highScore;
    }
}
