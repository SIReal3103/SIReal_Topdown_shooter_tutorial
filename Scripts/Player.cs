using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector3 moveInput;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    public GameObject ghostEffect;
    public float ghostDelaySeconds;
    private Coroutine dashEffectCoroutine;

    public Animator animator;
    public SpriteRenderer characterSR;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false)
        {
            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;
            StopDashEffect();
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }

    void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }

    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = characterSR.sprite;
            ghost.GetComponentInChildren<SpriteRenderer>().sprite = currentSprite;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghostDelaySeconds);
        }
    }
}
