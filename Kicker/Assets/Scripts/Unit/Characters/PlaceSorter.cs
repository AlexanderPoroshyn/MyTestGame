using UnityEngine;

[RequireComponent(typeof(PlaceChecker))]
public class PlaceSorter : MonoBehaviour
{
    private PlaceChecker placeChecker => GetComponent<PlaceChecker>();

    [SerializeField] private PlaceChecker.PlaceType[] allowedPlaces;

    public bool CheckRequirements()
    {
        for (int i = 0; i < allowedPlaces.Length; i++)
        {
            if (allowedPlaces[i] == placeChecker.GetPlace())
            {
                return true;
            }
        }
        return false;
    }
}
