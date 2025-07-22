using Newtonsoft.Json;
using Proyecto26;
using UnityEngine;
using UnityEngine.Events;

namespace VerveCode
{
    public class MCStatus
    {
        private static readonly string BASE_URL = "https://api.mcstatus.io/v2";
        private static readonly string QUREY_STATUS = "/status";
        private static readonly string PATH_JAVA = "/java";
        private static readonly string PATH_BEDROCK = "/bedrock";

        public static void GetServerStatus<T>(string address, int port, UnityAction<T> callback) where T : MCStatusBase
        {
            string path = string.Empty;
            if (typeof(T) == typeof(MCStatusJava))
            {
                path = PATH_JAVA;
            }
            else if (typeof(T) == typeof(MCStatusBedrock))
            {
                path = PATH_BEDROCK;
            }

            RestClient.Get($"{BASE_URL}{QUREY_STATUS}{path}/{address}:{port}").Then(response =>
            {
                T status = JsonConvert.DeserializeObject<T>(response.Text);
                callback.Invoke(status);
            }).Catch(error =>
            {
                Debug.LogError(error);
            });
        }
    }  
}
