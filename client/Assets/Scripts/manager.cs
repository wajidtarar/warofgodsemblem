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
	
		private SmartFox smartFox;
	public LogLevel logLevel = LogLevel.DEBUG;
	
	// Use this for initialization
	void Start () {
	//GameObject.Find("Player").AddComponent("AnimationController");

		
		if (!SmartFoxConnection.IsInitialized) {
			Application.LoadLevel("Connection");
			return;
		}
		else{
			smartFox = SmartFoxConnection.Connection;
			smartFox.AddEventListener(SFSEvent.OBJECT_MESSAGE, OnObjectMessage);
			smartFox.AddEventListener(SFSEvent.PUBLIC_MESSAGE, OnUserUpdate);
			smartFox.AddEventListener(SFSEvent.EXTENSION_RESPONSE,onr);

		}
		
		ISFSObject obj=new  SFSObject();
		obj.PutUtfString("name",ConnectionGUI.username);
		GameObject.Find ("PlayerCustom").name = ConnectionGUI.username;
		//sfs.Send(new JoinRoomRequest(room));
		smartFox.Send(new ExtensionRequest("SomeNumberHandle",obj));


}
		
	

	void onr(BaseEvent e)
	{
		
		string cmd=(string)e.Params["cmd"];
		ISFSObject obj=(SFSObject)e.Params["params"];
		if(cmd=="SpawnNewPlayer")
		{
			if (!GameObject.Find (obj.GetUtfString("name"))){
			Debug.Log(obj.GetInt("userID"));
			Debug.Log(obj.GetFloat("varX"));
			Debug.Log(obj.GetFloat("varY"));
			Debug.Log(obj.GetFloat("varZ"));
				
			GameObject player = new GameObject(obj.GetUtfString("name"));
			Animation playerModel = Animation.Instantiate(Resources.LoadAssetAtPath("Assets/Objects/penelopeFBX.fbx",typeof(Animation)) )as Animation;
			playerModel.transform.parent = player.transform;
			player.AddComponent("CharacterController");
			
			
			AnimationControllers anim = new AnimationControllers();
			
			
			player.AddComponent("AnimationControllers");
			anim = player.GetComponent("AnimationControllers") as AnimationControllers;
			anim.animationTarget = playerModel;
			float xv = obj.GetFloat("varX");
			Vector3 v = new Vector3(obj.GetFloat("varX"),obj.GetFloat("varY"),obj.GetFloat("varZ"));

			player.transform.position = v;
			//	Debug.Log(obj.GetInt("countlist"));
			}
			else if (obj.GetUtfString("name") == ConnectionGUI.username)
			{
				
							Debug.Log("extension response is coming");
				
				Debug.Log(obj.GetInt("userID"));
			Debug.Log(obj.GetFloat("varX"));
			Debug.Log(obj.GetFloat("varY"));
			Debug.Log(obj.GetFloat("varZ"));
					Vector3 v = new Vector3(obj.GetFloat("varX"),obj.GetFloat("varY"),obj.GetFloat("varZ"));
		
					GameObject.Find (ConnectionGUI.username).transform.position = v;
			}
		
		}
			else if(cmd=="updatexyz")
		
			
		{
			//Debug.Log ("working update");
			if (obj.GetUtfString("name") == ConnectionGUI.username)
			{
			
			}
			else{
					
				Vector3 v = new Vector3(obj.GetFloat("varX"),0,obj.GetFloat("varZ"));
				if(GameObject.Find (obj.GetUtfString("name")))
				{
						
					GameObject.Find (obj.GetUtfString("name")).transform.position = v;
				}
				else{
									GameObject player = new GameObject(obj.GetUtfString("name"));
						Animation playerModel = Animation.Instantiate(Resources.LoadAssetAtPath("Assets/Objects/penelopeFBX.fbx",typeof(Animation)) )as Animation;
						playerModel.transform.parent = player.transform;
						player.AddComponent("CharacterController");
						AnimationControllers anim = new AnimationControllers();
						player.AddComponent("AnimationControllers");
						anim = player.GetComponent("AnimationControllers") as AnimationControllers;
						anim.animationTarget = playerModel;
						float xv = obj.GetFloat("varX");
						v = new Vector3(obj.GetFloat("varX"),0,obj.GetFloat("varZ"));
						player.transform.position = v;
							
				}
			}
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
	

 void FixedUpdate () {
		smartFox.ProcessEvents();
	}
	// Update is called once per frame
	void Update () {
		ISFSObject obj=new  SFSObject();
		obj.PutUtfString("name",ConnectionGUI.username);
		float varx = (GameObject.Find (ConnectionGUI.username).transform.position.x);
		float vary = (GameObject.Find (ConnectionGUI.username).transform.position.y);
		float varz = (GameObject.Find (ConnectionGUI.username).transform.position.z);
		obj.PutFloat("varX",varx);
		obj.PutFloat("varY",0);
		obj.PutFloat("varZ",varz);
		//sfs.Send(new JoinRoomRequest(room));
		smartFox.Send(new ExtensionRequest("updatexyz",obj));
	
		//	smartFox.Send(new PublicMessageRequest("hello"));
	}
	

}
