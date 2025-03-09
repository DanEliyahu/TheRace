using UnityEngine;

public class PositionsUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private RectTransform player;
    [SerializeField] private RectTransform shepherd;
    [SerializeField] private RectTransform leftBorder;
    [SerializeField] private RectTransform rightBorder;
    
    [Header("World positions")]
    [SerializeField] private Transform startLine;
    [SerializeField] private Transform finishLine;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform shepherdTransform;
    
    private Vector2 playerPosition;
    private Vector2 shepherdPosition;
    private float worldDistance;

    private void Start()
    {
       playerPosition = new Vector2(leftBorder.anchoredPosition.x, player.anchoredPosition.y);
       shepherdPosition = new Vector2(leftBorder.anchoredPosition.x, player.anchoredPosition.y);
       player.anchoredPosition = playerPosition;
       shepherd.anchoredPosition = shepherdPosition;
       
       worldDistance = finishLine.position.x - startLine.position.x;
    }

    private void Update()
    {
        float playerDistance = finishLine.position.x - playerTransform.position.x;
        float shepherdDistance = finishLine.position.x - shepherdTransform.position.x;
        
        playerPosition.x = Mathf.Lerp(leftBorder.anchoredPosition.x, rightBorder.anchoredPosition.x, 1 - (playerDistance/worldDistance));
        shepherdPosition.x = Mathf.Lerp(leftBorder.anchoredPosition.x, rightBorder.anchoredPosition.x, 1 - (shepherdDistance/worldDistance));
        player.anchoredPosition = playerPosition;
        shepherd.anchoredPosition = shepherdPosition;
    }
}
