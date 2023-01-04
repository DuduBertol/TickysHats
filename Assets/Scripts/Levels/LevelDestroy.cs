using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroy : MonoBehaviour
{
    private LevelGenterator levelGenterator;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        levelGenterator = FindObjectOfType<LevelGenterator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        DeleteFinalParts();
    }

    private void DeleteFinalParts()
    {
        if(transform.position.x < player.transform.position.x - 125)
        {
            Destroy(gameObject);
        }
    }
}
