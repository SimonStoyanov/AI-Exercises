using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace node_canvas{

	[Description("espectro patrolum")]
	public class ActivePatrolCurve : ActionTask{

        public GameObject enable_bgcurve;

		protected override string OnInit(){
            return null;
		}

		protected override void OnExecute(){
            enable_bgcurve.SetActive(true);
        }

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
            enable_bgcurve.SetActive(false);
        }

        protected override void OnPause(){
			
		}
	}
}