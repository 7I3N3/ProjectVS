using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectVS
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        [SerializeField]
        protected bool dontDestroy;

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();

                if (dontDestroy)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

