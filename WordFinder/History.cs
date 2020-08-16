using System;
using System.Collections.Generic;
using System.Text;

class HistoryItem : IComparable 
{
    private String[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                 "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public int row { get; set; }
    public int col { get; set; }
    public HistoryItem(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
    protected int compareVal
    {
        get
        {
            return row + col * 4;
        }
    }
    public int CompareTo(object obj)
    {
        HistoryItem other = (HistoryItem)obj;
        return compareVal.CompareTo(other.compareVal);
    }
    public override string ToString()
    {
        return letters[col] + row.ToString();
    }
}
class History : IComparable
{
    private List<HistoryItem> histList;
    public History()
    {
        histList = new List<HistoryItem>();
    }
    public void Push(int row, int col)
    {
        histList.Add(new HistoryItem(row, col));
    }
    public HistoryItem Pop()
    {
        if (histList != null && histList.Count > 0)
        {
            int lastIndex = histList.Count - 1;
            HistoryItem item = histList[lastIndex];
            histList.RemoveAt(lastIndex);

            return item;
        }
        return null;
    }
    public bool Contains(int row, int col)
    {
        foreach (HistoryItem item in histList)
        {
            if (item.row == row && item.col == col)
            {
                return true;
            }
        }
        return false;
    }
    public int Count
    {
        get
        {
            return histList.Count;
        }
    }
    public List<HistoryItem> GetList()
    {
        return histList;
    }
    public History Copy()
    {
        History newHist = new History();
        foreach (HistoryItem item in GetList())
        {
            newHist.Push(item.row, item.col);
        }
        return newHist;
    }
    public bool Overlaps(List<HistoryItem> otherHistory)
    {
        for (int i=0;i<histList.Count;i++)
        {
            for (int j = 0; j < otherHistory.Count; j++)
            {
                if (histList[i].row==otherHistory[j].row && histList[i].col == otherHistory[j].col)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public int DirectionChanges()
    {
        if (histList.Count < 3)
        {
            return 0;
        } else
        {
            int changes = 0;
            for (int i = 2; i < histList.Count; i++)
            {
                if (!GetDirection(histList[i - 2], histList[i - 1]).Equals(GetDirection(histList[i - 1], histList[i])))
                {
                    changes++;
                }
            }
            return changes;
        }
    }
    public int CrossOvers()
    {
        if (histList.Count < 4)
        {
            return 0;
        }
        else
        {
            int crosses=0;
            List<Tuple<HistoryItem, HistoryItem>> Forwards = new List<Tuple<HistoryItem, HistoryItem>>();
            List<Tuple<HistoryItem, HistoryItem>> Backs = new List<Tuple<HistoryItem, HistoryItem>>();

            //Get all diagonals
            for (int i = 1; i < histList.Count; i++)
            {
                if (GetDirection(histList[i - 1], histList[i]).IsForwardSlash())
                {
                    Forwards.Add(Tuple.Create(histList[i - 1], histList[i]));
                }
                if (GetDirection(histList[i - 1], histList[i]).IsBackSlash())
                {
                    Backs.Add(Tuple.Create(histList[i - 1], histList[i]));
                }
            }

            //check which diagonals cross over
            if (Forwards.Count>0 && Backs.Count>0)
            {
                for(int i=0;i<Forwards.Count;i++)
                {
                    for (int j=0;j<Backs.Count;j++)
                    {
                        if (IsCrossed(Forwards[i], Backs[j])) 
                        {
                          crosses++;
                        }
                    }
                }
            }
            return crosses;
        }
    }
    public static bool IsCrossed(Tuple<HistoryItem, HistoryItem> forward, Tuple<HistoryItem, HistoryItem> back)
    {
        //Back components
        HistoryItem topLeft;
        HistoryItem bottomRight;

        //Forward Components
        HistoryItem topRight;
        HistoryItem bottomLeft;

        if (back.Item1.row > back.Item2.row)
        {
            topLeft = back.Item2;
            bottomRight = back.Item1;
        }
        else
        {
            topLeft = back.Item1;
            bottomRight = back.Item2;
        }
        if (forward.Item1.row > forward.Item2.row)
        {
            topRight = forward.Item2;
            bottomLeft = forward.Item1;
        }
        else
        {
            
            topRight = forward.Item1;
            bottomLeft = forward.Item2;
        }

        if (topLeft.row==topRight.row && topLeft.col+1==topRight.col)
        {
            return true;
        }
        return false;
    }
    public static Direction GetDirection(HistoryItem item1, HistoryItem item2)
    {
        return new Direction(item2.row - item1.row, item2.col - item1.col);
    }
    public int CompareTo(object obj)
    {
        History other = (History)obj;
        int itemCompareResult = 0;
        for (int i=0;i<Math.Min(histList.Count,other.GetList().Count);i++)
        {
            itemCompareResult = histList[i].CompareTo(other.GetList()[i]);
            if (itemCompareResult != 0) return itemCompareResult;
        }

        //Equal up to common point, now return difference based on length
        if (histList.Count == other.GetList().Count)
        {
            return 0;//shouldnt really get here?
        }
        if (histList.Count > other.GetList().Count)
        {
            return -1; //longer words first
        }
        if (histList.Count < other.GetList().Count)
        {
            return 1;
        }
        return 0;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(histList.Count*3);
        for (int i=0;i<histList.Count;i++)
        {
            sb.Append(histList[i].ToString());
        }
        return sb.ToString();
    }
}

