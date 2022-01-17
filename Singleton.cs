
using Unity.Netcode;
using UnityEngine;

public class Singleton<T> :  NetworkBehaviour //MonoBehaviour
where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var objs = FindObjectOfType(typeof(T)) as T[];
               
                if (objs is {Length: > 0})
                    _instance = objs[0];
                
                if (objs is {Length: > 1})
                {
                    Debug.LogWarning("More than one Instance Found");
                }

                if (Instance == null)
                {
                    var obj = new GameObject
                    {
                        name = $"_{typeof(T).Name}"
                    };
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }
}
