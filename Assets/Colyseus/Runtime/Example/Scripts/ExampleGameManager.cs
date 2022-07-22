using Colyseus;
using LucidSightTools;
using UnityEngine;
using System.Collections;

public class ExampleGameManager : MonoBehaviour
{
    public ColyseusNetworkedEntityView prefab;
	public ColyseusNetworkedEntityView prefabBall; //MODH
	public ColyseusNetworkedEntityView prefabMovingText; //MODH
	public ColyseusNetworkedEntityView prefabBallTaggedPlayer2;
	private int NumberOfEntities = 0;

	private void OnEnable()
    {
        ExampleRoomController.onAddNetworkEntity += OnNetworkAdd;
        ExampleRoomController.onRemoveNetworkEntity += OnNetworkRemove;
    }

	private void OnNetworkAdd(ExampleNetworkedEntity entity)
    {
        if (ExampleManager.Instance.HasEntityView(entity.id))
        {
            LSLog.LogImportant("View found! For " + entity.id);
        }
        else
        {
            LSLog.LogImportant("No View found for " + entity.id);
            CreateView(entity);
        }
    }

    private void OnNetworkRemove(ExampleNetworkedEntity entity, ColyseusNetworkedEntityView view)
    {
        RemoveView(view);
    }

    private void CreateView(ExampleNetworkedEntity entity)
    {
        LSLog.LogImportant("print: " + JsonUtility.ToJson(entity));

		Debug.Log("Entity xPos:" + entity.xPos.ToString());

		///////////NEW//////////////////
		/*if (entity.xScale > 2.0f || entity.yPos == 0.0002f)
		{
			ColyseusNetworkedEntityView newView2 = Instantiate(prefab);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, newView2);
			newView2.gameObject.SetActive(true);
		}
		else if (entity.xPos > 30.0f || entity.yPos == 0.001f)
		{
			ColyseusNetworkedEntityView scoreView2 = Instantiate(prefabMovingText);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, scoreView2);
			scoreView2.gameObject.SetActive(true);
		}
		else if (entity.xScale < 1.00f && entity.xScale > 0.900f)
		{
			ColyseusNetworkedEntityView ballView2 = Instantiate(prefabBallTaggedPlayer2);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView2);
			ballView2.gameObject.SetActive(true);
		}
		else if (entity.xPos < 0.000f)
		{
			ColyseusNetworkedEntityView ballView = Instantiate(prefabBall);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView);
			ballView.gameObject.SetActive(true);
		}*/
		///////////////NEW///////////////////

		//////////////////////////ORIGINAL OLD//////////////////////////////////////
		if (entity.xScale==2.5f)
        {
			ColyseusNetworkedEntityView newView = Instantiate(prefab);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, newView);
			newView.gameObject.SetActive(true);
		}
		else if(entity.xScale==0.99f)
        {
			ColyseusNetworkedEntityView ballView2 = Instantiate(prefabBallTaggedPlayer2);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView2);
			ballView2.gameObject.SetActive(true);
		}
		else if(entity.xScale==0.8f)
        {
			ColyseusNetworkedEntityView scoreView = Instantiate(prefabMovingText);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, scoreView);
			scoreView.gameObject.SetActive(true);
		}
		else if(entity.yPos== 0.0002f)
        {
			ColyseusNetworkedEntityView newView2 = Instantiate(prefab);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, newView2);
			newView2.gameObject.SetActive(true);
		}
		else if (entity.yPos == 0.001f)
		{
			ColyseusNetworkedEntityView scoreView2 = Instantiate(prefabMovingText);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, scoreView2);
			scoreView2.gameObject.SetActive(true);
		}
		else
        {
			ColyseusNetworkedEntityView ballView = Instantiate(prefabBall);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView);
			ballView.gameObject.SetActive(true);
		}
		//////////////////////////ORIGINAL OLD//////////////////////////////////////



		/*else if(NumberOfEntities == 2)
        {
			ColyseusNetworkedEntityView newView2 = Instantiate(prefab);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, newView2);
			newView2.gameObject.SetActive(true);
		}
		else if(NumberOfEntities == 1)
        {
			ColyseusNetworkedEntityView ballView2 = Instantiate(prefabBall);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView2);
			ballView2.gameObject.SetActive(true);
		}
		else if(NumberOfEntities == 0)
        {
			ColyseusNetworkedEntityView scoreView2 = Instantiate(prefabMovingText);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, scoreView2);
			scoreView2.gameObject.SetActive(true);
		}*/

		/*if (NumberOfEntities == 2)
		{
			ColyseusNetworkedEntityView newView = Instantiate(prefab);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, newView);
			newView.gameObject.SetActive(true);
		}
		else if (NumberOfEntities == 1)
        {
			if (NumberOfEntities == 1)
			{
				ColyseusNetworkedEntityView ballView2 = Instantiate(prefabBallTaggedPlayer2);
				ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView2);
				ballView2.gameObject.SetActive(true);
			}
			else if (NumberOfEntities == 4)
            {
				ColyseusNetworkedEntityView ballView = Instantiate(prefabBall);
				ExampleManager.Instance.RegisterNetworkedEntityView(entity, ballView);
				ballView.gameObject.SetActive(true);
			}
		}
		else if (NumberOfEntities == 0 || NumberOfEntities ==3)
		{
			ColyseusNetworkedEntityView scoreView = Instantiate(prefabMovingText);
			ExampleManager.Instance.RegisterNetworkedEntityView(entity, scoreView);
			scoreView.gameObject.SetActive(true);
		}*/

		NumberOfEntities++;
    }

    private void RemoveView(ColyseusNetworkedEntityView view)
    {
        view.SendMessage("OnEntityRemoved", SendMessageOptions.DontRequireReceiver);
    }
}