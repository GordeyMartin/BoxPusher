using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public Transform targetPosition;

    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;

    public GameObject PlayerWonPanel;

    Animator animator;

    private void Awake() {
        targetPosition.position = transform.position;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerWonPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xVelocity", movement.x);
        animator.SetFloat("yVelocity", movement.y);

        bool movingX = Mathf.Abs(movement.x) > 0;
        bool movingY = Mathf.Abs(movement.y) > 0;

        animator.SetBool("MovingX", movingX);
        animator.SetBool("MovingY", movingY);

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f && 
            !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, UnwalkableLayer)) {
                if (Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, MoveableLayer)) {
                    if (!Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, UnwalkableLayer)) {
                        targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                    }
                } else {
                    targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 && movement.y != 0)
        {
            movement = new Vector2(0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.transform.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
        }
    }
}
