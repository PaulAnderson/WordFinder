using System;
using System.Collections.Generic;

public class Direction
{
    public int RowOffset { get; set; }
    public int ColOffset { get; set; }
    public Direction(int rowOffset, int colOffset)
    {
        this.RowOffset = rowOffset;
        this.ColOffset = colOffset;
    }
    public override bool Equals(object obj)
    {
        if (obj is Direction)
        {
            Direction otherDir = (Direction)obj;
            return (RowOffset == otherDir.RowOffset && ColOffset == otherDir.ColOffset);
        } else
        {
            return false;
        }
    }
    public static List<Direction> get8Directions()
    {
        List<Direction>  Directions = new List<Direction>();
        Directions.Add(new Direction(0, -1));  //N
        Directions.Add(new Direction(1, -1));  //NE
        Directions.Add(new Direction(1, 0));   //E
        Directions.Add(new Direction(1, 1));   //SE
        Directions.Add(new Direction(0, 1));   //S
        Directions.Add(new Direction(-1, 1));  //SW
        Directions.Add(new Direction(-1, 0));   //W
        Directions.Add(new Direction(-1, -1)); //NW
        return Directions;
    }
    public bool IsDiagonal()
    {
        return (RowOffset != 0 && ColOffset != 0);
    }
    public bool IsBackSlash()
    {
        return (RowOffset != 0 && ColOffset != 0 && RowOffset + ColOffset != 0);
    }
    public bool IsForwardSlash()
    {
        return (RowOffset != 0 && ColOffset != 0 && RowOffset+ColOffset==0);
    }

}

