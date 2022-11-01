using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public enum AudioChannel {Master, Sfx, Music};

	float masterVolumePercent = .5f;
	float sfxVolumePercent = 1;
	float musicVolumePercent = .8f;

	AudioSource sfx2DSource;
	AudioSource[] musicSources;
	AudioSource[] ambientSources;
	int activeMusicSourceIndex;
	int activeAmbientSourceIndex;

	public static AudioManager instance;

	Transform audioListener;
	Transform playerT;

	SoundLibrary library;

	void Awake() {

		if (instance != null) {
			Destroy (gameObject);
		} else {

			instance = this;
			DontDestroyOnLoad (gameObject);

			library = GetComponent<SoundLibrary> ();

			musicSources = new AudioSource[2];
			for (int i = 0; i < 2; i++) {
				GameObject newMusicSource = new GameObject ("Music source " + (i + 1));
				musicSources [i] = newMusicSource.AddComponent<AudioSource> ();
				newMusicSource.transform.parent = transform;
			}
			ambientSources = new AudioSource[2];
			for (int i = 0; i < 2; i++) {
				GameObject newambientSource = new GameObject ("Ambient source " + (i + 1));
				ambientSources [i] = newambientSource.AddComponent<AudioSource> ();
				newambientSource.transform.parent = transform;
			}
			
			GameObject newSfx2Dsource = new GameObject ("2D sfx source");
			sfx2DSource = newSfx2Dsource.AddComponent<AudioSource> ();
			newSfx2Dsource.transform.parent = transform;

//			audioListener = FindObjectOfType<AudioListener> ().transform;
			//playerT = FindObjectOfType<PlayerController> ().transform;

			masterVolumePercent = PlayerPrefs.GetFloat ("master vol", masterVolumePercent);
			sfxVolumePercent = PlayerPrefs.GetFloat ("sfx vol", sfxVolumePercent);
			musicVolumePercent = PlayerPrefs.GetFloat ("music vol", musicVolumePercent);
			Debug.Log("Audio Manager started");
		}
	}

	void Update() {
		/*if (playerT != null) {
			audioListener.position = playerT.position;
		}*/
	}

	public void SetVolume(float volumePercent, AudioChannel channel) {
		switch (channel) {
		case AudioChannel.Master:
			masterVolumePercent = volumePercent;
			break;
		case AudioChannel.Sfx:
			sfxVolumePercent = volumePercent;
			break;
		case AudioChannel.Music:
			musicVolumePercent = volumePercent;
			break;
		}

		musicSources [0].volume = musicVolumePercent * masterVolumePercent;
		musicSources [1].volume = musicVolumePercent * masterVolumePercent;
		musicSources [2].volume = musicVolumePercent * masterVolumePercent;
		ambientSources[0].volume = .3f ;
		ambientSources[1].volume = .3f ;

		PlayerPrefs.SetFloat ("master vol", masterVolumePercent);
		PlayerPrefs.SetFloat ("sfx vol", sfxVolumePercent);
		PlayerPrefs.SetFloat ("music vol", musicVolumePercent);
	}
	public void IntroStart(){
		musicSources[activeAmbientSourceIndex].Stop();
	}
	public void PlayMusic(AudioClip clip, float fadeDuration = 1) {
		musicSources[activeMusicSourceIndex].Stop();
		StartCoroutine(WaitForABit());
		IEnumerator WaitForABit(){
			yield return new WaitForSeconds(0.7f);
			activeMusicSourceIndex = 1 - activeMusicSourceIndex;
			musicSources [activeMusicSourceIndex].clip = clip;
			musicSources [activeMusicSourceIndex].loop = true;
			musicSources [activeMusicSourceIndex].Play();

			StartCoroutine(AnimateMusicCrossfade(fadeDuration));
		}
	}
	public void StopAmbient(){
		ambientSources[activeAmbientSourceIndex].Stop();
	}
	public void PlayAmbient(AudioClip clip, float fadeDuration = 1) {
		activeAmbientSourceIndex = 1 - activeAmbientSourceIndex;
		ambientSources [activeAmbientSourceIndex].clip = clip;
		ambientSources [activeAmbientSourceIndex].loop = true;
		ambientSources [activeAmbientSourceIndex].Play();

		StartCoroutine(AnimateAmbientCrossfade(fadeDuration));
	}
	IEnumerator AnimateAmbientCrossfade(float duration) {
		float percent = 0;
		while (percent < 1) {
			percent += Time.deltaTime * 1 / duration;
			ambientSources [activeAmbientSourceIndex].volume = Mathf.Lerp (0, .06f, percent);
			ambientSources [1-activeAmbientSourceIndex].volume = Mathf.Lerp (.06f, 0, percent);
			yield return null;
		}
	}

	void Start(){

	}
/*	
	public void PlaySound(AudioClip clip, Vector3 pos) {
		if (clip != null) {
			AudioSource.PlayClipAtPoint (clip, pos, sfxVolumePercent * masterVolumePercent);
		}
	}

	public void PlaySound(string soundName, Vector3 pos) {
		PlaySound (library.GetClipFromName (soundName), pos);
	}
*/
	public void PlaySound2D(string soundName) {
		sfx2DSource.PlayOneShot (library.GetClipFromName (soundName), sfxVolumePercent * masterVolumePercent);
	}


	IEnumerator AnimateMusicCrossfade(float duration) {
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * 1 / duration;
			musicSources [activeMusicSourceIndex].volume = Mathf.Lerp (0, musicVolumePercent * masterVolumePercent, percent);
			musicSources [1-activeMusicSourceIndex].volume = Mathf.Lerp (musicVolumePercent * masterVolumePercent, 0, percent);
			yield return null;
		}
	}
}