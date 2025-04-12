using UnityEngine;

public class GridTile : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ChooseMonster.SelectedCharacterPrefab != null)
        {
            Vector3 spawnPosition = transform.position;

            Instantiate(ChooseMonster.SelectedCharacterPrefab, spawnPosition, Quaternion.identity);

            Debug.Log("在 " + spawnPosition + " 生成角色！");
        }
        else
        {
            Debug.LogWarning("尚未選擇角色，請先從 UI 選擇！");
        }
    }
}
