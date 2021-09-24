using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class GameOverVOSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameover;

    private TrackAsset[] tracks;
    void Start()
    {
        TimelineAsset timeline = _gameover.GetComponent<PlayableDirector>().playableAsset as TimelineAsset;
        tracks = timeline.GetOutputTracks().Select(t => t).Where(t => t is AudioTrack).ToArray();
        Debug.Log(tracks.Length);
        int active = Random.Range(1, 3);
        Debug.Log(active);
        tracks[active].muted = false;
        StartCoroutine(MuteGameOverVO());
    }

    private IEnumerator MuteGameOverVO()
    {
        yield return new WaitUntil(() => _gameover.GetComponent<PlayableDirector>().state == PlayState.Playing);
        yield return new WaitWhile(() => _gameover.GetComponent<PlayableDirector>().state == PlayState.Playing);
        tracks[1].muted = true;
        tracks[2].muted = true;
    }

}
