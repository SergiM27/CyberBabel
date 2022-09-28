using UnityEngine;

public class StartMusicMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic("Music");
        Cursor.visible = true;
    }
}
