using UnityEngine;
using System.Collections;

public class PotatoManager : MonoBehaviour {

    private Transform[] _potatoes;
    public float StartYPos = -100;
    private const float MAX_POTATO_SCALE = 2.0f;
    private const float MID_FREEZING_POINT = 0.5f;

	// Use this for initialization
	void Start () {
        // Figure out how many child potatoes there are.
        this._potatoes = new Transform[this.transform.childCount];

        // Add them all.
        for (int i = 0; i < this._potatoes.Length; i++) {
            this._potatoes[i] = this.transform.GetChild(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
        foreach (var child in _potatoes) {
            float val = LampManager.LightStrength * PotatoManager.MAX_POTATO_SCALE;

            // Find out if the potatoes are freezing or growing.
            child.transform.localScale = new Vector3(val, val, val);
        }

        this.transform.localPosition = new Vector3(
            this.transform.localPosition.x,
            (1 - LampManager.LightStrength) * StartYPos,
            this.transform.localPosition.z);
	}
}
