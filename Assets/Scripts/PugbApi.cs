using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PugbApi : MonoBehaviour
{
    public RectTransform ParentPanel;
    public GameObject[] GOTextID, GOTextDateTime;
    public Text[] txtID;
    public Text[] txtDateTime;


    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(GetTournaments());
    }


    public IEnumerator GetTournaments()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.pubg.com/tournaments");
        www.SetRequestHeader("Accept", "application/vnd.api+json");
        www.SetRequestHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJhNzc0ZTkyMC02YjE1LTAxMzktNWQ4Ni0xZmE5ZGJlNTJlMWYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE2MTgxNDQyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InBvYy1wdWdiIn0.hFzREJokYrwG5KZRhVyijg7D3TXt0RNgUNNv9F3Rzz4");
        www.timeout = 3;
        

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Algo salio mal");
        }
        else
        {
            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log("Json Result PUGB: " + jsonResult);

                DataPugb dataPugb = JsonUtility.FromJson<DataPugb>(jsonResult);

                Debug.Log("id de pugb: " + dataPugb.data[0].id);
                Debug.Log("fecha de creación de pugb: " + dataPugb.data[0].attributes.createdAt);

                GOTextID = new GameObject[dataPugb.data.Count];
                GOTextDateTime = new GameObject[dataPugb.data.Count];

                for (int i = 0; i < dataPugb.data.Count; i++)
                {
                    GOTextID[i] = Instantiate(Resources.Load("TextID", typeof(GameObject))) as GameObject;
                    GOTextDateTime[i] = Instantiate(Resources.Load("TextDateTime", typeof(GameObject))) as GameObject;

                    GOTextID[i].GetComponentInChildren<Text>().text = dataPugb.data[i].id;
                    GOTextDateTime[i].GetComponentInChildren<Text>().text = dataPugb.data[i].attributes.createdAt;

                    GOTextID[i].transform.SetParent(ParentPanel, false);
                    GOTextDateTime[i].transform.SetParent(ParentPanel, false);

                } 
            }
        }
    }
}
