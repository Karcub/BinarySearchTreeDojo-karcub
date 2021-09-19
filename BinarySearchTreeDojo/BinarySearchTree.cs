using System;
using System.Collections.Generic;

namespace BinarySearchTreeDojo
{
    public class BinarySearchTree
    {
        private Node _root;

        private BinarySearchTree()
        {
            // private constructor so it can't be instantiated like this
        }

        public static BinarySearchTree Build(List<int> elements)
        {
            BinarySearchTree tree = new BinarySearchTree();
            foreach (var element in elements) tree.Add(element);
            return tree;
        }
    
        public Boolean Search(int toFind) {
            Node temp = _root;
            Boolean returnVal = false;
            while (true)
            {
                if (toFind < temp.Data && temp.LinkLeft !=null) temp = temp.LinkLeft;
                else if (toFind > temp.Data && temp.LinkRight != null) temp = temp.LinkRight;
                else if (toFind == temp.Data)
                {
                    returnVal = true;
                    break;
                }
                else break;
            }
            return returnVal;
        }

        public void Add(int toAdd) {
            Node node = new Node(toAdd);
            if (_root == null)
            {
                _root = node;
                return;
            }
            Node temp = _root;
            while (true)
            {
                if (toAdd <= temp.Data)
                {
                    if (temp.LinkLeft == null)
                    {
                        temp.LinkLeft = node;
                        break;
                    }
                    else temp = temp.LinkLeft;
                }

                if (toAdd <= temp.Data) continue;
                if (temp.LinkRight == null)
                {
                    temp.LinkRight = node;
                    break;
                }
                else temp = temp.LinkRight;
            }
        }
        
        public void Remove(int toRemove)
        {
            _root = Remove(_root, toRemove);
        }
 
        private Node Remove(Node parent, int key)
        {
            if (parent == null) return parent;
            if (key < parent.Data) parent.LinkLeft = Remove(parent.LinkLeft, key); 
            else if (key > parent.Data) parent.LinkRight = Remove(parent.LinkRight, key);
            else
            {
                if (parent.LinkLeft == null) return parent.LinkRight;
                else if (parent.LinkRight == null) return parent.LinkLeft;
                parent.Data = MinValue(parent.LinkRight);
                parent.LinkRight = Remove(parent.LinkRight, parent.Data);
            }
            return parent;
        }
        
        private int MinValue(Node node)
        {
            int min = node.Data;
            while (node.LinkLeft != null)
            {
                min = node.LinkLeft.Data;
                node = node.LinkLeft;
            }
            return min;
        }
    }
}
