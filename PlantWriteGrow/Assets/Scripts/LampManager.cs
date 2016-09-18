using UnityEngine;
using System;

public class LampManager : MonoBehaviour {

    // Localize the light strength modification 
    public static float LightStrength { private set; get; }

    // The collection of light components contained in the lamp manager.
    private Light[] _lamps;

    // The next interval for degrading the lamps.
    private int _tmrLampDecrementation;
    public const int LAMP_DEGRADE_RATE = 500;
    private const int MAX_LAMP_INTENSITY = 8;

	// Use this for initialization
	void Start () {
        // Figure out how many lamps there are.
        this._lamps = new Light[this.transform.childCount];

        // Add them all.
        for (int i = 0; i < this._lamps.Length; i++) {
            var lampObject = this.transform.GetChild(i);

            // Make sure that this lamp object has a child first.
            if (lampObject.childCount > 0) {
                this._lamps[i] = lampObject.GetChild(0).GetComponent<Light>();                
            }
        }

        // Initialize the first value of the light strenght: 35%
        LampManager.LightStrength = 0.35f;
	}
	
	// Update is called once per frame
	void Update () {
        // Make sure we're not dead.
        if (LampManager.LightStrength > 0) {
            // Degrade the strength of the lights.
            DegradeLamps();
        }
	}

    public void UpgradeLamps() {
        // Make sure we're not dead.
        if (LampManager.LightStrength <= 0) {
            return;
        }

        // Increment the light strengh, and update the lamps.
        LampManager.LightStrength += 0.05f;
        this.UpdateLampStrength();
    }

    private void DegradeLamps() {

        // Get the current system tickcount.
        int tick = Environment.TickCount;

        // Can we degrade the lamps?
        if (tick > this._tmrLampDecrementation) {
            // Yes.
            LampManager.LightStrength -= 0.01f;

            //Debug.Log(LampManager.LightStrength);

            // Update the lamps.
            this.UpdateLampStrength();

            // Set the time for the next degrade.
            this._tmrLampDecrementation = tick + LampManager.LAMP_DEGRADE_RATE;
        }
    }

    private void UpdateLampStrength() {
        // Make sure we're not dead.
        if (LampManager.LightStrength <= 0) {
            return;
        }

        // Update the intensity.
        foreach (var lamp in this._lamps) {
            lamp.intensity = LampManager.LightStrength * (float)LampManager.MAX_LAMP_INTENSITY;
        }
    }
}
