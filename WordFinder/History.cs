using System;
using System.Collections.Generic;

class HistoryItem
{
    public int row { get; set; }
    public int col { get; set; }
    public HistoryItem(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}
class History
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
}

