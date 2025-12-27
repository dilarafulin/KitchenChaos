using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSounds : MonoBehaviour
{
    //SoundManager ile Tightly Coupled olmus durumda fakat bu class soundmanager in yaninda var olmayi amacladigi icin tightly coupled olmasi np 
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax = .1f;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0)
        {
            footstepTimer = footstepTimerMax;

            if (player.IsWalking())
            {
                float volume = 2f;
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }

}
