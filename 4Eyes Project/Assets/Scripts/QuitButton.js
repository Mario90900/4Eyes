#pragma strict
var quitNormal : Texture2D;
var quitHover : Texture2D;

function Start () {

}

function OnMouseEnter () {

     guiTexture.texture = quitHover; 

}

function OnMouseExit () {
  
     guiTexture.texture = quitNormal;

}

function OnMouseDown () {

     Application.Quit();

}