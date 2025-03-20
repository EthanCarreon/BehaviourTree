using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class GuardMoveAT : ActionTask {

		public Transform[] posToMoveTo;
		public int foodIndex = 0;
		public float speed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			float step = speed * Time.deltaTime;
			agent.transform.position = Vector3.MoveTowards(agent.transform.position, posToMoveTo[foodIndex].transform.position, step);

			float distToPos = Vector3.Distance(agent.transform.position, posToMoveTo[foodIndex].transform.position);
			if (distToPos <= 0.5f)
			{
				foodIndex++;
                EndAction(true);
            }

			if (foodIndex >= posToMoveTo.Length)
			{
				foodIndex = posToMoveTo.Length - 1;
			}
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}