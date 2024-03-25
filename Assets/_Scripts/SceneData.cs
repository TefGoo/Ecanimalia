using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Scene Data", order = 1)]
public class SceneData : ScriptableObject
{
    [System.Serializable]
    public struct ScoreRange
    {
        public int minScore;
        public int maxScore;
        public Sprite sprite;
    }

    public ScoreRange[] scoreRanges;
    public int initialScore;
}
