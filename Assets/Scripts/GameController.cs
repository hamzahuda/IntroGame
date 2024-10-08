using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI distanceToClosestPickupText;
    private GameObject[] pickUps;
    private float minDistance;
    private GameObject nearestPickup;
    private LineRenderer lineRenderer;

    void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");
        minDistance = Mathf.Infinity;
        for (int i = 0; i < pickUps.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, pickUps[i].transform.position);
            if (distance < minDistance) {
                if (nearestPickup) {
                    nearestPickup.GetComponent<Renderer>().material.color = Color.white;
                }
                
                nearestPickup = pickUps[i];
                nearestPickup.GetComponent<Renderer>().material.color = Color.blue;

                lineRenderer.SetPosition (0, transform.position);
                lineRenderer.SetPosition(1, nearestPickup.transform.position);
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.2f;

                minDistance = distance;
            }
        }
        
        distanceToClosestPickupText.text = "Closest Pickup's Distance: " + minDistance.ToString("0.00");
    }
}
