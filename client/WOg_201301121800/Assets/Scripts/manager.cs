using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Entities.Variables;
using Sfs2X.Requests;
using Sfs2X.Logging;
using UnityEngineInternal;


public class manager : MonoBehaviour {

	public GameObject MyCharacter;
	
public int varx;	
		private SmartFox smartFox;
	public LogLevel logLevel = LogLevel.DEBUG;
	
	// Use this for initialization
	void Start () {
	//GameObject.Find("Player").AddComponent("AnimationController");
		
		GameObject player = new GameObject("MyPlayer");
		Animation playerModel = Animation.Instantiate(Resources.LoadAssetAtPath("Assets/Objects/penelopeFBX.fbx",typeof(Animation)) )as Animation;
		playerModel.transform.parent = player.transform;
		player.AddComponent("CharacterController");
		
		
		AnimationControllers anim = new AnimationControllers();
		
		
		player.AddComponent("AnimationControllers");
		anim = player.GetComponent("AnimationControllers") as AnimationControllers;
		anim.animationTarget = playerModel;
		//player.AddComponent("GameObject",playerModel,typeof(GameObject));
		//Component comp;
		
		
		//player.AddComponent("AnimationController");
		
		//playerModel.transform.parent = player.transform;
		
		//animScript = player.transform.GetComponent("AnimationController");

    	//animScript.animationTarget = playerModel;

		//AssetDatabase.LoadMainAssetAtPath("Assets/Objects/penelopeFBX.fbx") as GameObject;
		
		
		
		//newchar.AddComponent(GameObject.Find("Player").gameObject.GetComponent("penelopeFBX").ToString());
		//GameObject mychar=GameObject.Instantiate(GameObject.Find("Player")) as  GameObject;
		//mychar.gameObject.GetComponent("penelopeFBX");
		varx = 1;
		
		if (!SmartFoxConnection.IsInitialized) {
			Application.LoadLevel("Connection");
			return;
		}
		else{
			smartFox = SmartFoxConnection.Connection;
			smartFox.AddEventListener(SFSEvent.OBJECT_MESSAGE, OnObjectMessage);
			smartFox.AddEventListener(SFSEvent.PUBLIC_MESSAGE, OnUserUpdate);

		}
		
	
}
		
void OnObjectMessage(BaseEvent evt)
{
    ISFSObject obj = (SFSObject)evt.Params["message"];

		Debug.Log ("working");
}
	
	void OnUserUpdate(BaseEvent evt)
{
		Debug.Log ("working");
}
	

 
	// Update is called once per frame
	void Update () {
		ISFSObject newobj = SFSObject.NewInstance();
		newobj.PutInt("x",varx);
		//Debug.Log(MyCharacter.transform.position.x);

		varx++;
		//	smartFox.Send(new PublicMessageRequest("hello"));
	}
	

}
