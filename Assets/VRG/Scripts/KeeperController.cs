using LucidSightTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;

public class KeeperController : ExampleNetworkedEntityView
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float playerSpeed = 2.0f;
	private float jumpHeight = 1.0f;
	private float gravityValue = 0;
	private int flagSetPosition = 0;

	//Override para anular essa função indesejável que tem origem no ExampleNetworkedEntityView
	protected override void SetStateStartPos()
	{
	}

	protected override void Start()
	{
		autoInitEntity = false;
		base.Start();
		controller = gameObject.AddComponent<CharacterController>();

		StartCoroutine("WaitForConnect");
	}

	IEnumerator WaitForConnect()
	{
		if (ExampleManager.Instance.CurrentUser != null && !IsMine) yield break;

		while (!ExampleManager.Instance.IsInRoom)
		{
			yield return 0;
		}
		LSLog.LogImportant("HAS JOINED ROOM - CREATING ENTITY");
		ExampleManager.CreateNetworkedEntityWithTransform(new Vector3(0f, 0.0002f, 0f), Quaternion.identity, new Dictionary<string, object>() { ["prefab"] = "VMEViewPrefab" }, this, (entity) => {
			LSLog.LogImportant($"Network Entity Ready {entity.id}");
		});
	}

	public override void OnEntityRemoved()
	{
		base.OnEntityRemoved();
		LSLog.LogImportant("REMOVING ENTITY", LSLog.LogColor.lime);
		Destroy(this.gameObject);
	}

	protected override void Update()
	{
		base.Update();

		/*//Printando os estados que eu quero checar
		Debug.Log("IsMine: " + IsMine);
		Debug.Log("HasInit: " + HasInit);
		Debug.Log("IsEntityOwner: " + IsEntityOwner);
		Debug.Log("OwnerId: " + OwnerId);
		Debug.Log("RefId: " + RefId);
		Debug.Log("Id: " + Id);
		Debug.Log("CreationId: " + CreationId);*/

		if (!HasInit || !IsMine) return;

		/*Vector3 Vec = transform.localPosition;  //CONTROLE ANTIGO PELO TECLADO
		Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
		transform.localPosition = Vec;*/
	}
}
