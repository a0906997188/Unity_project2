using UnityEngine;

public class ChooseMonster : MonoBehaviour
{
    public static GameObject SelectedCharacterPrefab { get; private set; }

    public void SelectCharacter(GameObject prefab)
    {
        SelectedCharacterPrefab = prefab;
        Debug.Log("¤w¿ï¾Ü¨¤¦â: " + prefab.name);
    }
}
