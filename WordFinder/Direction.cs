using System;
class Direction
{
    public int RowOffset { get; set; }
    public int ColOffset { get; set; }
    public Direction(int rowOffset, int colOffset)
    {
        this.RowOffset = rowOffset;
        this.ColOffset = colOffset;
    }
}

