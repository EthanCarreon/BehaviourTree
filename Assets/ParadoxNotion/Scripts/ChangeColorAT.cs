using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ChangeColorAT : ActionTask {
		public Color cookedColor;
		public Color overCookedColor;
		public Color underCookedColor;
		public MeshRenderer[] meshRenderer;
		public int foodIndex = 0;


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
			int cookInt = Random.Range(0, 3);
			if (cookInt == 1)
			{
                meshRenderer[foodIndex].material.color = underCookedColor;
            }
			else if (cookInt == 2)
			{
                meshRenderer[foodIndex].material.color = overCookedColor;
            }
			else
			{
                meshRenderer[foodIndex].material.color = cookedColor;
            }
			foodIndex++;
            EndAction(true);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}