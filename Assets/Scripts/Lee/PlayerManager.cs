using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int hp;

    // Single Tone
    public static PlayerManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public int HP { get; set; }


}
