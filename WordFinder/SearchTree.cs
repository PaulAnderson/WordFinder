using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder
{
    class SearchTree
    {
        node root;
        public LinkedList<node> nodesWithKeys;  //A list of leaf nodes.
        public class node
        {
            public LinkedList<node> childNodes;
            public node parent;
            public LinkedList<int> numericKeys; //Stores numeric key of dataDedup.dataItemList item that this (leaf) node points to - only for nodes that end a search path.
            public char label;     //character label of this node.Used for searching.
            public node()
            {
                //constructor for new,empty node
                this.childNodes = new LinkedList<node>();
                this.numericKeys=new LinkedList<int>();     //list of numeric keys for this node. Contains no duplicates.
                this.label = ' ' ;                          //default label.
            }
            public node(int numericKey) {
                //constructor for node with given numericKey
                this.childNodes = new LinkedList<node>();
                this.numericKeys=new LinkedList<int>();
                this.label = ' ';
                this.numericKeys.AddFirst(numericKey);
            }
            public node(char label)
            {
                //constructor for node with given label
                this.childNodes = new LinkedList<node>();
                this.numericKeys = new LinkedList<int>();
                this.label = label;
            }
            public void addNumericKey(int numericKey)
            {
                //Add numeric key to list of numeric keys for this node if it is not already in the list.
                if (!this.numericKeys.Contains(numericKey)) {
                    this.numericKeys.AddLast(numericKey);
                }
            }
            public void addNode(node newNode)
            {
                this.childNodes.AddLast(newNode);
                newNode.parent = this;
            }
        }
        public SearchTree()
        {
            root = new node();
            nodesWithKeys = new LinkedList<node>();
        }
        public Boolean addString(int Numerickey, String strAdd) {
            //Creates or finds path in trie corresponding to string given. Adds key to this path
            //returns true if string already existed.

           strAdd = strAdd + "~";  //end of string character to satisfy algorithm requirement that no string is a substring of another. This character will have been previously stripped from the input.
            node currentNode=root;	//start at root node
            for (int x=0;x<strAdd.Length;x++) { //iterate over string
                Boolean found=false;
                char currentSearchChar=char.Parse(strAdd.Substring(x,1));
                foreach (node childNode in currentNode.childNodes) {
                    if (childNode.label.Equals(currentSearchChar)) {
                        //found matching node.move to this node and continue comparison
                        currentNode=childNode;
                        found=true; //set flag to indicate successfully matched string.
                    }
                }
                if (!found) {
                    //not found.Add new node.
                    node newNode=new node(currentSearchChar);   //create new node for this character
                    currentNode.addNode(newNode);               //link this node to the currentNode
                    currentNode=newNode;                        //move to new node and contine string add.
                }
            }
            //finished adding
            //Now currentNode contains final node for this string.
            if (currentNode.numericKeys.Count > 0)
            {
                //this string was already in the tree
                if (!currentNode.numericKeys.Contains(Numerickey)) //no duplicates
                    currentNode.numericKeys.AddLast(Numerickey); //add the key
                return true;
            }
            else
            {
                //string was not already in the tree
                currentNode.numericKeys.AddFirst(Numerickey);
                nodesWithKeys.AddLast(currentNode);             //keep track of nodes with keys for later detection of duplicate strings
                return false;
            }
        }
        /// <summary>
        /// returns true if strFind is a prefix of a word in the tree
        /// </summary>
        public Boolean findPrefix(String strFind)
        {
            //attempts to find given string.
            //Returns (first) numericKey of string if found else -1
            node currentNode = root;	//start at root node
            for (int x = 0; x < strFind.Length; x++)
            { //iterate over string
                Boolean found = false;
                char currentSearchChar = char.Parse(strFind.Substring(x, 1));
                foreach (node childNode in currentNode.childNodes)
                {
                    if (childNode.label.Equals(currentSearchChar))
                    {
                        //found matching node.move to this node and continue comparison
                        currentNode = childNode;
                        found = true; //set flag to indicate successfully matched string.
                    }
                }
                if (!found) return false;
            }
            return true;
        }
        public int findString(String strFind)
        {
            //attempts to find given string.
            //Returns (first) numericKey of string if found else -1
            strFind = strFind + "~";  //end of string character to satisfy algorithm requirement that no string is a substring of another. This character will have been previously stripped from the input.
            node currentNode = root;	//start at root node
            for (int x = 0; x < strFind.Length; x++)
            { //iterate over string
                Boolean found = false;
                char currentSearchChar = char.Parse(strFind.Substring(x, 1));
                foreach (node childNode in currentNode.childNodes)
                {
                    if (childNode.label.Equals(currentSearchChar))
                    {
                        //found matching node.move to this node and continue comparison
                        currentNode = childNode;
                        found = true; //set flag to indicate successfully matched string.
                    }
                }
                if (!found) return -1;
            }
            return currentNode.numericKeys.First.Value;
        }
        public int[] findStringEx(String strFind)
        {
            //attempts to find given string.
            //Returns all numericKeys of leaf node after matching string, or null if no match.
            strFind = strFind + "~";  //end of string character to satisfy algorithm requirement that no string is a substring of another. This character will have been previously stripped from the input.
            node currentNode = root;	//start at root node
            for (int x = 0; x < strFind.Length; x++)
            { //iterate over string
                Boolean found = false;
                char currentSearchChar = char.Parse(strFind.Substring(x, 1));
                foreach (node childNode in currentNode.childNodes)
                {
                    if (childNode.label.Equals(currentSearchChar))
                    {
                        //found matching node.move to this node and continue comparison
                        currentNode = childNode;
                        found = true; //set flag to indicate successfully matched string.
                    }
                }
                if (!found) return null;
            }
            int[] outputArray=new int[currentNode.numericKeys.Count];   //initialize result array.
            currentNode.numericKeys.CopyTo(outputArray, 0);   //convert to array for (safe) return
            return outputArray;
        }
        public String getStringFromNode(node startNode) {
            //node should be a leaf node.
            String result = "";
            node currentNode = startNode;
            do
            {
                if (currentNode.label != '~') //~ character is to mark the end of the string in the tree.
                    result = currentNode.label+result ;
                currentNode = currentNode.parent;
            } while (currentNode != root);

            return result;
        }
        public String getStringFromNode(LinkedListNode<node> startNode)
        {
            //startNode should be a leaf node.
            String result = "";
            node currentNode = startNode.Value;
            do
            {
                if (currentNode.label!='~') //~ character is to mark the end of the string in the tree.
                    result = currentNode.label + result;
                currentNode = currentNode.parent;
            } while (currentNode != root);

            return result;
        }
    }
}
