using Assets.CodeBase.Core;
using UnityEngine;

public class Player : IWatcher
{
    public Vector3 Position { get; set; }

    public void Save(PersistentData persistentData)
    {
         Position = GameObject.FindGameObjectWithTag("Player").transform.position;
         persistentData.HeroPosition = Position;
    }

    public void Load(PersistentData persistentData)
    {
         Position = persistentData.HeroPosition;
    }
}
