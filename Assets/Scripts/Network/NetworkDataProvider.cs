using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkDataProvider : MonoBehaviour
{
    public static Action<bool> LoadingStarted;
    public UsersList _usersList = new UsersList();
    [SerializeField] NetworkDataReader _jsonReader;

    private void Start()
    {
        StartCoroutine(GetRequest(ConstStrings.JSON_URI));
    }

    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            LoadingStarted?.Invoke(true);
            yield return webRequest.SendWebRequest();
            LoadingStarted?.Invoke(false);

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogWarning("webRequest responded with an error!");
            }
            else
            {
                ParseJsonFromURI(webRequest);
            }
        }
    }

    private void ParseJsonFromURI(UnityWebRequest webRequest)
    {
        _usersList = JsonUtility.FromJson<UsersList>("{\"Users\":" + webRequest.downloadHandler.text + "}");
        _jsonReader.ReadUserInfo(_usersList);
    }
}
