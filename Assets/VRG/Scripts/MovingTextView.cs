using LucidSightTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;


public class MovingTextView : ExampleNetworkedEntityView
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float playerSpeed = 2.0f;
	private float jumpHeight = 1.0f;
	private float gravityValue = 0;
	private int flagSetPosition = 0;

	public score theScore;

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
		ExampleManager.CreateNetworkedEntityWithTransform(new Vector3(0f, 0.001f, 0f), Quaternion.identity, new Dictionary<string, object>() { ["prefab"] = "VMEViewPrefab" }, this, (entity) => {
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

		GetComponent<TextMesh>().text = transform.localPosition.z.ToString();

		if (!HasInit || !IsMine) return;

		Vector3 Vec = transform.localPosition;
		Vec.z = theScore.scorePlayer1;
		Vec.y = theScore.tries;
		transform.localPosition = Vec;
	}
}
