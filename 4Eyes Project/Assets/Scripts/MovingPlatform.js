#pragma strict
private var Xpos : float;
private var Ypos : float;
private var max : boolean;
var Vert : boolean;
var GoOpposite : boolean; //To start going the other way instead
var maxAmount : float;
var step : float;

function Start () {
	Xpos = transform.position.x;
	Ypos = transform.position.y;
	max = false;
}

function Update () {
	//SET THE MAX
	if(Vert){ //Vertical
		if (!GoOpposite){
			if(transform.position.y >= Ypos + maxAmount){
				max = true;
			} else if(transform.position.y <= Ypos){
				max = false;
			}
		} else {
			if(transform.position.y <= Ypos - maxAmount){
				max = true;
			} else if(transform.position.y >= Ypos){
				max = false;
			}
		}
	} 
	else { //horizontal
		if (!GoOpposite){
			if(transform.position.x >= Xpos + maxAmount) {
				max = true;
			} else if(transform.position.x <= Xpos) {
				max = false;
			}
		} else {
			if(transform.position.x <= Xpos - maxAmount) {
				max = true;
			} else if(transform.position.x >= Xpos) {
				max = false;
			}
		}
	}
	
	//MOVING THE PLATFORM
	if(Vert){ // Vertical movement
		if (!GoOpposite){
			if(!max){
				transform.position.y += step;
			} else {
				transform.position.y -= step;
			}
		} else {
			if(!max){
				transform.position.y -= step;
			} else {
				transform.position.y += step;
			}
		}
	} else { //Horizontal movement
		if (!GoOpposite){
			if(!max){
				transform.position.x += step;
			} else {
				transform.position.x -= step;
			}
		} else {
			if(!max){
				transform.position.x -= step;
			} else {
				transform.position.x += step;
			}
		}
	}
}