public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution1
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode();
        ListNode current = dummy;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        if (list1 != null)
        {
            current.next = list1;
        }
        if (list2 != null)
        {
            current.next = list2;
        }
        return dummy.next;
    }
}

public class Solution2
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        // 如果其中一個列表為空，直接返回另一個列表
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        // 遞歸比較節點值並合併鏈結串列
        if (list1.val <= list2.val)
        {
            // 選擇 list1 的節點，並合併剩餘的 list1.next 和 list2
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }
        else
        {
            // 選擇 list2 的節點，並合併 list1 和 list2.next
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
