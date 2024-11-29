class ListNode:
    def _int_(self, x):
        self.val = x
        self.next = None


# 進入環之前是a,兩指針相遇的前半環是b,兩指針相遇的後半環是c.
# 快指針走兩倍慢指針的距離，在走n個環以後遇到慢指針，可以寫成
# 2(a+b)=a+b+n(b+c)
# slow走的第一環就會遇到fast
class Solution:
    def detectCycle(self, head: ListNode) -> ListNode:
        slow = head
        fast = head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next
            if slow == fast:
                slow = head  # a=c 讓他們再相遇就是環的入口了
                while slow != fast:
                    slow = slow.next
                    fast = fast.next
                return slow
        return None
