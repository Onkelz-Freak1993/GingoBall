using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNew : MonoBehaviour {

	public Animator CameraObject;
	public GameObject PanelControls;
	public GameObject PanelVideo;
	public GameObject PanelGame;
	public GameObject PanelKeyBindings;
	public GameObject PanelMovement;
	public GameObject PanelCombat;
	public GameObject PanelGeneral;
	public GameObject hoverSound;
	public GameObject sfxhoversound;
	public GameObject clickSound;
	public GameObject areYouSure;
	
	// campaign button sub menu
	public GameObject endlessBtn;
	public GameObject multiplayerBtn;
	public GameObject loadMapBtn;
	public GameObject mpmenu;
	public GameObject playbg;

	// highlights
	public GameObject lineGame;
	public GameObject lineVideo;
	public GameObject lineControls;
	public GameObject lineKeyBindings;
	public GameObject lineMovement;
	public GameObject lineCombat;
	public GameObject lineGeneral;


	//Useful Functions
	public static Color hexToColor(string hex)
	{
		hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
		hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
		byte a = 255;//assume fully visible unless specified in hex
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		//Only use alpha if the string has enough characters
		if(hex.Length == 8){
			a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}

	// ##############

	public void  PlayCampaign (){
		areYouSure.gameObject.active = false;
		endlessBtn.gameObject.active = true;
		multiplayerBtn.gameObject.active = true;
		loadMapBtn.gameObject.active = true;
		playbg.gameObject.active = true;
	}

	public void  PlayMultiplayer(){
		endlessBtn.gameObject.active = false;
		multiplayerBtn.gameObject.active = false;
		loadMapBtn.gameObject.active = false;
		mpmenu.gameObject.active = true;
		playbg.gameObject.active = false;
	}
	
	public void  CloseMultiplayer(){
		endlessBtn.gameObject.active = true;
		multiplayerBtn.gameObject.active = true;
		loadMapBtn.gameObject.active = true;
		mpmenu.gameObject.active = false;
		playbg.gameObject.active = true;
	}
	
	public void  DisablePlayCampaign (){
		endlessBtn.gameObject.active = false;
		multiplayerBtn.gameObject.active = false;
		loadMapBtn.gameObject.active = false;
		mpmenu.gameObject.active = false;
		playbg.gameObject.active = false;
	}

	public void  Position2 (){
		DisablePlayCampaign();
		CameraObject.SetFloat("Animate",1);
	}

	public void  Position1 (){
		CameraObject.SetFloat("Animate",0);
	}

	public void  GamePanel (){
		PanelControls.gameObject.active = false;
		PanelVideo.gameObject.active = false;
		PanelGame.gameObject.active = true;
		PanelKeyBindings.gameObject.active = false;

		lineGame.gameObject.active = true;
		lineControls.gameObject.active = false;
		lineVideo.gameObject.active = false;
		lineKeyBindings.gameObject.active = false;
	}

	public void  VideoPanel (){
		PanelControls.gameObject.active = false;
		PanelVideo.gameObject.active = true;
		PanelGame.gameObject.active = false;
		PanelKeyBindings.gameObject.active = false;

		lineGame.gameObject.active = false;
		lineControls.gameObject.active = false;
		lineVideo.gameObject.active = true;
		lineKeyBindings.gameObject.active = false;
	}

	public void  ControlsPanel (){
		PanelControls.gameObject.active = true;
		PanelVideo.gameObject.active = false;
		PanelGame.gameObject.active = false;
		PanelKeyBindings.gameObject.active = false;

		lineGame.gameObject.active = false;
		lineControls.gameObject.active = true;
		lineVideo.gameObject.active = false;
		lineKeyBindings.gameObject.active = false;
	}

	public void  KeyBindingsPanel (){
		PanelControls.gameObject.active = false;
		PanelVideo.gameObject.active = false;
		PanelGame.gameObject.active = false;
		PanelKeyBindings.gameObject.active = true;

		lineGame.gameObject.active = false;
		lineControls.gameObject.active = false;
		lineVideo.gameObject.active = true;
		lineKeyBindings.gameObject.active = true;
	}

	public void  MovementPanel (){
		PanelMovement.gameObject.active = true;
		PanelCombat.gameObject.active = false;
		PanelGeneral.gameObject.active = false;

		lineMovement.gameObject.active = true;
		lineCombat.gameObject.active = false;
		lineGeneral.gameObject.active = false;
	}

	public void  CombatPanel (){
		PanelMovement.gameObject.active = false;
		PanelCombat.gameObject.active = true;
		PanelGeneral.gameObject.active = false;

		lineMovement.gameObject.active = false;
		lineCombat.gameObject.active = true;
		lineGeneral.gameObject.active = false;
	}

	public void  GeneralPanel (){
		PanelMovement.gameObject.active = false;
		PanelCombat.gameObject.active = false;
		PanelGeneral.gameObject.active = true;

		lineMovement.gameObject.active = false;
		lineCombat.gameObject.active = false;
		lineGeneral.gameObject.active = true;
	}

	public void  PlayHover (){
		hoverSound.GetComponent<AudioSource>().Play();
	}

	public void  PlaySFXHover (){
		sfxhoversound.GetComponent<AudioSource>().Play();
	}

	public void  PlayClick (){
		clickSound.GetComponent<AudioSource>().Play();
	}

	public void  AreYouSure (){
		areYouSure.gameObject.active = true;
		DisablePlayCampaign();
	}

	public void  No (){
		areYouSure.gameObject.active = false;
	}

	public void  Yes (){
		Application.Quit();
	}


	public void endlessStart(){
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.backgroundColor = hexToColor("#314D7900");
		SceneManager.LoadScene (1);
	}
}
