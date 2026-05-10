using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance { get { return _instance; } }
    public virtual void Awake()
    {
        #region Singleton Pattern
        if (_instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            _instance = this as T;
        }
        #endregion
    }
}
