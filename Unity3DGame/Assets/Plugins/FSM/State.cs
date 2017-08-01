using UnityEngine;
using System.Collections;

namespace GDGeek{
	public class State {
		
		public delegate State GetCurrState(string name);
		private string name_ = "";
		protected string fatherName_ = "";
		public GetCurrState getCurrState = null;

		public string name{
			get{
				return name_;
			}
			set{
				name_ = value;
			}
		}

		public string fatherName{
			get{
				return fatherName_;
			}
			set{
				fatherName_ = value;
			}
		}

		public State(){
			
		}


		public virtual void start(){
			
		}

		public virtual void over(){
			
		}

		public virtual string postEvent(FSMEvent evt){
			return "";
		}
	}
}