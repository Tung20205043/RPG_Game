using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour {
    public static ChestManager Instance { get; private set; }

    [SerializeField] private Button openButton;
    [SerializeField] private AudioSource openSound;
    private bool opened = false;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
        Instance = this;
    }
    private void OnTriggerEnter(Collider other) {
        if (opened) return;
        if (other.CompareTag("Player")) {
            openButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (opened) return;
        if (other.CompareTag("Player")) {
            openButton.gameObject.SetActive(false);
        }
    }
    public void OpenChest() {
        animator.SetTrigger("Open");
        openSound.Play();
        opened = true;
        openButton.gameObject.SetActive(false);
        
    }
}
