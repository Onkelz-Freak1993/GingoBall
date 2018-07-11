using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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
	
	// campaign MP button sub menu
	public GameObject mplan;
	public GameObject mpcanvas;
	public GameObject settingscanvas;

	// highlights
	public GameObject lineGame;
	public GameObject lineVideo;
	public GameObject lineControls;
	public GameObject lineKeyBindings;
	public GameObject lineMovement;
	public GameObject lineCombat;
	public GameObject lineGeneral;

	public string hostPort;



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
		areYouSure.gameObject.SetActive(false);
		endlessBtn.gameObject.SetActive(true);
		multiplayerBtn.gameObject.SetActive(true);
		loadMapBtn.gameObject.SetActive(true);
		playbg.gameObject.SetActive(true);
	}


	public void  PlayMultiplayer(){
		endlessBtn.gameObject.SetActive(false);
		multiplayerBtn.gameObject.SetActive(false);
		loadMapBtn.gameObject.SetActive(false);
		mpmenu.gameObject.SetActive(true);
		playbg.gameObject.SetActive(false);
	}

	// LAN 

	public void PlayLAN(){
		mpmenu.gameObject.SetActive(false);
		mplan.gameObject.SetActive(true);
	}

	public void CloseLAN(){
		mplan.gameObject.SetActive(false);
		mpmenu.gameObject.SetActive(true);
	}
		
	public void LANHost(){
		
	}
	
	// Serverbrowser / MP-Menu
	
	public void showMP(){
		mpcanvas.gameObject.SetActive(true);
		settingscanvas.gameObject.SetActive(false);
	}
	
	public void showSettings(){
		mpcanvas.gameObject.SetActive(false);
		settingscanvas.gameObject.SetActive(true);
	}
	
	// #############

	public void  CloseMultiplayer(){
		endlessBtn.gameObject.SetActive(true);
		multiplayerBtn.gameObject.SetActive(true);
		loadMapBtn.gameObject.SetActive(true);
		mpmenu.gameObject.SetActive(false);
		playbg.gameObject.SetActive(true);
	}
	
	public void  DisablePlayCampaign (){
		endlessBtn.gameObject.SetActive(false);
		multiplayerBtn.gameObject.SetActive(false);
		loadMapBtn.gameObject.SetActive(false);
		mpmenu.gameObject.SetActive(false);
		playbg.gameObject.SetActive(false);
	}

	public void  Position2 (){
		DisablePlayCampaign();
		CameraObject.SetFloat("Animate",1);
	}

	public void  Position1 (){
		CameraObject.SetFloat("Animate",0);
	}

	public void  GamePanel (){
		PanelControls.gameObject.SetActive(false);
		PanelVideo.gameObject.SetActive(false);
		PanelGame.gameObject.SetActive(true);
		PanelKeyBindings.gameObject.SetActive(false);

		lineGame.gameObject.SetActive( true);
		lineControls.gameObject.SetActive( false);
		lineVideo.gameObject.SetActive( false);
		lineKeyBindings.gameObject.SetActive( false);
	}

	public void  VideoPanel (){
		PanelControls.gameObject.SetActive( false);
		PanelVideo.gameObject.SetActive( true);
		PanelGame.gameObject.SetActive( false);
		PanelKeyBindings.gameObject.SetActive( false);

		lineGame.gameObject.SetActive( false);
		lineControls.gameObject.SetActive( false);
		lineVideo.gameObject.SetActive( true);
		lineKeyBindings.gameObject.SetActive( false);
	}

	public void  ControlsPanel (){
		PanelControls.gameObject.SetActive( true);
		PanelVideo.gameObject.SetActive( false);
		PanelGame.gameObject.SetActive( false);
		PanelKeyBindings.gameObject.SetActive( false);

		lineGame.gameObject.SetActive( false);
		lineControls.gameObject.SetActive( true);
		lineVideo.gameObject.SetActive( false);
		lineKeyBindings.gameObject.SetActive( false);
	}

	public void  KeyBindingsPanel (){
		PanelControls.gameObject.SetActive( false);
		PanelVideo.gameObject.SetActive( false);
		PanelGame.gameObject.SetActive( false);
		PanelKeyBindings.gameObject.SetActive( true);

		lineGame.gameObject.SetActive( false);
		lineControls.gameObject.SetActive( false);
		lineVideo.gameObject.SetActive( true);
		lineKeyBindings.gameObject.SetActive( true);
	}

	public void  MovementPanel (){
		PanelMovement.gameObject.SetActive( true);
		PanelCombat.gameObject.SetActive( false);
		PanelGeneral.gameObject.SetActive( false);

		lineMovement.gameObject.SetActive( true);
		lineCombat.gameObject.SetActive( false);
		lineGeneral.gameObject.SetActive( false);
	}

	public void  CombatPanel (){
		PanelMovement.gameObject.SetActive( false);
		PanelCombat.gameObject.SetActive( true);
		PanelGeneral.gameObject.SetActive( false);

		lineMovement.gameObject.SetActive( false);
		lineCombat.gameObject.SetActive( true);
		lineGeneral.gameObject.SetActive( false);
	}

	public void  GeneralPanel (){
		PanelMovement.gameObject.SetActive( false);
		PanelCombat.gameObject.SetActive( false);
		PanelGeneral.gameObject.SetActive( true);

		lineMovement.gameObject.SetActive( false);
		lineCombat.gameObject.SetActive( false);
		lineGeneral.gameObject.SetActive( true);
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
		areYouSure.gameObject.SetActive( true);
		DisablePlayCampaign();
	}

	public void  No (){
		areYouSure.gameObject.SetActive( false);
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
