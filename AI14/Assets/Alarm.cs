using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace AI13{

	[Description("Alarmeame esta Antonio")]
	public class Alarm : ActionTask{

        public FSM_Alarm fsm_alarm;

		protected override string OnInit(){
            fsm_alarm.enabled = true;
            return "FSM ALARM ACTIVED";
		}

		protected override void OnExecute(){
			EndAction(true);
		}

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
            fsm_alarm.enabled = false;
        }

        protected override void OnPause(){
			
		}
	}
}