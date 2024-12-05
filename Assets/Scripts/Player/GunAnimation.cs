using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunAnimation : MonoBehaviour {
    private Animator _shootAnimator;
    public static GunAnimation Instance;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        PlayerShoot.EOnPlayerShoot += PlayShoot;

        _shootAnimator = gameObject.GetComponent<Animator>();
    }
    private void PlayShoot() {
       _shootAnimator.SetTrigger("Shoot");
    }
    private void OnDestroy() {
        PlayerShoot.EOnPlayerShoot -= PlayShoot;
    }
}