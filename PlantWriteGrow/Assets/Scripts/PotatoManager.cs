using UnityEngine;

public class PotatoManager : MonoBehaviour {

    private Transform[] _potatoes;
    public float StartYPos = -100;
    private const float MAX_POTATO_SCALE = 2.0f;
    private const float MID_POINT = 0.5f;
    public float CurGrowPoint { private set; get; }
    public float LifeLeft { private set; get; }
    public Material SurfaceMaterial;

	// Use this for initialization
	void Start () {

        // Figure out how many child potatoes there are.
        this._potatoes = new Transform[this.transform.childCount];

        // Add them all.
        for (int i = 0; i < this._potatoes.Length; i++) {
            this._potatoes[i] = this.transform.GetChild(i);
        }

        this.LifeLeft = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (LampManager.LightStrength < PotatoManager.MID_POINT) {
            this.LifeLeft -= 0.001f;
            // TODO: Update color here.
            Debug.Log(SurfaceMaterial.color);
        } else {
            this.CurGrowPoint += 0.001f;
        }


	
        foreach (var child in _potatoes) {
            float val = PotatoManager.MAX_POTATO_SCALE * this.CurGrowPoint;

            if (val > PotatoManager.MAX_POTATO_SCALE) {
                Debug.Log("You win");
                return;
            }

            // Find out if the potatoes are freezing or growing.
            child.transform.localScale = new Vector3(val, val, val);
        }

        this.transform.localPosition = new Vector3(
            this.transform.localPosition.x,
            (1 - this.CurGrowPoint) * StartYPos,
            this.transform.localPosition.z);
	}
}
