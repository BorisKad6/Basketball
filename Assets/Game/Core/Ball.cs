using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    [SerializeReference] private Rigidbody2D _rb;

    private IBallDestanationHandler _destanationHandler;

    public float Speed;
    public void Init(IBallDestanationHandler destanationHandler, Vector2 position, float speed)
    {
        _destanationHandler = destanationHandler;
        if(_rb == null) _rb = GetComponent<Rigidbody2D>();  
        Speed = speed;
        transform.position = position;
    }
    public void Update()
    {
        _rb.position += Vector2.right * Speed * Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            _destanationHandler.OnDestanationReached();
            OnExit();
            Destroy(gameObject);
        }
    }
    public virtual void OnExit()
    {

    }
}
