using UnityEngine;

public class LevelIncreaseManager: MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private int levelIndex;
    [SerializeField]
    private GameObject player;
    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += OnWinnerDcided;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= OnWinnerDcided;
        
    }
    public void OnWinnerDcided(GameObject _winner, GameObject _looser)
    {
        if(player != _winner)
        {
            playerData.DidLastBattleUnlockNewLevel.Value = false;
            return;
        }
        if (levelIndex == playerData.MaximumLevelUnlocked.Value)
        {
            playerData.DidLastBattleUnlockNewLevel.Value = true;
            playerData.MaximumLevelUnlocked.Value++;
        }
        else playerData.DidLastBattleUnlockNewLevel.Value = false;

    }

}