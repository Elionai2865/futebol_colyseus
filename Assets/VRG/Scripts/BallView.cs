using LucidSightTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;

public class BallView : ExampleNetworkedEntityView
{

	public score thatScore;

	//Override para anular essa função indesejável que tem origem no ExampleNetworkedEntityView
	protected override void SetStateStartPos()
	{
	}

	protected override void Start()
	{
		autoInitEntity = false;
		base.Start();
		//controller = gameObject.AddComponent<CharacterController>();

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
		ExampleManager.CreateNetworkedEntityWithTransform(new Vector3(0f, 0f, 0f), Quaternion.identity, new Dictionary<string, object>() { ["prefab"] = "VMEViewPrefab" }, this, (entity) => {
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

		if (!HasInit || !IsMine) return;

	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Ball")
		{
			thatScore.scoreIncrement();
		}
	}
}
