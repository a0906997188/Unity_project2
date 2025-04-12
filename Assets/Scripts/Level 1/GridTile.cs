using UnityEngine;

public class GridTile : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ChooseMonster.SelectedCharacterPrefab != null)
        {
            Vector3 spawnPosition = transform.position;

            Instantiate(ChooseMonster.SelectedCharacterPrefab, spawnPosition, Quaternion.identity);

            Debug.Log("�b " + spawnPosition + " �ͦ�����I");
        }
        else
        {
            Debug.LogWarning("�|����ܨ���A�Х��q UI ��ܡI");
        }
    }
}
