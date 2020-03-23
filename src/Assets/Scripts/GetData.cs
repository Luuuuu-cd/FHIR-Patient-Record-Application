using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public Patients patients;
    public Text notification;

    [Serializable]
    public class TokenClassName
    {
        public string access_token;
    }
    IEnumerator GetAccessToken(Action<string> result)
    {
        var url = "https://login.microsoftonline.com/ca254449-06ec-4e1d-a3c9-f8b84e2afe3f/oauth2/v2.0/token";
        var form = new WWWForm();
        form.AddField("grant_type", "client_credentials");
        form.AddField("client_id", "");
        form.AddField("client_secret", "");
        form.AddField("scope", "");
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        //wait for request to complete
        yield return www.Send();

        //and check for errors
        if (!www.isNetworkError)
        {
            string resultContent = www.downloadHandler.text;
            TokenClassName json = JsonUtility.FromJson<TokenClassName>(resultContent);

            //Return result
            result(json.access_token);
        }
        else
        {
            //Return null
            result("");
        }
    }


    #region Data Structure
    [Serializable]
    public class Patients
    {
        public string resourceType;
        public string id;
        public Meta meta;
        public string type;
        public Link[] link;
        public Entry[] entry;

        [Serializable]
        public class Meta
        {
            public string lastUpdated;
        }
        [Serializable]
        public class Link
        {
            public string relation;
            public string url;
        }
        [Serializable]
        public class Entry
        {
            public string fullUrl;
            public Resource resource;
            public Search search;
            [Serializable]
            public class Resource
            {
                public string resourceType;
                public string id;
                public ResourceMeta meta;
                public Text text;
                public Extension[] extension;
                public Identifier[] identifier;
                public Name[] name;
                public Telecom[] telecom;
                public string gender;
                public string birthDate;
                public Address[] address;
                public MaritalStatus maritalStatus;
                public string multipleBirthBoolean;
                public Communication[] communication;

                [Serializable]
                public class ResourceMeta
                {
                    public string versionId;
                    public string lastUpdated;
                }
                [Serializable]
                public class Text
                {
                    public string status;
                    public string div;
                }
                [Serializable]
                public class Extension
                {
                    public ExtensionExtension[] extension;
                    public string url;
                    [Serializable]
                    public class ExtensionExtension
                    {
                        public string url;
                        public ValueCoding valueCoding;
                        [Serializable]
                        public class ValueCoding
                        {
                            public string system;
                            public string code;
                            public string display;
                        }
                    }
                }
                [Serializable]
                public class Identifier
                {
                    public string system;
                    public string value;
                    public Type type;

                    [Serializable]
                    public class Type
                    {
                        public Coding[] coding;
                        public string text;

                        [Serializable]
                        public class Coding
                        {
                            public string system;
                            public string code;
                            public string display;
                        }
                    }
                }
                [Serializable]
                public class Name
                {
                    public string use;
                    public string family;
                    public string[] given;
                    public string[] prefix;
                    [Serializable]
                    public class Given
                    {
                        public string given;
                    }
                    [Serializable]
                    public class Prefix
                    {
                        public string prefix;
                    }
                }
                [Serializable]
                public class Telecom
                {
                    public string system;
                    public string value;
                    public string home;
                }
                [Serializable]
                public class Address
                {
                    public Extension[] extension;
                    public string[] line;
                    public string city;
                    public string state;
                    public string postalCode;
                    public string country;
                    [Serializable]
                    public class Extension
                    {
                        public ExtensionExtension[] extension;
                        public string url;
                        [Serializable]
                        public class ExtensionExtension
                        {
                            public string url;
                            public string valueDecimal;
                        }
                    }
                }
                [Serializable]
                public class MaritalStatus
                {
                    public Coding[] coding;
                    public string text;
                    [Serializable]
                    public class Coding
                    {
                        public string system;
                        public string code;
                        public string display;
                    }
                }
                [Serializable]
                public class Communication
                {
                    public Language language;
                    [Serializable]
                    public class Language
                    {
                        public Coding[] coding;
                        public string text;
                        [Serializable]
                        public class Coding
                        {
                            public string system;
                            public string code;
                            public string display;
                        }
                    }
                }
            }
            [Serializable]
            public class Search
            {
                public string mode;
            }

        }


    } 

    #endregion

    IEnumerator GetPatients(Action<Patients> result)
    {
        var url = "https://gosh-fhir-synth.azurehealthcareapis.com";
        UnityWebRequest www = UnityWebRequest.Get(url+ "/Patient");
        string token = null;
        yield return GetAccessToken((tokenResult) => { token = tokenResult; });
 
        www.SetRequestHeader("Authorization", "Bearer " + token);
        www.SetRequestHeader("Content-Type","application/json");
        yield return www.Send();
        if (!www.isNetworkError)
        {
    
            string resultContent = www.downloadHandler.text;
            string newResultContent = "{\"Items\":" + resultContent + "}";
            Patients patient = JsonUtility.FromJson<Patients>(resultContent);
            string patientsName = "";

            //Return result
            result(patient);
        }
        else
        {
            //Return null
            result(null);
        }
    }

    public static class JsonHelper
    {

        public static T[] FromJson<T>(string json)
        {
 
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(GetPatients((patientsResult) =>
        {
            patients = patientsResult;
            notification.text = "Retrieving Completed!";
        }));  
    }
}
