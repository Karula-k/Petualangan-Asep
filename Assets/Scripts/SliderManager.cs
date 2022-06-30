using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    public Texture2D image;
    public int blocksPerline = 4;
    public int shuffleLength = 20;
    public float defaultMoveDuration = .2f;
    public float shuffleMoveDuration = .1f;
    enum PuzzleState { Solve,Shuffling,InPlay};
    PuzzleState state;

    Block emptyBlock;
    Block[,] blocks;
    Queue<Block> inputs;
    bool blockIsMoving;
    int shuffleMoveRemaining;
    Vector2Int prevShuffleOffset;
    public QuestManager qm;
    [SerializeField]private float[] xy;
    public void StarsPuzzle()
    {
        qm.puzzleSolve = false;
        CreatePuzzle();
        transform.position = new Vector2(transform.position.x+xy[0],transform.position.y+xy[1]);
        StartShuffle();
        
    }
    private void Update()
    {
        if (state == PuzzleState.Solve && Input.GetKeyDown(KeyCode.H))
        {
            StartShuffle();
        }
    }
    void CreatePuzzle()
    {
        blocks = new Block[blocksPerline, blocksPerline];
        Texture2D[,] imageSlices = ImageSlicer.GetSlices(image, blocksPerline);
        for(int y = 0; y < blocksPerline; y++)
        {
            for(int x = 0; x < blocksPerline; x++)
            {

                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                blockObject.transform.position = -Vector2.one * (blocksPerline - 1) * .5f + new Vector2(x, y);
                blockObject.transform.parent = transform;

                Block block = blockObject.AddComponent<Block>();
                block.OnBlockPressed += PlayerMoveBloc;
                block.OnFinishMoving += onBlockFinishMoving;
                block.Init(new Vector2Int(x, y), imageSlices[x, y]);
                blocks[x, y] = block;
                if (y == 0 && x == blocksPerline-1)
                {
                    emptyBlock = block;
                }
            }
        }
        inputs = new Queue<Block>();
    }
    void PlayerMoveBloc(Block blockTomove) {
        if (state == PuzzleState.InPlay)
        {
            inputs.Enqueue(blockTomove);
            MakeNextPlayerMove();
        }
    }

    void MakeNextPlayerMove()
    {
        while (inputs.Count > 0 && !blockIsMoving)
        {
            MoveBlock(inputs.Dequeue(),defaultMoveDuration);
        }
    }
    void MoveBlock(Block blockTomove,float duration)
    {
        if ((blockTomove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            blocks[blockTomove.coord.x, blockTomove.coord.y]=emptyBlock;
            blocks[emptyBlock.coord.x, emptyBlock.coord.y] = blockTomove;
            Vector2Int targetCoord = emptyBlock.coord;
            emptyBlock.coord = blockTomove.coord;
            blockTomove.coord = targetCoord;
            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockTomove.transform.position;
            blockTomove.MoveToPosition(targetPosition, duration);
            blockIsMoving = true;
        }
    }
    void onBlockFinishMoving() {
        blockIsMoving = false;
        CheckIsSolved(); 
        if (state == PuzzleState.InPlay)
        {
            MakeNextPlayerMove();
        }
        else if (state == PuzzleState.Shuffling)
        {
            if (shuffleMoveRemaining > 0)
            {
                makeNextShuffleMove();
            }
            else
            { 
                state = PuzzleState.InPlay;
            }
        }
    }
    void StartShuffle()
    {
        state = PuzzleState.Shuffling;
        shuffleMoveRemaining = shuffleLength;
        emptyBlock.gameObject.SetActive(false);
        makeNextShuffleMove();
    }
    void makeNextShuffleMove()
    {
        Vector2Int[] offsets = { new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1) };
        int randomIndex = Random.Range(0, offsets.Length);
        for(int i = 0; i < offsets.Length; i++)
        {
            Vector2Int offset = offsets[(randomIndex+i)%offsets.Length];
            if (offset != prevShuffleOffset * -1)
            {
                Vector2Int moveBlockCoord = emptyBlock.coord + offset;

                if (moveBlockCoord.x >= 0 && moveBlockCoord.x < blocksPerline && moveBlockCoord.y >= 0 && moveBlockCoord.y < blocksPerline)
                {
                    MoveBlock(blocks[moveBlockCoord.x, moveBlockCoord.y],shuffleMoveDuration);
                    shuffleMoveRemaining--;
                    prevShuffleOffset = offset;
                    break;
                }
            }
        }
    }
    void CheckIsSolved()
    {
        foreach(Block block in blocks)
        {
            if (!block.IsStartingCoord())
            {
                return;
            }
        }
        state = PuzzleState.Solve;
        qm.puzzleSolve = true;
        emptyBlock.gameObject.SetActive(true);

    }
}

