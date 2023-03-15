using UnityEngine;

[RequireComponent(typeof(Place))]
public class PlaceSorter : MonoBehaviour
{
    private Place place => GetComponent<Place>();

    [SerializeField] private Place.PlaceType[] allowedPlaces;

    public bool CheckRequirements()
    {
        for (int i = 0; i < allowedPlaces.Length; i++)
        {
            if (allowedPlaces[i] == place.GetPlace(transform.position))
            {
                return true;
            }
        }
        return false;
    }
}
