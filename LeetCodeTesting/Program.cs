
public class Testing
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int v)
        {
            val = v;
        }
    }

    public static ListNode GenerateList(params int[] vals)
    {
        var node = new ListNode(vals[0]);
        ListNode currentNode = node, HeadNode = node;

        for (var v = 1; v < vals.Length; v++)
        {
            var n = new ListNode(vals[v]);
            currentNode.next = n;
            currentNode = n;
        }

        printList(HeadNode);

        return HeadNode;
    }

    public static void printList(ListNode list)
    {
        Console.Write('[');
        while (list != null)
        {
            Console.Write(list.val);
            if (list.next != null) Console.Write(", ");
            list = list.next;
        }
        Console.WriteLine(']');
    }

    public static void Main(string[] args)
    {
        ListNode list1 = null;
        ListNode list2 = GenerateList(0);
        Console.WriteLine();
        printList(MergeTwoLists(list1, list2));
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode newHead, newCurrent;
        if (list2?.val < list1?.val || list1 == null)
        {
            newHead = newCurrent = list2;
            if (list2 != null) list2 = list2.next;
        }
        else
        {
            newHead = newCurrent = list1;
            if (list1 != null) list1 = list1.next;
        }

        while (list1 != null || list2 != null)
        {
            if (list2?.val < list1?.val || list1 == null)
            {
                newCurrent.next = list2;
                list2 = list2.next;
            }
            else
            {
                newCurrent.next = list1;
                list1 = list1.next;
            }

            newCurrent = newCurrent.next;
            
        }
        return newHead;
    }
}
