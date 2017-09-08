using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private int count;
	public float Speed;
	public Text countText;
	public Text winText;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count=0;
		SetCountText();
		winText.text="";
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		
		Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);
		rb.AddForce(movement*Speed);

	}
	void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false); 
			count+=1; 
			SetCountText();
		} 
    }
	void SetCountText()
	{
		countText.text="Count:"+count.ToString();
		if(count>=11)
		{
			winText.text="You Win!!!";
		}
	}
}
