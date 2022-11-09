using Assets.CodeBase.Core;
using UnityEngine;

internal class SaveLoadService: ISaveLoadService
{
    private GameObject _player = null;
    public void Save()
    {
        if (HasNotPlayer())
            InitPlayer();

        SaveSpawnPoint();
    }

    public void Load()
    {
        GetSpawnPointPosition(out string spawnPointPosition);

        if (spawnPointPosition != "")
            ChangeSpawnPointObjectPosition(spawnPointPosition);
    }

    private void GetSpawnPointPosition(out string spawnPoint)
    {
        spawnPoint = PlayerPrefs.GetString("spawnPoint");
    }

    private void ChangeSpawnPointObjectPosition(string spawnPointPosition)
    {
        GameObject spawnPointObj = GameObject.FindGameObjectWithTag("SpawnPoint");
        spawnPointObj.transform.position = JsonUtility.FromJson<Vector3>(spawnPointPosition);
    }

    private bool HasNotPlayer()
    {
        return _player == null;
    }
    private void InitPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void SaveSpawnPoint()
    {
        PlayerPrefs.SetString("spawnPoint", JsonUtility.ToJson(_player.transform.position));
        PlayerPrefs.Save();
    }
}
