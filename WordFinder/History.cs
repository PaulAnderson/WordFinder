using System;
using System.Collections.Generic;
using System.Text;

class HistoryItem : IComparable 
{
    private String[] letters = { "A", "B", "C", "D" };
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
        //return base.ToString();
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
        //return base.ToString();
    }
}

