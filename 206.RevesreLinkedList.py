class ListNode(object):
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution206(object):
    def reverseList(self, head):
        if not head or not head.next:
            return head
        cur = head
        pre = None
        while cur is not None:
            temp = cur.next
            cur.next = pre  # 斷開魂結
            pre = cur  # 移動開始
            cur = temp
        return pre
