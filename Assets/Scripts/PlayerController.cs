using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    public float MovementSpeed;

    public float Jump;

    public float GroundHitRange;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = this.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Move(Vector3.right);
        }
        
         if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            Move(Vector3.left);
        }

          if (IsOnGround() && Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            JumpNow(Vector2.up);
        }
    }

    private void Move(Vector3 position) 
    {
        this.playerObject.transform.position += position * this.MovementSpeed * Time.deltaTime;
    }

    public void JumpNow(Vector2 direction) 
    {
        var body = this.gameObject.GetComponent<Rigidbody2D>();
        body.AddForce(direction * Jump * 100);
    }

    public bool IsOnGround()
    {
        var hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, GroundHitRange);
        return hit.collider != null;
    }
    
    void OnDrawGizmos() 
    {
        var hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down, GroundHitRange);
        Debug.DrawRay(this.gameObject.transform.position, Vector3.down * GroundHitRange, Color.red);
    }
}
