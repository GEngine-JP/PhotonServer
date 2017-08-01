using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace GDGeek{
	public class FSM {

		private Dictionary<string, State> states_ = new Dictionary<string, State>();
		private ArrayList currState_ = new ArrayList();

		public FSM(){
			State root = new State();
			root.name = "root";
			this.states_["root"]  = root;
			this.currState_.Add(root);
		}
		public void addState(string stateName, State state){
			this.addState (stateName, state, "");		
		}
		public void addState(string stateName, State state, string fatherName){	
			if(fatherName == ""){
				state.fatherName = "root";
			}
			else{
				state.fatherName = fatherName;
			}
			state.getCurrState = delegate (string name){	
				for(int i = 0; i< this.currState_.Count; ++i){
					State s = this.currState_[i] as State;
					if(s.name == name)
					{
						return s;
					}
					
				}	
				return null;
			};
			this.states_[stateName] = state;
		}

	
		public void translation(string name)
		{
			State target = this.states_[name] as State;//target state
			
			if (target == null)//if no target return!
			{
				return;
			}
			
			
			//if current, reset
			if(target == this.currState_[this.currState_.Count-1])
			{
				target.over();
				target.start();
				return;
			}
			
			
			
			State publicState = null;
			
			ArrayList stateList = new ArrayList();
			
			State tempState = target;
			string fatherName = tempState.fatherName;
			
			//do loop 
			while(tempState != null)
			{
				//reiterator current list
				for(var i = this.currState_.Count -1; i >= 0; i--){
					State state = this.currState_[i] as State;
					//if has public 
					if(state == tempState){
						publicState = state;	
						break;
					}
				}
				
				//end
				if(publicState != null){
					break;
				}
				
				//else push state_list
				stateList.Insert(0, tempState);
				//state_list.unshift(temp_state);
				
				if(fatherName != ""){
					tempState = this.states_[fatherName] as State;
					fatherName = tempState.fatherName;
				}else{
					tempState = null;
				}
				
			}
			//if no public return
			if (publicState == null){
				return;
			}
			
			ArrayList newCurrState = new ArrayList();
			bool under = true;
			//-- 析构状态
			for(int i2 = this.currState_.Count -1; i2>=0; --i2)
			{
				State state2 = this.currState_[i2] as State;
				if(state2 == publicState)
				{
					under = false;
				}
				if(under){
					state2.over();
				}
				else{
					newCurrState.Insert(0, state2);
				}
				
			}
			
			
			//-- 构建状态
			for(int i3 = 0; i3 < stateList.Count; ++i3){
				State state3 = stateList[i3] as State;
				state3.start();
				newCurrState.Add(state3);
			}
			this.currState_ = newCurrState;
		}


		
		public State getCurrState(string name)
		{
			var self = this;
			for(var i =0; i< self.currState_.Count; ++i)
			{
				State state = self.currState_[i] as  State;
				if(state.name == name)
				{
					return state;
				}
			}
			
			return null;
			
		}
		
		public void init(string state_name){
			var self = this;
			self.translation(state_name);
		}
		
		
		public void shutdown(){
			for(int i = this.currState_.Count-1; i>=0; --i){
				State state =  this.currState_[i] as State;
				state.over();
			}
			this.currState_ = null;  
		}

		public void post(string msg){
			FSMEvent evt = new FSMEvent();
			evt.msg = msg;
			this.postEvent(evt);
		}
		public void postEvent(FSMEvent evt){
			for(int i =0; i< this.currState_.Count; ++i){
				State state = this.currState_[i] as State;
				string stateName = state.postEvent(evt) as string;
				if(stateName != ""){
					this.translation(stateName);
					break;
				}
			}
		}
	}
}
